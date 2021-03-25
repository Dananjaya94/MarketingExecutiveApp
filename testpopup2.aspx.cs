using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testpopup2 : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;

    int a;

    protected void Page_Load(object sender, EventArgs e)
    {

        // String username;
        TextBoxbranch.Text = "YY00";//Session["sfc_brn_code"].ToString();//"YY00";//
        TextBoxmecode.Text = "08449";//Session["sfc_code"].ToString();//"08449";//


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

    //protected void Edit(object sender, EventArgs e)
    //{
    //    using (GridViewRow row = (GridViewRow)((Button)sender).Parent.Parent)
    //    {
    //        //row.ID = row.ID + 1;
    //        txtinsured.Text = row.Cells[4].Text;
    //        txtaddress.Text = row.Cells[1].Text;
    //        txtmobile.Text = row.Cells[2].Text;
    //        txtoccupation.Text = row.Cells[3].Text;
    //        //popup.Show();
    //        //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "$('#exampleModalLong').show();", true);
    //        //ClientScript.RegisterStartupScript(this.GetType(), "exampleModalLong", "ShowPopup('');", true);
    //        // ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
    //    }
    //}


    protected void Display(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex);
        GridViewRow row = grid1.Rows[rowIndex];

        txtinsured.Text = row.Cells[3].Text;//(row.FindControl("POLICY_NO") as Label).Text;
        txtaddress.Text = row.Cells[4].Text;//(row.FindControl("INSURED") as Label).Text; ;
        txtmobile.Text = row.Cells[2].Text;//(row.FindControl("MOBILE_NO") as Label).Text;
        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Your Saving code.
    }




    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ReportMenu.aspx");
    }
}