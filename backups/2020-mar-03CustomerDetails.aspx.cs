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
    int check, checkMobil,checkinsert = 0;
    int a;
    string poltype;
    string cus_code, visit_code = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //populateTrantype();

        if (!this.IsPostBack)
        {

            if (Session["sfc_brn_code"].ToString()!="" && Session["sfc_code"].ToString() != "") { 

            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            TextBoxmecode.Text = Session["sfc_code"].ToString();
            gettitle();
            getPresentInsure();
            getbussinessocu();
            getpoltype();
           // getLeasingCompany();

            TextBoxCusCode.Text = getCusCode();
            }

            else
            {
                Response.Redirect("acc_login.aspx");
            }

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
        TextBoxpolno.Text = "";
        TextBoxleasing.Text = "";
        DropDownListbusinesscl.SelectedIndex = 0;

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
        DropDownListbusinesscl.BackColor = System.Drawing.Color.Black;



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



        if (TextBoxcity.Text.Equals(""))
        {
            status = false;
            TextBoxcity.BorderColor = System.Drawing.Color.Red;
        }
        else
        {

            //if (lblcity.Text.Equals(""))
            //{
            //    status = false;
                
            //    lblcity.Text = "error values :Select City";
            //    TextBoxcity.BorderColor = System.Drawing.Color.Red;

            //}

            //else
            //{
                TextBoxcity.BorderColor = System.Drawing.Color.Black;
            //}
        }

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
        string query = "SELECT moc_main_occ_name,moc_main_occ_code FROM SM_T_OCCUPATIONS WHERE moc_print ='Y'  ORDER BY moc_main_occ_code";
        Common.FillLOV(cmbbisocu, query);

    }





    protected void getpoltype()
    {
        DropDownListpoltype.Items.Clear();
        DropDownListpoltype.Items.Add(new ListItem("----- Select Type -----", ""));
        string query = " select prd_code ||' - '|| prd_description,prd_code  from uw_m_products where prd_cla_code NOT IN ('M3', 'M4', 'M2')  "+
                       " order by  PRD_CODE, prd_description";

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

    public int SaveAllEntry()
    {


      

        if (ValidationCustomerDetails())
        {



            string renewal_date = null;
            string fallowup_date = null;

            string add1 = TextBoxadd1.Text.ToUpper();
            add1 = TextBoxadd1.Text.Replace("'", "''");
            string add2 = TextBoxadd2.Text.ToUpper();
            add2 = TextBoxadd2.Text.Replace("'", "''");

            string todaydate= DateTime.Today.ToString("dd/MMM/yyyy");
            string visit_date = Convert.ToDateTime(TextBoxvisitDate.Text).ToString("dd/MMM/yyyy").ToString();
            string time = Convert.ToDateTime(TextBoxvisitDate.Text).ToString("hh:mm tt").ToString();

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



            try
            {
                con = new OracleConnection(Connection.con_str_oracle_cicco);
                cmd = new OracleCommand();
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Clear();
                cmd.CommandText = "pk_sm_t_me_visits.PU_All_INS_CUS_DATA";
                cmd.Parameters.Add("wkmec_cus_me", OracleType.VarChar, 5).Value =TextBoxmecode.Text;
                cmd.Parameters.Add("wkmec_cus_title", OracleType.VarChar, 5).Value =   DropDownListtitle.Text;
                cmd.Parameters.Add("wkmec_cus_first_name", OracleType.VarChar, 100).Value = TextBoxfname.Text;
                cmd.Parameters.Add("wkmec_cus_last_name", OracleType.VarChar, 100).Value =  TextBoxlname.Text;
                cmd.Parameters.Add("wkmec_cus_adr_no", OracleType.VarChar, 100).Value = TextBoxadd1.Text;
                cmd.Parameters.Add("wkmec_cus_adr_str", OracleType.VarChar, 100).Value =  TextBoxadd2.Text;
                cmd.Parameters.Add("wkmec_cus_adr_city", OracleType.VarChar, 100).Value =  TextBoxcity.Text;
                cmd.Parameters.Add("wkmec_cus_tel", OracleType.VarChar, 15).Value =  TextBoxlandno.Text;
                cmd.Parameters.Add("wkmec_cus_mob", OracleType.VarChar, 15).Value = TextBoxmobileno.Text;
                cmd.Parameters.Add("wkmec_cus_brn_code", OracleType.VarChar, 4).Value = TextBoxbranch.Text;
                cmd.Parameters.Add("wkmev_visit_date", OracleType.DateTime).Value = Convert.ToDateTime( visit_date);
                cmd.Parameters.Add("wkmev_pol_type", OracleType.VarChar, 5).Value =  DropDownListpoltype.SelectedValue;
                cmd.Parameters.Add("wkmev_bus_occupation", OracleType.VarChar, 50).Value =  cmbbisocu.SelectedItem.Text;
                cmd.Parameters.Add("wkmev_vehi_no", OracleType.VarChar, 10).Value =  TextBoxvehicleno.Text;
                cmd.Parameters.Add("wkmev_cur_insurer", OracleType.VarChar, 15).Value =  DropDownListinsurer.SelectedValue;
                cmd.Parameters.Add("wkmev_cur_sum_insured", OracleType.Number, 17).Value =  txtsuminsured.Text;
                cmd.Parameters.Add("wkmev_cur_premium", OracleType.Number, 17).Value = txtcurrpremium.Text;
                cmd.Parameters.Add("wkmev_renewal_date", OracleType.DateTime).Value =  Convert.ToDateTime(renewal_date);
                cmd.Parameters.Add("wkmev_folloup_date", OracleType.DateTime).Value =  Convert.ToDateTime(fallowup_date);
                cmd.Parameters.Add("wkmev_busi_closed", OracleType.VarChar, 2).Value =DropDownListbusinesscl.SelectedValue;
                cmd.Parameters.Add("wkmev_busi_closed_date", OracleType.DateTime).Value =  Convert.ToDateTime(todaydate);
                cmd.Parameters.Add("wkmev_policy_no", OracleType.VarChar, 20).Value =  TextBoxpolno.Text;
                cmd.Parameters.Add("wkmev_remarks", OracleType.VarChar, 100).Value =  txtremarks.Text;
                cmd.Parameters.Add("wkmev_fin_code", OracleType.VarChar, 6).Value = TextBoxleasingcode.Text;


                checkinsert = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
                con.Close();

            }



        }

        else
        {
            LabelMsg.ForeColor = System.Drawing.Color.Red;
            LabelMsg.Text = "error values :Fields Must  be enterd";

        }

        return checkinsert;
    }

    public int SaveVisitEntry()
    {
        string renewal_date = null;
        string fallowup_date = null;

        TextBoxVisitNo.Text = getVisitCode();
       
        if (ValidationCustomerDetails())
        {



            string todaydate = DateTime.Today.ToString("dd/MMM/yyyy");
            string visit_date = Convert.ToDateTime(TextBoxvisitDate.Text).ToString("dd/MMM/yyyy").ToString();
             string time = Convert.ToDateTime(TextBoxvisitDate.Text).ToString("hh:mm tt").ToString();

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


            try
            {
                con = new OracleConnection(Connection.con_str_oracle_cicco);
                cmd = new OracleCommand();
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Clear();
                cmd.CommandText = "pk_sm_t_me_visits.PU_INS_VISIT_DATA  ";
                cmd.Parameters.Add("wkmev_me_code", OracleType.VarChar, 5).Value = TextBoxmecode.Text;
                cmd.Parameters.Add("wkmev_visit_date", OracleType.DateTime).Value = Convert.ToDateTime(visit_date);
                cmd.Parameters.Add("wkmev_cus_code", OracleType.VarChar, 20).Value = TextBoxCusCode.Text;
                cmd.Parameters.Add("wkmev_pol_type", OracleType.VarChar, 5).Value = DropDownListpoltype.SelectedValue;
                cmd.Parameters.Add("wkmev_bus_occupation", OracleType.VarChar, 50).Value = cmbbisocu.SelectedItem.Text;
                cmd.Parameters.Add("wkmev_vehi_no", OracleType.VarChar, 10).Value = TextBoxvehicleno.Text;
                cmd.Parameters.Add("wkmev_cur_insurer", OracleType.VarChar, 15).Value = DropDownListinsurer.SelectedValue;
                cmd.Parameters.Add("wkmev_cur_sum_insured", OracleType.Number, 17).Value = txtsuminsured.Text;
                cmd.Parameters.Add("wkmev_cur_premium", OracleType.Number, 17).Value = txtcurrpremium.Text;
                cmd.Parameters.Add("wkmev_renewal_date", OracleType.DateTime).Value = Convert.ToDateTime(renewal_date);
                cmd.Parameters.Add("wkmev_folloup_date", OracleType.DateTime).Value = Convert.ToDateTime(fallowup_date);
                cmd.Parameters.Add("wkmev_busi_closed", OracleType.VarChar, 2).Value = DropDownListbusinesscl.SelectedValue;
                cmd.Parameters.Add("wkmev_busi_closed_date", OracleType.DateTime).Value = Convert.ToDateTime(todaydate);
                cmd.Parameters.Add("wkmev_policy_no", OracleType.VarChar, 20).Value = TextBoxpolno.Text;
                cmd.Parameters.Add("wkmev_remarks", OracleType.VarChar, 100).Value = txtremarks.Text;

                check = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();

            }


        }

        else
        {
            LabelMsg.ForeColor = System.Drawing.Color.Red;
            LabelMsg.Text = "error values :Fields Must  be enterd";

        }

        return check;
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
        int chk = 0;
        int count = checkDetail();
        if (count > 0)
        {
          chk=  SaveVisitEntry();

            if (chk > 0)
            {

                LabelMsg.ForeColor = System.Drawing.Color.Green;
                LabelMsg.Text = "Success!";
                Clear();

            }

            else
            {
                LabelMsg.ForeColor = System.Drawing.Color.Red;
                LabelMsg.Text = "error values :Insert fail";
            }
        }

        else
        {
         chk= SaveAllEntry();

            if(chk>0)
            {

                LabelMsg.ForeColor = System.Drawing.Color.Green;
                LabelMsg.Text = "Success!";
                Clear();
                
            }

            else
            {
                LabelMsg.ForeColor = System.Drawing.Color.Red;
                LabelMsg.Text = "error values :Insert fail";
            }
   
            // TextBoxCusCode.Text = getCusCode();
        }
        
        
    }

    protected void ButtonClear_Click1(object sender, EventArgs e)
    {
        Clear();
    }

    protected void ButtonBack_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/VisitUpdateMenu.aspx");
    }
}