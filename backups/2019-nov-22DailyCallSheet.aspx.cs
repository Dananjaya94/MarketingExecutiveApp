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


        string sqlquery = "SELECT "+
                          "   mev_visit_date VISIT_DATE " +
                          "   , ROWNUM NO " +
                          "   , UPPER(mec_cus_title || '.' || mec_cus_first_name) INSURED " +
                          "   , UPPER(mec_cus_adr_no || ' ' || mec_cus_adr_str || ' ' || mec_cus_adr_CITY)   ADDRESS " +
                          "   , pk_ri_r_main_occupation.fn_get_mainocc_des(mev_bus_occupation) OCCUPATION " +
                          "   , (SELECT rft_description FROM cm_r_reference_two WHERE  rft_type = 'PI'  AND rft_code = mev_cur_insurer ) PRESENT_INSURED " +
                          "   , mev_cur_sum_insured SUM_INSURED " +
                         "    , mev_cur_premium PREMIUM " +
                         "    , pk_uw_m_products.fn_get_prod_desc(mev_pol_type) PRODUCT " +
                          "   ,to_char( mev_renewal_date,'dd-Mon-yyyy') RENEWAL_DATE " +
                          "   ,to_char( mev_folloup_date,'dd-Mon-yyyy') FOLLOWUP_DATE " +
                          "   , UPPER(mev_vehi_no) VEHICLE_NO " +
                          "   , UPPER(mev_remarks) REMARKS " +
                          "   , mev_busi_closed " +
                          "   ,to_char( mev_busi_closed_date,'dd-Mon-yyyy') CLOSED_DATE  " +
                          "   , mev_policy_no " +
                          "   FROM SM_T_ME_CUSTOMERS A, SM_T_ME_VISITS B " +

                          "   WHERE mec_cus_code = mev_cus_code " +
                          "   AND mev_me_code = '"+TextBoxmecode.Text+"' " +
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







    protected void btngetMe_Click(object sender, EventArgs e)
    {
        getMeData();
    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}