using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class policywisecusdetails : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;


    protected void Page_Load(object sender, EventArgs e)
    {
        TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
        TextBoxmecode.Text = Session["sfc_code"].ToString();
    }

    protected void btncuspolicy_Click(object sender, EventArgs e)
    {
        getcuspoldetails();
    }

    public void getcuspoldetails()
    {
        string sqlquery = "select " +
                          "      pk_uw_r_classes.fn_get_class_desc(POL_CLA_CODE) CLASS " +
                          "      ,pk_uw_m_products.fn_get_prod_desc(POL_PRD_CODE) PRODUCT " +
                          "      ,pol_policy_no POLICY_NO " +
                          "      , TO_CHAR(pol_period_from,'DD-MON-YYYY') PERIOD_FROM " +
                          "      ,TO_CHAR(pol_period_to, 'DD-MON-YYYY') PERIOD_TO " +
                          "      ,TRIM(TO_CHAR(pol_sum_insured, '999,999,999,999,999,999,999,999,999')) SUM_INSURED " +
                          "      ,TRIM(TO_CHAR(pol_premium, '999,999,999,999,999,999,999,999,999')) PREMIUM " +
                          "      ,pk_temp_ranga.fn_get_vehi_no(POL_POLICY_NO) RISK_NAME " +
                          "      ,pk_uw_m_customers.fn_get_cust_title_and_name(POL_CUS_CODE) NAME " +
                          "      ,pk_uw_m_customers.fn_get_cust_phone(pol_cus_code) phone " +
                          "      ,pk_uw_m_customers.fn_get_cust_nic(pol_cus_code) cus_nic " +
                          "    ,    (select count(DISTINCT cen_claim_no) " +
                          "         from ac_t_central_claim @cicl c " +
                          "         where c.cen_policy_no = a.POL_policy_NO " +
                          "         AND TRUNC(cen_int_date_loss) BETWEEN   trunc(pol_period_from)  AND   trunc(pol_period_to) " +
                          "         and cen_cl_status <> 'C') NOS_INTIMATED_CLAIMS " +
                          "    ,    (select count(DISTINCT cen_claim_no) " +
                          "         from ac_t_central_claim @cicl c " +
                          "         where c.cen_policy_no = a.POL_policy_NO " +
                          "         AND TRUNC(cen_int_date_loss)BETWEEN   trunc(pol_period_from)  AND   trunc(pol_period_to) " +
                          "         and cen_cl_status = 'O') NOS_OUTSTANDING_CLAIMS " +
                          "   ,    (select count(DISTINCT cen_claim_no) " +
                          "         from ac_t_central_claim @cicl c , ac_t_central_requi @cicl r " +
                          "           where c.cen_seq_no = r.cre_cen_seq_no " +
                          "         and c.cen_policy_no = a.POL_policy_NO " +
                          "         AND TRUNC(cen_int_date_loss)BETWEEN   trunc(pol_period_from)  AND   trunc(pol_period_to) " +
                          "         AND cre_acc_paid_status = 'Y' " +
                          "         AND cre_acc_pay_voucher_no IS NOT NULL ) NOS_PAID_CLAIMS " +
                          "   ,    (select  NVL(SUM(cre_paid_amount), 0) " +
                          "         from ac_t_central_claim @cicl c , ac_t_central_requi @cicl r " +
                          "           where c.cen_seq_no = r.cre_cen_seq_no " +
                          "         and c.cen_policy_no = a.POL_policy_NO " +
                          "         AND TRUNC(cen_int_date_loss)BETWEEN   trunc(pol_period_from)  AND   trunc(pol_period_to) " +
                          "         AND cre_acc_paid_status = 'Y' " +
                          "         AND cre_acc_pay_voucher_no IS NOT NULL ) PAID_premium " +
                          "  from uw_t_policies a " +
                          "  where a.pol_marketing_executive_code = '"+TextBoxmecode.Text+"' " +
                          "  and a.pol_status NOT IN(8, 9) " +
                          "  and a.pol_policy_no is not null " +
                          "  and pk_uw_m_customers.fn_get_cust_nic(pol_cus_code) = '"+txtsearchNIC.Text.ToUpper().Trim()+"'";

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

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/techcenteremenu.aspx");
    }
}