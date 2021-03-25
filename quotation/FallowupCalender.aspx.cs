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

            loadvisit();


        }




    }


    public void loadvisit()
    {


        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_me_followup_schedule";


        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);

        prm1.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(prm1);



        OracleParameter prm3 = new OracleParameter("wkmecode", OracleType.VarChar);

        prm3.Direction = ParameterDirection.Input;

        prm3.Value = TextBoxmecode.Text.ToString();

        cmd.Parameters.Add(prm3);






        try
        {
            conn.Open();
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();

            adp.Fill(dt);

            grid3.DataSource = dt;
            grid3.DataBind();

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







    protected void Buttonback_Click1(object sender, EventArgs e)
    {
        // Response.Redirect("~/ReportMenu.aspx");DaillyCallMenu
        Response.Redirect("~/ReportMenu.aspx");
    }
}