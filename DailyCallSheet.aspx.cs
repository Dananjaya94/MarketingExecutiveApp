using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class quotation : System.Web.UI.Page
{

    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;

    int a;
    int checkvisit=0;
    int checkcus = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        // String username;
        TextBoxbranch.Text = Session["sfc_brn_code"].ToString();//"YY00";////"BP00";//
        TextBoxmecode.Text = Session["sfc_code"].ToString();//"08449";//"09348";//

        if (!this.IsPostBack)
        {
            //getbusiclosed();
            getpoltype();
            getPresentInsure();
            gettitle();
        }
    }


    protected void getMeDataComment()
    {
        string from_date = Convert.ToDateTime(txtfromdate.Text).ToString("dd/MMM/yyyy").ToString();
        string to_date = Convert.ToDateTime(txttodate.Text).ToString("dd/MMM/yyyy").ToString();


        string sqlquery = "SELECT " +
                          "   to_char(mev_visit_date,'dd-Mon-yyyy') VISIT_DATE " +
                          "   , RANK() OVER (PARTITION BY TRUNC(mev_visit_date)  ORDER BY mev_seq_no  ) No " +
                          "   , UPPER(mec_cus_title || '.' || mec_cus_first_name || ' ' || mec_cus_last_name  ) INSURED " +
                          "   , mec_cus_tel Land_Line " +
                          "   , mec_cus_mob Mobile_no" +
                          "   , UPPER(mec_cus_adr_no || ' ' || mec_cus_adr_str || ' ' || mec_cus_adr_CITY)   ADDRESS " +
                          "   , pk_ri_r_main_occupation.fn_get_mainocc_des(mev_bus_occupation) OCCUPATION " +
                          "   , (SELECT rft_description FROM cm_r_reference_two WHERE  rft_type = 'PI'  AND rft_code = mev_cur_insurer ) PRESENT_INSURED " +
                          "   , mev_cur_sum_insured SUM_INSURED " +
                         "    , mev_cur_premium PREMIUM " +
                         "    , pk_uw_m_products.fn_get_prod_desc(mev_pol_type) PRODUCT " +
                          "   , to_char( mev_renewal_date,'dd-Mon-yyyy') RENEWAL_DATE " +
                          "   , to_char( mev_folloup_date,'dd-Mon-yyyy') FOLLOWUP_DATE " +
                          "   , UPPER(mev_vehi_no) Risk_name " +
                          "   , UPPER(mev_remarks) REMARKS " +
                          "   , mev_busi_closed Business_Closed" +
                          "   , to_char( mev_busi_closed_date,'dd-Mon-yyyy') CLOSED_DATE  " +
                          "   , mev_policy_no Policy_no " +
                          "   FROM SM_T_ME_CUSTOMERS A, SM_T_ME_VISITS B " +
                          "   WHERE mec_cus_code = mev_cus_code " +
                          "   AND mev_me_code = '" + TextBoxmecode.Text + "' " +
                          "   AND TRUNC(mev_visit_date)BETWEEN   TO_DATE('" + from_date + "') and TO_DATE('" + to_date + "') ";

        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);

        try
        {

            conn.Open();
            OracleDataAdapter adp = new OracleDataAdapter(sqlquery, conn);
            DataTable dt = new DataTable();

            adp.Fill(dt);

            grid1.DataSource = dt;
            grid1.DataBind();

            //conn.Open();
            //grid1.EmptyDataText = "No Records Found";

            //grid1.DataSource = cmd.ExecuteReader();

            //grid1.DataBind();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }

    }


    protected void getMeData()
    {
        //string from_date = Convert.ToDateTime(txtfromdate.Text).ToString("dd/MMM/yyyy").ToString();
        //string to_date = Convert.ToDateTime(txttodate.Text).ToString("dd/MMM/yyyy").ToString();

        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_me_daily_call_sheet";

        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);
        prm1.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(prm1);

        OracleParameter prm2 = new OracleParameter("wkmecode", OracleType.VarChar);
        prm2.Direction = ParameterDirection.Input;
        prm2.Value = TextBoxmecode.Text;
        cmd.Parameters.Add(prm2);

        OracleParameter prm3 = new OracleParameter("wk_date", OracleType.VarChar);
        prm3.Direction = ParameterDirection.Input;
        prm3.Value = Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString();
        cmd.Parameters.Add(prm3);

        OracleParameter prm4 = new OracleParameter("wk_date1", OracleType.VarChar);
        prm4.Direction = ParameterDirection.Input;
        prm4.Value = Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString();
        cmd.Parameters.Add(prm4);


        try
        {
            conn.Open();
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();

            adp.Fill(dt);

            grid1.DataSource = dt;
            grid1.DataBind();

            //conn.Open();
            //grid1.EmptyDataText = "No Records Found";
            //grid1.DataSource = cmd.ExecuteReader();
            //grid1.DataBind();

            foreach (GridViewRow row in grid1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string visit = row.Cells[1].Text;
                    string renewal = row.Cells[11].Text;
                    string folowup = row.Cells[12].Text;
                    string closed = row.Cells[16].Text;

                    if (visit == "01-Jan-0001")
                    {
                        row.Cells[1].Text = null;
                    }
                    if (renewal == "01-Jan-0001")
                    {
                        row.Cells[11].Text = null;
                    }
                    if (folowup == "01-Jan-0001")
                    {
                        row.Cells[12].Text = null;
                    }
                    if (closed == "01-Jan-0001")
                    {
                        row.Cells[16].Text = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }

    }

    protected void btngetMe_Click(object sender, EventArgs e)
    {
        getMeData();
    }

    public void clear()
    {
        txtvistdate.Text = "";
        txtoccupation.Text = "";
        DropDownListinsurer.SelectedValue = "";
        txtsum.Text = "";
        txtpremium.Text = "";
        txtriskname.Text = "";
        txtremarks.Text = "";
        DropDownListbusinesscl.SelectedValue = "";
        txtpolicyno.Text = "";
        txtrenewaldate.Text = "";
        txtfollowup.Text = "";
        txtmevseq.Text = "";
        DropDownListpoltype.SelectedValue = "";
        DropDownListtitle.SelectedValue = "";
        TextBoxfname.Text = "";
        TextBoxlname.Text = "";
        TextBoxadd1.Text = "";
        TextBoxadd2.Text = "";
        TextBoxcity.Text = "";
        TextBoxlandno.Text = "";
        TextBoxmobileno.Text = "";
        lblcity.Text = "";
    }

    protected void Display(object sender, EventArgs e)
    {
        clear();
        //Label18.Visible = true;
        //txtpolicyno.Visible = true;
        //Label9.Visible = true;
        //txtfollowup.Visible = true;
        //Label15.Visible = true;
        //txtrenewaldate.Visible = true;

        int rowIndex = Convert.ToInt32(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex);
        GridViewRow row = grid1.Rows[rowIndex];

        if (row.Cells[1].Text == "")
        {

        }
        else
        {
            txtvistdate.Text = Convert.ToDateTime(row.Cells[1].Text).ToString("MM/dd/yyyy").Replace("&nbsp;", "");
        }
        //txtinsured.Text = row.Cells[3].Text.Replace("&nbsp;", "");
        //txtaddress.Text = row.Cells[5].Text.Replace("&nbsp;", "");
        txtoccupation.Text = row.Cells[6].Text.Replace("&nbsp;", "");
        DropDownListinsurer.SelectedValue=row.Cells[28].Text;
        txtsum.Text = row.Cells[8].Text.Replace("&nbsp;", "");
        txtpremium.Text = row.Cells[9].Text.Replace("&nbsp;", "");
        //txtproduct.Text = row.Cells[10].Text.Replace("&nbsp;", "");
        txtriskname.Text = row.Cells[13].Text.Replace("&nbsp;", "");
        txtremarks.Text = row.Cells[14].Text.Replace("&nbsp;", "");
        DropDownListbusinesscl.SelectedValue = row.Cells[15].Text.Replace("&nbsp;", "");
        txtclosedate.Text= Convert.ToDateTime(row.Cells[16].Text).ToString("MM/dd/yyyy").Replace("&nbsp;", "");
        if (DropDownListbusinesscl.SelectedValue == "Y")
        {
            txtpolicyno.Text = row.Cells[17].Text.Replace("&nbsp;", "").ToUpper();
            //Label18.Visible = true;
            //txtpolicyno.Visible = true;
            //Label9.Visible = false;
            //txtfollowup.Visible = false;
            //Label15.Visible = false;
            //txtrenewaldate.Visible = false;


        }
        else if (DropDownListbusinesscl.SelectedValue == "N")
        {
            if (row.Cells[11].Text == "")
            {            }
            else
            {
                txtrenewaldate.Text = Convert.ToDateTime(row.Cells[11].Text).ToString("MM/dd/yyyy").Replace("&nbsp;", "");
            }
            if (row.Cells[12].Text == "")
            {            }
            else
            {
                txtfollowup.Text = Convert.ToDateTime(row.Cells[12].Text).ToString("MM/dd/yyyy").Replace("&nbsp;", "");
            }
            //Label18.Visible = false;
            //txtpolicyno.Visible = false;
            //Label9.Visible = true;
            //txtfollowup.Visible = true;
            //Label15.Visible = true;
            //txtrenewaldate.Visible = true;

        }
        else if (DropDownListbusinesscl.SelectedValue == "")
        {
            if (row.Cells[11].Text == "")
            { }
            else
            {
                txtrenewaldate.Text = Convert.ToDateTime(row.Cells[11].Text).ToString("MM/dd/yyyy").Replace("&nbsp;", "");
            }
            //Label18.Visible = false;
            //txtpolicyno.Visible = false;
            //Label9.Visible = false;
            //txtfollowup.Visible = false;
        }

        //if (row.Cells[16].Text == "")
        //{        //}
        //else
        //{
        //    txtcloasedate.Text = Convert.ToDateTime(row.Cells[16].Text).ToString("yyyy-MM-dd").Replace("&nbsp;", "");
        //}

        txtmevseq.Text= row.Cells[18].Text.Replace("&nbsp;", "");
        DropDownListpoltype.SelectedValue = row.Cells[19].Text;
        //txtpoltype.Text = row.Cells[19].Text.Replace("&nbsp;", "");
        //txtprsname.Text = row.Cells[20].Text.Replace("&nbsp;", "");

        txtcuscode.Text= row.Cells[29].Text.Replace("&nbsp;", "");
        DropDownListtitle.SelectedValue= row.Cells[20].Text.Replace("&nbsp;", "");
        TextBoxfname.Text= row.Cells[21].Text.Replace("&nbsp;", "");
        TextBoxlname.Text= row.Cells[22].Text.Replace("&nbsp;", "");
        TextBoxadd1.Text= row.Cells[23].Text.Replace("&nbsp;", "");
        TextBoxadd2.Text= row.Cells[24].Text.Replace("&nbsp;", "");
        TextBoxcity.Text= row.Cells[25].Text.Replace("&nbsp;", "");
        TextBoxlandno.Text= row.Cells[26].Text.Replace("&nbsp;", "");
        TextBoxmobileno.Text= row.Cells[27].Text.Replace("&nbsp;", "");
        lblcity.Text= row.Cells[25].Text.Replace("&nbsp;", "");


        //if (row.Cells[15].Text=="Y")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), this.ID, "$('#Label18, #txtpolicyno').show();", true);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), this.ID, "$('#Label9, #txtfollowup,#Label15, #txtrenewaldate').css('display', 'none');", true);
        //}
        //else if (row.Cells[15].Text == "N")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), this.ID, "$('#Label18, #txtpolicyno').css('display', 'none');", true);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), this.ID, "$('#Label9, #txtfollowup,#Label15, #txtrenewaldate').show();", true);
        //}
        //else if (row.Cells[15].Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), this.ID, "$('#Label9, #txtfollowup,#Label18, #txtpolicyno').css('display', 'none');", true);
        //}

        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
       // ClientScript.RegisterClientScriptBlock(this.GetType(), "blah", "showhide();", true);

    }

    public string checkgridnullval(string checkval)
    {
        if (checkval.Trim() == "")
        {

        }
        //if (checkval.Trim() == "" && type == "text")
        //{

        //}
        //else if (checkval.Trim() == "" && type == "date")
        //{

        //}
        return checkval;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        updatedata();
        //Your Saving code.
    }



    public void updatedata()
    {
        string todaydate = DateTime.Today.ToString("dd/MMM/yyyy");
        string renewal_date = null;
        string fallowup_date = null;
        string closedate = Convert.ToDateTime(txtclosedate.Text).ToString("dd/MMM/yyyy").ToString(); ; 


        if (txtrenewaldate.Text != "")
        {
            renewal_date = Convert.ToDateTime(txtrenewaldate.Text).ToString("dd/MMM/yyyy").ToString();
            //Convert.ToDateTime(txtrenewaldate.Text).ToString("dd-MMM-yyy").ToString();
            //DateTime.Parse(txtrenewaldate.Text);// Convert.ToDateTime(txtrenewaldate.Text).ToString("dd/MMM/yyyy").ToString();
            //fromdate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").ToString();
        }

        else
        {

        }

        if (txtfollowup.Text != "")
        {
            fallowup_date = Convert.ToDateTime(txtfollowup.Text).ToString("dd/MMM/yyyy").ToString();
        }

        else
        {
        }

        string add1 = TextBoxadd1.Text.ToUpper();
        add1 = TextBoxadd1.Text.Replace("'", "''");
        string add2 = TextBoxadd2.Text.ToUpper();
        add2 = TextBoxadd2.Text.Replace("'", "''");


        try
        {
            OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
            cmd = new OracleCommand();
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.Clear();
            cmd.CommandText = "PK_SM_T_ME_VISITS.PU_UPD_VISIT_INFO";
            cmd.Parameters.Add("wkmev_seq_no", OracleType.VarChar, 20).Value = txtmevseq.Text;
            cmd.Parameters.Add("wkmev_visit_date", OracleType.DateTime).Value = Convert.ToDateTime(txtvistdate.Text);
            cmd.Parameters.Add("wkmev_bus_occupation", OracleType.VarChar, 50).Value = txtoccupation.Text;
            cmd.Parameters.Add("wkmev_pol_type", OracleType.VarChar, 5).Value = DropDownListpoltype.SelectedValue;
            cmd.Parameters.Add("wkmev_cur_insurer", OracleType.VarChar, 15).Value = DropDownListinsurer.SelectedValue;
            cmd.Parameters.Add("wkmev_cur_sum_insured", OracleType.Number, 17).Value = txtsum.Text;
            cmd.Parameters.Add("wkmev_cur_premium", OracleType.Number, 17).Value = txtpremium.Text;           
            cmd.Parameters.Add("wkmev_vehi_no", OracleType.VarChar, 10).Value = txtriskname.Text;
            cmd.Parameters.Add("wkmev_remarks", OracleType.VarChar, 100).Value = txtremarks.Text;
            cmd.Parameters.Add("wkmev_busi_closed", OracleType.VarChar, 2).Value = DropDownListbusinesscl.SelectedValue;
            if (HiddenField1.Value=="NOTCHANGE")
            {
                cmd.Parameters.Add("wkmev_busi_closed_date", OracleType.DateTime).Value = Convert.ToDateTime(closedate);
            }          
            else
            {
                cmd.Parameters.Add("wkmev_busi_closed_date", OracleType.DateTime).Value = Convert.ToDateTime(todaydate);
            }
            cmd.Parameters.Add("wkmev_renewal_date", OracleType.DateTime).Value = Convert.ToDateTime(renewal_date);
            cmd.Parameters.Add("wkmev_folloup_date", OracleType.DateTime).Value = Convert.ToDateTime(fallowup_date);
            cmd.Parameters.Add("wkmev_policy_no", OracleType.VarChar, 20).Value = txtpolicyno.Text;
            //Convert.ToDateTime(TextBoxredate.Text).ToString("dd/MMM/yyyy").ToString();
            checkvisit = cmd.ExecuteNonQuery();

            cmd.Dispose();


            cmd.Parameters.Clear();
            cmd.CommandText = "PK_SM_T_ME_VISITS.PU_UPD_CUST_INFO";
            cmd.Parameters.Add("wkmec_cus_code", OracleType.VarChar, 20).Value = txtcuscode.Text;
            cmd.Parameters.Add("wkmec_cus_title", OracleType.VarChar, 5).Value = DropDownListtitle.Text;
            cmd.Parameters.Add("wkmec_cus_first_name", OracleType.VarChar, 100).Value = TextBoxfname.Text;
            cmd.Parameters.Add("wkmec_cus_last_name", OracleType.VarChar, 100).Value = TextBoxlname.Text;
            cmd.Parameters.Add("wkmec_cus_adr_no", OracleType.VarChar, 100).Value = TextBoxadd1.Text;
            cmd.Parameters.Add("wkmec_cus_adr_str", OracleType.VarChar, 100).Value = TextBoxadd2.Text;
            cmd.Parameters.Add("wkmec_cus_adr_city", OracleType.VarChar, 100).Value = TextBoxcity.Text;
            cmd.Parameters.Add("wkmec_cus_tel", OracleType.VarChar, 15).Value = TextBoxlandno.Text;
            cmd.Parameters.Add("wkmec_cus_mob", OracleType.VarChar, 15).Value = TextBoxmobileno.Text.Replace(" ","").Replace("(","").Replace(")","");

            checkcus = cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

        if (checkvisit==1 &&checkcus==1)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Updated');", true);
        }
    }

    protected void getpoltype()
    {
        DropDownListpoltype.Items.Clear();
        DropDownListpoltype.Items.Add(new ListItem("----- Select Type -----", ""));
        string query = " select prd_code ||' - '|| prd_description,prd_code  from uw_m_products where prd_cla_code NOT IN ('M3', 'M4', 'M2')  " +
                       " order by  PRD_CODE, prd_description";

        Common.FillLOV(DropDownListpoltype, query);

    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ReportMenu.aspx");
    }

    protected void getPresentInsure()
    {
        DropDownListinsurer.Items.Clear();
        DropDownListinsurer.Items.Add(new ListItem("Select insure", ""));
        string query = "SELECT  rft_description ,rft_code FROM cm_r_reference_two WHERE rft_type = 'PI' ";
        Common.FillLOV(DropDownListinsurer, query);

    }

    protected void getbusiclosed()
    {
        DropDownListbusinesscl.Items.Clear();
        DropDownListbusinesscl.Items.Add(new ListItem("Select Item", ""));
        string query = "SELECT  'Yes' ,'Y' FROM dual union all select 'No','N' from dual";
        Common.FillLOV(DropDownListbusinesscl, query);

    }

    protected void gettitle()
    {
        DropDownListtitle.Items.Clear();
        DropDownListtitle.Items.Add(new ListItem("----- Select Title -----", ""));
        string query = " SELECT tit_title_desc,tit_title_code FROM sm_r_title " +
                       " WHERE tit_title_code IN ('MR.', 'MRS', 'MISS.', 'DR', 'REV', 'CAPT', 'HON', 'MS.', 'PROF', 'Dr' ) ";
        Common.FillLOV(DropDownListtitle, query);

    }

    //protected void DropDownListbusinesscl_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //if (DropDownListbusinesscl.SelectedValue == "Y")
    //{
    //    Label18.Visible = true;
    //    txtpolicyno.Visible = true;
    //    Label9.Visible = false;
    //    txtfollowup.Visible = false;
    //    Label15.Visible = false;
    //    txtrenewaldate.Visible = false;
    //}
    //else if (DropDownListbusinesscl.SelectedValue == "N")
    //{
    //    Label18.Visible = false;
    //    txtpolicyno.Visible = false;
    //    Label9.Visible = true;
    //    txtfollowup.Visible = true;
    //    Label15.Visible = true;
    //    txtrenewaldate.Visible = true;
    //}
    //else if (DropDownListbusinesscl.SelectedValue == "")
    //{
    //    Label18.Visible = false;
    //    txtpolicyno.Visible = false;
    //    Label9.Visible = false;
    //    txtfollowup.Visible = false;
    //}
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        //HiddenField1.Value = "TEST";
        //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('"+ HiddenField1.Value+"');", true);


    }
}