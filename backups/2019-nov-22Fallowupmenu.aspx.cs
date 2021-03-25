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

            TextBoxbranch.Text =Session["sfc_brn_code"].ToString();
            TextBoxmecode.Text = Session["sfc_code"].ToString();


        }




    }


    public void loadvisit()
    {

        string from_date = Convert.ToDateTime(TextBoxfrom.Text).ToString("dd/MMM/yyyy").ToString();
        string to_date = Convert.ToDateTime(TextBoxTo.Text).ToString("dd/MMM/yyyy").ToString();

        string sqlquery = "SELECT  "+
                         "    mev_seq_no  " +
                         "   , UPPER(mec_cus_title || '.' || mec_cus_first_name) INSURED  " +
                         "   , mev_cur_sum_insured SUM_INSURED  " +
                         "   ,to_char( mev_cur_premium,'999,999,999,999.99') PREMIUM  " +
                         "   , mev_pol_type PRODUCT  " +
                         "   ,to_char( mev_renewal_date,'dd-Mon-yyyy') RENEWAL_DATE  " +
                         "   ,to_char( mev_folloup_date,'dd-Mon-yyyy') FOLLOWUP_DATE  " +
                         "   , UPPER(mev_vehi_no) VEHICLE_NO  " +
                         "  , UPPER(mev_remarks) REMARKS "+
                         ", mev_cur_insurer INSURE "+
                         "   , mec_cus_code CUS_CODE "+
                         "   , mev_bus_occupation OCCUPATION" +
                         "   FROM SM_T_ME_CUSTOMERS A, SM_T_ME_VISITS B  " +
                         "   WHERE mec_cus_code = mev_cus_code  " +
                         "   AND mev_me_code = '"+TextBoxmecode.Text+"'"+
                         "   AND TRUNC(mev_folloup_date)BETWEEN   TO_DATE('" + from_date + "') and TO_DATE('" + to_date + "')";
        //where clf_clf_status = 'Y' ORDER BY created_date) a ";
        //"  where a.ref_no = c.cl_main_ref_no "+
        //"  and trunc(c.created_date)between '"+from_date+"' and  '"+to_date+"'";

        try
        {

            //conn = new OracleConnection(Connection.con_str_oracle_ceyt); 
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            con.Open();//open connection 


            OracleDataAdapter adp = new OracleDataAdapter(sqlquery, con);

            dt = new DataTable();

            adp.Fill(dt);

            grid3.DataSource = dt;
            grid3.DataBind();

            grid3.Columns[0].Visible = false;


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



    protected void grid3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        grid3.Columns[0].Visible = true;
        int rowIndex = Convert.ToInt32(e.CommandArgument);
        OracleConnection oracon = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = oracon.CreateCommand();
        //Reference the GridView Row.
        GridViewRow row = grid3.Rows[rowIndex];

        string visit_seq = row.Cells[0].Text;
        //Session["comm"] = row.Cells[7].Text;
        

        if (e.CommandName == "visit")
        {
            string queryString1 = "FallowupDetails.aspx?visit_seq=" + visit_seq;
            Page.ClientScript.RegisterStartupScript(
this.GetType(), "OpenWindow", "window.open('" + queryString1 + "','_newtab');", true);

        }

        grid3.Columns[0].Visible = false;
    }

    protected void btnLoadEmp_Click(object sender, EventArgs e)
    {
        loadvisit();
    }
}