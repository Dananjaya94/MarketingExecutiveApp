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
        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;
        
        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.OPEN_ME_PROD_ACH";


        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);

        prm1.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(prm1);



        OracleParameter prm3 = new OracleParameter("WK_DATE", OracleType.VarChar);

        prm3.Direction = ParameterDirection.Input;

        prm3.Value = Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString();

        cmd.Parameters.Add(prm3);



        OracleParameter prm4 = new OracleParameter("WK_DATE1", OracleType.VarChar);

        prm4.Direction = ParameterDirection.Input;

        prm4.Value = Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString();

        cmd.Parameters.Add(prm4);





        OracleParameter prm6 = new OracleParameter("WKMECODE", OracleType.VarChar);

        prm6.Direction = ParameterDirection.Input;

        prm6.Value = TextBoxmecode.Text;

        cmd.Parameters.Add(prm6);


        OracleParameter prm5 = new OracleParameter("WKBRN", OracleType.VarChar);

        prm5.Direction = ParameterDirection.Input;

        prm5.Value = TextBoxbranch.Text.ToUpper();

        cmd.Parameters.Add(prm5);







        //cmd.CommandType = CommandType.StoredProcedure;


        //cmd.Parameters.Add("WK_DATE", OracleType.VarChar).Value = Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString();

        //cmd.Parameters.Add("WK_DATE1", OracleType.VarChar).Value = Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString();

        //cmd.Parameters.Add("WKMECODE", OracleType.VarChar).Value = TextBoxmecode.Text.ToString();

        //cmd.Parameters.Add("WKBRN", OracleType.VarChar).Value = TextBoxbranch.Text.ToString();


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
        }
        finally {
            conn.Close();
        }
       
    }







    protected void btngetMe_Click(object sender, EventArgs e)
    {
        getMeData();
    }



    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MeMenu.aspx");
    }
}