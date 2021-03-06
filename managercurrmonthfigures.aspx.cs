using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managercurrmonthfigures : System.Web.UI.Page
{

    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;

    int a;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // String username;
            //TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            //TextBoxmecode.Text = Session["sfc_code"].ToString();
            //TextBoximei.Text = Session["imei"].ToString();

            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
                                        //TextBoxmecode.Text = "51333";// Session["sfc_code"].ToString();
                                        //TextBoximei.Text = "204943";// Session["imei"].ToString();
                                        //getbranch();
            getcurrfigures();

        }
    }


    protected void getcurrfigures()
    {
        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_dss_br_reports.OPEN_BRN_ONL_MK_FIG_FORAPP";

        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);
        prm1.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(prm1);

        OracleParameter prm2 = new OracleParameter("WKREGCODE", OracleType.VarChar);
        prm2.Direction = ParameterDirection.Input;
        prm2.Value = TextBoxbranch.Text;
        cmd.Parameters.Add(prm2);


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
                grow.Cells[2].Text = Convert.ToDouble(grow.Cells[2].Text.Replace("&nbsp;", "0")).ToString("N2");
                grow.Cells[3].Text = Convert.ToDouble(grow.Cells[3].Text.Replace("&nbsp;", "0")).ToString("N2");
                grow.Cells[4].Text = Convert.ToDouble(grow.Cells[4].Text.Replace("&nbsp;", "0")).ToString("N2");
                grow.Cells[5].Text = Convert.ToDouble(grow.Cells[5].Text.Replace("&nbsp;", "0")).ToString("N2");
                grow.Cells[6].Text = Convert.ToDouble(grow.Cells[6].Text.Replace("&nbsp;", "0")).ToString("N2");
                grow.Cells[7].Text = Convert.ToDouble(grow.Cells[7].Text.Replace("&nbsp;", "0")).ToString("N2");
                grow.Cells[8].Text = Convert.ToDouble(grow.Cells[8].Text.Replace("&nbsp;", "0")).ToString("N2");

                grow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }

    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/managermenu.aspx");
    }

    //protected void getbranch()
    //{
    //    DropDownListbranch.Items.Clear();
    //    DropDownListbranch.Items.Add(new ListItem("----- Select Branch -----", ""));
    //    string query = " select   pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code " +
    //                  "  from sm_t_branch_heads where mgr_imei = '" + TextBoximei.Text + "' " +
    //                  "  UNION all " +
    //                  "  select  pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code from sm_t_branch_heads where agm_imei = '" + TextBoximei.Text + "' " +
    //                  "  union all select  pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code from sm_t_branch_heads where dgm_imei = '" + TextBoximei.Text + "'";
    //    Common.FillLOV(DropDownListbranch, query);

    //}
}