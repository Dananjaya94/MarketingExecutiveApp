using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Web.Services;
using System.Net.Mail;

public partial class AllIslandPromotion : System.Web.UI.Page
{
    OracleDataReader rd;
    DataTable dt = null;
    public int getstate = 0;
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd1;
    int check, checkMobil = 0;
    int a;
    string poltype;
    string cus_code, visit_code = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //populateTrantype();

        if (!this.IsPostBack)
        {

            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            TextBoxmecode.Text = Session["sfc_code"].ToString();
            gettitle();
            getPresentInsure();
            getbussinessocu();
            getpoltype();
           // getLeasingCompany();

            TextBoxCusCode.Text = getCusCode();
            

        }




    }



    protected void ButtonBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../home.aspx");
    }
    //clear fields
    private void Clear()
    {

        TextBoxvisitDate.Text = "";
        DropDownListtitle.SelectedIndex = 0;
        TextBoxfname.Text = "";
        TextBoxlname.Text = "";
        TextBoxadd1.Text = "";
        TextBoxadd2.Text = "";
        TextBoxcity.Text = "";
        TextBoxlandno.Text = "";
        TextBoxmobileno.Text = "";
        cmbbisocu.SelectedIndex = 0;
        TextBoxvehicleno.Text = "";
        DropDownListinsurer.SelectedIndex = 0;
        txtsuminsured.Text = "";
        txtcurrpremium.Text = "";
        DropDownListpoltype.SelectedIndex = 0;
        TextBoxredate.Text = "";
        txtremarks.Text = "";
        TextBoxfalldate.Text = "";

        TextBoxvisitDate.BorderColor = System.Drawing.Color.Black;
        DropDownListtitle.BorderColor = System.Drawing.Color.Black;
        TextBoxfname.BorderColor = System.Drawing.Color.Black; 
        TextBoxlname.BorderColor = System.Drawing.Color.Black;
        TextBoxadd1.BorderColor = System.Drawing.Color.Black;
        TextBoxadd2.BorderColor = System.Drawing.Color.Black;
        TextBoxcity.BorderColor = System.Drawing.Color.Black;
        TextBoxlandno.BorderColor = System.Drawing.Color.Black;
        TextBoxmobileno.BorderColor = System.Drawing.Color.Black;
        cmbbisocu.BorderColor = System.Drawing.Color.Black;
        TextBoxvehicleno.BorderColor = System.Drawing.Color.Black;
        DropDownListinsurer.BorderColor = System.Drawing.Color.Black;
        txtsuminsured.BorderColor = System.Drawing.Color.Black;
        txtcurrpremium.BorderColor = System.Drawing.Color.Black;
        DropDownListpoltype.BorderColor = System.Drawing.Color.Black;
        TextBoxredate.BorderColor = System.Drawing.Color.Black;
        txtremarks.BorderColor = System.Drawing.Color.Black;
        TextBoxfalldate.BorderColor = System.Drawing.Color.Black;



        //        LabelCustomerId.Text = Common.GenerateId("select pk_vph_t_cus_info.fn_get_cus_SPC_no('" + Session["sfc_brn_code"].ToString() + "') FROM DUAL");

        //clear datagrid





    }






    private Boolean ValidationCustomerDetails()
    {
        Boolean status = true;

        if (TextBoxvisitDate.Text.Equals(""))
        {
            status = false;
            TextBoxvisitDate.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxvisitDate.BorderColor = System.Drawing.Color.Black;
        }


        if (DropDownListtitle.SelectedValue.Equals(""))
        {
            status = false;
            DropDownListtitle.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            DropDownListtitle.BorderColor = System.Drawing.Color.Black;
        }


        if (TextBoxfname.Text.Equals(""))
        {
            status = false;
            TextBoxfname.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxfname.BorderColor = System.Drawing.Color.Black;
        }


        if (TextBoxlname.Text.Equals(""))
        {
            status = false;
            TextBoxlname.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxlname.BorderColor = System.Drawing.Color.Black;
        }

        if (TextBoxadd1.Text.Equals(""))
        {
            status = false;
            TextBoxadd1.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxadd1.BorderColor = System.Drawing.Color.Black;
        }
        if (TextBoxadd2.Text.Equals(""))
        {
            status = false;
            TextBoxadd2.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxadd2.BorderColor = System.Drawing.Color.Black;
        }

        //if (DropDownListcity.SelectedValue.Equals(""))
        //{
        //    status = false;
        //    DropDownListcity.BorderColor = System.Drawing.Color.Red;
        //}
        //else
        //{
        //    DropDownListcity.BorderColor = System.Drawing.Color.Black;
        //}

        //if (TextBoxlandno.Text.Equals(""))
        //{
        //    status = false;
        //    TextBoxlandno.BorderColor = System.Drawing.Color.Red;
        //}
        //else
        //{
        //    TextBoxlandno.BorderColor = System.Drawing.Color.Black;
        //}

        if (TextBoxmobileno.Text.Equals(""))
        {
            status = false;
            TextBoxmobileno.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxmobileno.BorderColor = System.Drawing.Color.Black;
        }
        if (cmbbisocu.SelectedValue.Equals(""))
        {
            status = false;
            cmbbisocu.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            cmbbisocu.BorderColor = System.Drawing.Color.Black;
        }

        if (DropDownListinsurer.SelectedValue.Equals(""))
        {
            status = false;
            DropDownListinsurer.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            DropDownListinsurer.BorderColor = System.Drawing.Color.Black;
        }

        if (txtsuminsured.Text.Equals(""))
        {
            status = false;
            txtsuminsured.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            txtsuminsured.BorderColor = System.Drawing.Color.Black;
        }

        if (txtcurrpremium.Text.Equals(""))
        {
            status = false;
            txtcurrpremium.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            txtcurrpremium.BorderColor = System.Drawing.Color.Black;
        }

        if (DropDownListpoltype.SelectedValue.Equals(""))
        {
            status = false;
            DropDownListpoltype.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            DropDownListpoltype.BorderColor = System.Drawing.Color.Black;
        }





        return status;
    }




    protected void ButtonClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    //public int checkNumber()

    //{

    //    int chkNumber = 0;

    //    string sq = "SELECT " +

    //    "  nvl(to_number(pk_all_general.fn_valid_mobile_no('" + TextBoxMobile.Text + "')),0)value " +

    //    " FROM DUAL ";

    //    try

    //    {

    //        con = new OracleConnection(Connection.con_str_oracle_cicco);

    //        con.Open();

    //        OracleCommand cmd1 = new OracleCommand(sq, con);

    //        OracleDataReader rd1 = cmd1.ExecuteReader();

    //        //if (rd1.HasRows)

    //        //{

    //        while (rd1.Read())

    //        {

    //            chkNumber = Convert.ToInt32(rd1[0]);

    //        }

    //        //}

    //    }

    //    catch (Exception ex)

    //    {

    //        throw ex;

    //    }

    //    finally

    //    {

    //        con.Close();

    //    }

    //    return chkNumber;

    //}


    //protected void updatecusID() {

    //    OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
    //    OracleCommand cmd = new OracleCommand();
    //    cmd.Connection = conn;
    //    cmd.CommandText = "pk_vph_t_cus_info.pu_update_cus_seq";

    //    cmd.CommandType = CommandType.StoredProcedure;

    //    cmd.Parameters.Add("wkbrn", OracleType.VarChar).Value = Session["sfc_brn_code"].ToString();

    //    cmd.Parameters.Add("wkcol", OracleType.VarChar).Value = "SPC";


    //    try
    //    {
    //        conn.Open();

    //        a = cmd.ExecuteNonQuery();

    //    }
    //    catch (Exception ex) {
    //    }
    //    conn.Close();
    //}



    protected void gettitle()
    {
        DropDownListtitle.Items.Clear();
        DropDownListtitle.Items.Add(new ListItem("----- Select Title -----", ""));
        string query = " SELECT tit_title_desc,tit_title_code FROM sm_r_title " +
                       " WHERE tit_title_code IN ('MR.', 'MRS', 'MISS.', 'DR', 'REV', 'CAPT', 'HON', 'MS.', 'PROF', 'Dr' ) ";
        Common.FillLOV(DropDownListtitle, query);

    }
    protected void getPresentInsure()
    {
        DropDownListinsurer.Items.Clear();
        DropDownListinsurer.Items.Add(new ListItem("Select insure", ""));
        string query = "SELECT  rft_description ,rft_code FROM cm_r_reference_two WHERE rft_type = 'PI' ";
        Common.FillLOV(DropDownListinsurer, query);

    }

    protected void getbussinessocu()
    {
        cmbbisocu.Items.Clear();
        cmbbisocu.Items.Add(new ListItem("Select Occupations", ""));
        string query = " SELECT  moc_main_occ_name,moc_main_occ_code  FROM ri_r_main_occupation ORDER BY moc_main_occ_name ";
        Common.FillLOV(cmbbisocu, query);

    }


    //protected void getLeasingCompany()
    //{
    //    DropDownListleasing.Items.Clear();
    //    DropDownListleasing.Items.Add(new ListItem("Select Leasing Company", ""));
    //    string query = "select  fin_name,fin_code from sm_t_fin_intrestORDER BY fin_name ";
    //    Common.FillLOV(DropDownListleasing, query);

    //}


    protected void getpoltype()
    {
        DropDownListpoltype.Items.Clear();
        DropDownListpoltype.Items.Add(new ListItem("----- Select Type -----", ""));
        string query = " select  prd_description,prd_code from uw_m_products where prd_cla_code NOT IN ('M3', 'M4', 'M2') " +
                       "  order by prd_cla_code, PRD_CODE, prd_description ";

        Common.FillLOV(DropDownListpoltype, query);

    }

    public string getCusCode()
    {

        
        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            con.Open();
            string sql = "SELECT  pk_sm_t_me_visits.FN_GEN_ME_CUST_CODE('"+ TextBoxmecode.Text + "')  FROM DUAL";


            cmd = new OracleCommand(sql, con);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                cus_code = rd[0].ToString();



            }
            con.Close();
        }
        catch (Exception ex)
        {

        }
        return cus_code;
    }

    public string getVisitCode()
    {


        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            con.Open();
            string sql = "select pk_sm_t_me_visits.FN_GEN_ME_VISIT_SEQ('"+ TextBoxmecode.Text + "')  FROM DUAL";


            cmd = new OracleCommand(sql, con);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                visit_code = rd[0].ToString();



            }
            con.Close();
        }
        catch (Exception ex)
        {

        }
        return visit_code;
    }

    public void SaveEntry()
    {

      


        if (ValidationCustomerDetails())
        {


        
        
            
            string add1 = TextBoxadd1.Text.ToUpper();
            add1 = TextBoxadd1.Text.Replace("'", "''");
            string add2 = TextBoxadd2.Text.ToUpper();
            add2 = TextBoxadd2.Text.Replace("'", "''");

            




            string sql = "INSERT INTO  SM_T_ME_CUSTOMERS " +
     " ( mec_cus_code,mec_cus_me,mec_cus_title,mec_cus_first_name,mec_cus_last_name,mec_cus_adr_no,mec_cus_adr_str,mec_cus_adr_city, mec_cus_tel,mec_cus_mob,mec_cus_brn_code) " +
     "  VALUES ('"+TextBoxCusCode.Text+"','"+TextBoxmecode.Text+"','"+DropDownListtitle.Text+"','"+TextBoxfname.Text+"','"+TextBoxlname.Text+"','"+add1+"','"+add2+"','"+TextBoxcity.Text+"', "+
     "  '"+TextBoxlandno.Text+"','"+TextBoxmobileno.Text+"','"+TextBoxbranch.Text+"')";


            int x = Common.Save(sql);
            if (x == 1)
            {
                LabelMsg.ForeColor = System.Drawing.Color.Green;
                LabelMsg.Text = "insert success!";
               // TextBoxCusCode.Text = getCusCode();


            }


            else
            {
                LabelMsg.ForeColor = System.Drawing.Color.Red;
                LabelMsg.Text = "insert Error!";

            }
        
        }

        else
        {
            LabelMsg.ForeColor = System.Drawing.Color.Red;
            LabelMsg.Text = "error values :Fields Must  be enterd";

        }
    }

    public void SaveVisitEntry()
    {
        string renewal_date = null;
        string fallowup_date = null;

        TextBoxVisitNo.Text = getVisitCode();

        if (ValidationCustomerDetails())
        {




           string visit_date = Convert.ToDateTime(TextBoxvisitDate.Text).ToString("dd/MMM/yyyy").ToString();

            if (TextBoxredate.Text != "")
            {
                renewal_date = Convert.ToDateTime(TextBoxredate.Text).ToString("dd/MMM/yyyy").ToString();
            }

            else
            {

            }

            if (TextBoxfalldate.Text != "")
            {
                fallowup_date = Convert.ToDateTime(TextBoxfalldate.Text).ToString("dd/MMM/yyyy").ToString();
            }

            else
            {
            }



            string sql = "INSERT INTO  sm_t_me_visits " +
     " (mev_seq_no,mev_me_code,mev_visit_date,mev_cus_code,mev_pol_type,mev_bus_occupation,mev_vehi_no,mev_cur_insurer,mev_cur_sum_insured,mev_cur_premium,mev_renewal_date,mev_folloup_date,mev_remarks) " +
     "  VALUES ('" + TextBoxVisitNo.Text + "','" + TextBoxmecode.Text + "','" + visit_date + "','" + TextBoxCusCode.Text + "','" + DropDownListpoltype.SelectedValue + "','" + cmbbisocu.SelectedValue + "','" + TextBoxvehicleno.Text + "','"+DropDownListinsurer.SelectedValue+"', " +
     "  '" + txtsuminsured.Text + "','" + txtcurrpremium.Text + "','" + renewal_date + "','"+fallowup_date+"','"+ txtremarks.Text+ "')";


            int x = Common.Save(sql);
            if (x == 1)
            {
                LabelMsg.ForeColor = System.Drawing.Color.Green;
                LabelMsg.Text = "insert success!";

                Clear();
                TextBoxCusCode.Text = getCusCode();

            }


            else
            {
                LabelMsg.ForeColor = System.Drawing.Color.Red;
                LabelMsg.Text = "insert Error!";

            }

        }

        else
        {
            LabelMsg.ForeColor = System.Drawing.Color.Red;
            LabelMsg.Text = "error values :Fields Must  be enterd";

        }
    }

    public int checkDetail()
    {
        int cnt = 0;
        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            con.Open();
            string sql = "select count(*) cnt  from SM_T_ME_CUSTOMERS where mec_cus_code='"+TextBoxCusCode.Text+"'";


            cmd = new OracleCommand(sql, con);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                cnt =Convert.ToInt32( rd[0].ToString());
                


            }
           con.Close();
        }
        catch (Exception ex)
        {

        }
        return cnt;

    }
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        int count = checkDetail();
        if (count > 0)
        {
            SaveVisitEntry();
           
            
        }

        else
        {
            SaveEntry();
            SaveVisitEntry();
            // TextBoxCusCode.Text = getCusCode();
        }
        
        
    }

    protected void ButtonClear_Click1(object sender, EventArgs e)
    {
        Clear();
    }

    protected void ButtonBack_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/DaillyCallMenu.aspx");
    }
}