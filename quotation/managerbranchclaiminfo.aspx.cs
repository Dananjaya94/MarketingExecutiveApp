using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class managerbranchclaiminfo : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;

    int a,cnt=0;
    double acr, paid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            // String username;
            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            TextBoxmecode.Text = Session["sfc_code"].ToString();
            TextBoximei.Text = Session["imei"].ToString();
            getbranch();
            getme();
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


    protected void getRefundRation()
    {
        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_brn_claim_info";

        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);
        prm1.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(prm1);

        OracleParameter prm2 = new OracleParameter("wkbrn", OracleType.VarChar);
        prm2.Direction = ParameterDirection.Input;
        prm2.Value = DropDownListbranch.SelectedValue;
        cmd.Parameters.Add(prm2);

        OracleParameter prm3 = new OracleParameter("wk_date", OracleType.VarChar);
        prm3.Direction = ParameterDirection.Input;
        prm3.Value = Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString();
        cmd.Parameters.Add(prm3);

        OracleParameter prm4 = new OracleParameter("wk_date1", OracleType.VarChar);
        prm4.Direction = ParameterDirection.Input;
        prm4.Value = Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString();
        cmd.Parameters.Add(prm4);

        OracleParameter prm5 = new OracleParameter("wkmecode", OracleType.VarChar);
        prm5.Direction = ParameterDirection.Input;
        prm5.Value = DropDownListme.SelectedValue;
        cmd.Parameters.Add(prm5);

        try
        {
            conn.Open();
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();

            adp.Fill(dt);

            grid1.DataSource = dt;
            grid1.DataBind();

            foreach (GridViewRow grow in grid1.Rows)
            {
                cnt = cnt + 1;
                grow.Cells[10].Text = Convert.ToDouble(grow.Cells[10].Text.Replace("&nbsp;","0")).ToString("N2");
                grow.Cells[11].Text = Convert.ToDouble(grow.Cells[11].Text.Replace("&nbsp;", "0")).ToString("N2");

                acr = acr + Convert.ToDouble(grow.Cells[10].Text);
                paid = paid + Convert.ToDouble(grow.Cells[11].Text);

                grow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[11].HorizontalAlign = HorizontalAlign.Right;
            }


            grid1.FooterRow.Cells[0].Text = cnt.ToString();
            grid1.FooterRow.Cells[0].Font.Bold = true;
            grid1.FooterRow.Cells[9].Text = "Total";
            grid1.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[9].Font.Bold = true;
            grid1.FooterRow.Cells[10].Text = acr.ToString("N2");
            grid1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[10].Font.Bold = true;
            grid1.FooterRow.Cells[11].Text = paid.ToString("N2");
            grid1.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[11].Font.Bold = true;

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
        if (txtfromdate.Text != "" && txttodate.Text != "" && DropDownListbranch.SelectedIndex != 0)
        {
            getRefundRation();

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

    protected void getbranch()
    {
        DropDownListbranch.Items.Clear();
        DropDownListbranch.Items.Add(new ListItem("----- Select Branch -----", ""));
        string query = " select   pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code " +
                      "  from sm_t_branch_heads where mgr_imei = '" + TextBoximei.Text + "' " +
                      "  UNION all " +
                      "  select  pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code from sm_t_branch_heads where agm_imei = '" + TextBoximei.Text + "' " +
                      "  union all select  pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code from sm_t_branch_heads where dgm_imei = '" + TextBoximei.Text + "'";
        Common.FillLOV(DropDownListbranch, query);

    }
}