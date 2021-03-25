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
        TextBoxbranch.Text =  Session["sfc_brn_code"].ToString();
        //TextBoxmecode.Text = Session["sfc_code"].ToString();
        //TextBoximei.Text = Session["imei"].ToString();
      

    }

    protected void getBranchAchivement()
    {




        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_BRN_ach_summery";


        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);

        prm1.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(prm1);


        OracleParameter prm2 = new OracleParameter("wkbrn", OracleType.VarChar);

        prm2.Direction = ParameterDirection.Input;

        prm2.Value = TextBoxbranch.Text;

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

            //foreach (GridViewRow grow in grid1.Rows)
            //{
            //    grow.Cells[1].Text = Convert.ToInt32(grow.Cells[1].Text.Replace(",","")).ToString("N2");
            //    //grow.Cells[3].Text = Convert.ToInt32(grow.Cells[3].Text).ToString("N2");
            //    //grow.Cells[6].Text = Convert.ToInt32(grow.Cells[6].Text).ToString("N2");
            //    //grow.Cells[8].Text = Convert.ToInt32(grow.Cells[8].Text).ToString("N2");
            //    //grow.Cells[10].Text = Convert.ToInt32(grow.Cells[10].Text).ToString("N2");
            //    //grow.Cells[12].Text = Convert.ToInt32(grow.Cells[12].Text).ToString("N2");
            //}

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
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            getBranchAchivement();

        }
        else { }
    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/managermenu.aspx");
    }


   
}