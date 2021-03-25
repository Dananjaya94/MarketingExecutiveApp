using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class prospectregister : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;

    int a;

    protected void Page_Load(object sender, EventArgs e)
    {

        // String username;
        TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
        TextBoxmecode.Text = Session["sfc_code"].ToString();


    }

    protected void getMeData()
    {


        string from_date = Convert.ToDateTime(txtfromdate.Text).ToString("dd/MMM/yyyy").ToString();
        string to_date = Convert.ToDateTime(txttodate.Text).ToString("dd/MMM/yyyy").ToString();


        string sqlquery = "SELECT " +
                          "   to_char(mev_visit_date,'DD-MON-YYYY') ME_VISIT_DATE " +
                          "  , ROWNUM NO " +
                          "  , UPPER(mec_cus_title || '.' || mec_cus_first_name) INSURED " +
                          "  , UPPER(mec_cus_adr_no || ' ' || mec_cus_adr_str || ' ' || mec_cus_adr_CITY)   ADDRESS " +
                          "  , UPPER(mev_vehi_no) VEHICLE_NO " +
                          "  , TO_CHAR(mev_cur_sum_insured,'999,999,999,999.99') SUM_INSURED " +
                          "  , TO_CHAR(mev_cur_premium,'999,999,999,999.99') PREMIUM " +
                          "  , (SELECT rft_print_desc FROM cm_r_reference_two WHERE  rft_type = 'PI'  AND rft_code = mev_cur_insurer ) PRESENT_INSURED " +
                          "  , pk_ri_r_main_occupation.fn_get_mainocc_des(mev_bus_occupation) OCCUPATION " +
                          "  , mev_pol_type PRODUCT " +
                          "  , to_char(mev_renewal_date,'DD-MON-YYYY') RENEWAL_DATE " +
                          "  , to_char(mev_folloup_date,'DD-MON-YYYY') FOLLOWUP_DATE " +
                          "  , UPPER(mev_remarks) REMARKS " +
                          " , mev_busi_closed " +
                          "  , to_char(mev_busi_closed_date,'DD-MON-YYYY') BUSI_CLOSED_DATE " +
                          "  , mev_policy_no " +
                          "  FROM SM_T_ME_CUSTOMERS A, SM_T_ME_VISITS B " +
                          "  WHERE mec_cus_code = mev_cus_code " +
                          "  AND mev_cur_insurer <> 'NANA' " +
                          "  AND mev_me_code = '" + TextBoxmecode.Text + "' " + //:WK_ME-------- USER PARA
                          "  AND mev_visit_date BETWEEN  to_date('" + from_date + "','DD-MON-YYYY')  AND to_date('" + to_date + "','DD-MON-YYYY') "; //----PARA

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







    protected void btngetMe_Click(object sender, EventArgs e)
    {
        getMeData();
    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DaillyCallMenu.aspx");
    }
}