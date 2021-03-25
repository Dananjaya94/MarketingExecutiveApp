using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class techstatusreport : System.Web.UI.Page
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

        getMeData();
    }

    protected void getMeData()
    { 
        string sqll = "SELECT Trs_ref_no, " +
                      "  trs_policy_no, " +
                      "  (SELECT   trq_description " +
                      "                FROM   tec_r_request_types " +
                      "               WHERE   trq_code = trs_req_type) request_type,trs_user_comt, " +
                      "  pk_uw_m_products.fn_get_prod_desc(trs_prd_code) product, " +
                      "  trs_brn_code, " +
                      "  trs_me_code, " +
                      "  to_char(trs_req_date, 'DD-MON-YYYY HH24:MI:SS')request_date, " +
                      "             TO_CHAR(trs_tec_assgin_date, 'DD-MON-YYYY HH24:MI:SS') assigned_date, " +
                      "                                     TO_CHAR(trs_proc_start_date, 'DD-MON-YYYY HH24:MI:SS') process_start_date, " +
                      "             TO_CHAR(trs_user_compl_date, 'DD-MON-YYYY HH24:MI:SS') completed_date, " +
                      "  pk_sm_m_sales_force.fn_get_name(trs_tec_assgin_user) assigned_user, " +
                      "  NVL( " +
                      "           NVL( " +
                      "           pk_uw_m_customers.fn_get_cust_title_and_name(trs_cus_code), " +
                      "          (SELECT   MAX(TRIM(cus_indv_title || ' ' || cus_indv_initials || cus_indv_surname)) " +
                      "              FROM   tec_m_customers aa  WHERE   aa.cus_code = trs_cus_code)), " +
                      "                  trs_quot_customer) customer_name, " +
                      " (select rqs_description from tec_r_req_status where rqs_code = trs_status) status " +
                      "    FROM tec_t_requests " +
                      "    WHERE  trs_me_code = '"+ TextBoxmecode.Text + "' "+
                      " order by trs_req_date desc";


        try
        {
            //conn = new OracleConnection(Connection.con_str_oracle_ceyt); 
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            cmd = new OracleCommand(sqll, con);
            // con = new OracleConnection(Connection.con_str_oracle_cicco);

            con.Open();//open connection 

            OracleDataAdapter adp = new OracleDataAdapter(sqll, con);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            grid1.DataSource = dt;
            grid1.DataBind();
            //Panel2.Visible = true;
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


    protected void btngetMe_Click(object sender, EventArgs e)
    {
        getMeData();
    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("~/ReportMenu.aspx");
        Response.Redirect("~/techcenteremenu.aspx");

    }

    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            //Determine the RowIndex of the Row whose LinkButton was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = grid1.Rows[rowIndex];

            //Fetch value of Name.
            //string name = (row.FindControl("txtName") as TextBox).Text;

            //Fetch value of Country
            //string country = row.Cells[1].Text;

            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nCountry: " + country + "');", true);

            Response.Redirect("http://www.ceyins.lk/cuc_me/tasks_details_me.php?refno=" + row.Cells[0].Text + "");
        }
        else if (e.CommandName == "Document")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = grid1.Rows[rowIndex];

            //Response.Redirect("http://10.10.1.119/claim/view_uwnc_doc.php?polno=" + row.Cells[0].Text + "&refno=" + row.Cells[0].Text + "&branch="+ TextBoxbranch.Text + "&ncepfno="+ TextBoxmecode.Text + "");
            Response.Redirect("http://www.ceyins.lk/uw_nerve/view_uwnc_doc.php?polno=" + row.Cells[0].Text + "&refno=" + row.Cells[0].Text + "&branch=" + TextBoxbranch.Text + "&ncepfno=" + TextBoxmecode.Text + "");



        }
    }
}