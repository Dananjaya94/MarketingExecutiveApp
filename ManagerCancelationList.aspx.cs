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
    int cnt = 0;
    double tot, settle, bal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            // String username;
            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            //TextBoxmecode.Text = Session["sfc_code"].ToString();
            //TextBoximei.Text = Session["imei"].ToString();
            getme();
            getRenewable();

        }

    }

    protected void getme()
    {
        DropDownListme.Items.Clear();
        DropDownListme.Items.Add(new ListItem("----- All MEs -----", "%"));
        string query = "select sfc_code||' - '||sfc_initials||' '||sfc_surname namee,sfc_code from sm_m_sales_force " +
                       "     where sfc_brn_code = '" + TextBoxbranch.Text + "' " +
                       "     AND sfc_active = 'Y' " +
                       " order by sfc_code ";
        Common.FillLOV(DropDownListme, query);

    }

    protected void btngetMe_Click(object sender, EventArgs e)
    {
        getRenewable();

    }

    protected void getRenewable()
    {
        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_BRN_auto_cancellation";

        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);
        prm1.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(prm1);

        OracleParameter prm2 = new OracleParameter("wkbrncode", OracleType.VarChar);
        prm2.Direction = ParameterDirection.Input;
        prm2.Value = TextBoxbranch.Text;
        cmd.Parameters.Add(prm2);

        OracleParameter prm3 = new OracleParameter("wkmecode", OracleType.VarChar);
        prm3.Direction = ParameterDirection.Input;
        prm3.Value = DropDownListme.SelectedValue;
        cmd.Parameters.Add(prm3);

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

            foreach (GridViewRow grow in grid1.Rows)
            {
                cnt = cnt + 1;
                grow.Cells[7].Text = Convert.ToDouble(grow.Cells[7].Text).ToString("N2");
                grow.Cells[8].Text = Convert.ToDouble(grow.Cells[8].Text).ToString("N2");
                grow.Cells[10].Text = Convert.ToDouble(grow.Cells[10].Text).ToString("N2");

                tot = tot + Convert.ToDouble(grow.Cells[7].Text);
                settle = settle + Convert.ToDouble(grow.Cells[8].Text);
                bal = bal + Convert.ToDouble(grow.Cells[10].Text);

                grow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
            }

            grid1.FooterRow.Cells[0].Text = cnt.ToString();
            grid1.FooterRow.Cells[0].Font.Bold = true;
            grid1.FooterRow.Cells[6].Text = "Total";
            grid1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[6].Font.Bold = true;
            grid1.FooterRow.Cells[7].Text = tot.ToString("N2");
            grid1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[7].Font.Bold = true;
            grid1.FooterRow.Cells[8].Text = settle.ToString("N2");
            grid1.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[8].Font.Bold = true;
            grid1.FooterRow.Cells[10].Text = bal.ToString("N2");
            grid1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[10].Font.Bold = true;

        }
        catch (Exception ex)
        {
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }

    }

    
    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    //protected void Buttonback_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/managermenu.aspx");
    //}

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/managermenu.aspx");
    }

}