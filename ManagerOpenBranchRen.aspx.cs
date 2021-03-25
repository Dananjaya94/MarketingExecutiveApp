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
    int checkinsert = 0;
    int cnt = 0;
    double totsum = 0;
    double totprim = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // String username;
            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            //TextBoxmecode.Text = "51333"; //Session["sfc_code"].ToString();
            //TextBoximei.Text = Session["imei"].ToString();
            //getToBeCancellation();
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

    protected void getToBeCancellation()
    {
        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;
        

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_brn_renewable";

        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);
        prm1.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(prm1);

        OracleParameter prm2 = new OracleParameter("wkbrncode", OracleType.VarChar);
        prm2.Direction = ParameterDirection.Input;
        prm2.Value = TextBoxbranch.Text;
        cmd.Parameters.Add(prm2);

        OracleParameter prm7 = new OracleParameter("wk_date", OracleType.VarChar);
        prm7.Direction = ParameterDirection.Input;
        prm7.Value = Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString();//txtfromdate.Text; //
        cmd.Parameters.Add(prm7);

        OracleParameter prm8 = new OracleParameter("wk_date1", OracleType.VarChar);
        prm8.Direction = ParameterDirection.Input;
        prm8.Value = Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString(); ;// txttodate.Text; //
        cmd.Parameters.Add(prm8);

        OracleParameter prm9 = new OracleParameter("wktyp", OracleType.VarChar);
        prm9.Direction = ParameterDirection.Input;
        prm9.Value = cmbcategory.SelectedValue;
        cmd.Parameters.Add(prm9);

        OracleParameter prm10 = new OracleParameter("wkmecode", OracleType.VarChar);
        prm10.Direction = ParameterDirection.Input;
        prm10.Value = DropDownListme.SelectedValue;
        cmd.Parameters.Add(prm10);

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
                grow.Cells[7].Text = Convert.ToDouble(grow.Cells[7].Text).ToString("N2");
                grow.Cells[8].Text = Convert.ToDouble(grow.Cells[8].Text).ToString("N2");

                totsum = totsum + Convert.ToDouble(grow.Cells[7].Text);
                totprim = totprim + Convert.ToDouble(grow.Cells[8].Text);

                grow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                grow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            }


            grid1.FooterRow.Cells[0].Text = cnt.ToString();
            grid1.FooterRow.Cells[0].Font.Bold = true;
            grid1.FooterRow.Cells[6].Text = "Total";
            grid1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[6].Font.Bold = true;
            grid1.FooterRow.Cells[7].Text = totsum.ToString("N2");
            grid1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[7].Font.Bold = true;
            grid1.FooterRow.Cells[8].Text = totprim.ToString("N2");
            grid1.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[8].Font.Bold = true;

            //conn.Open();
            //grid1.EmptyDataText = "No Records Found";
            //grid1.DataSource = cmd.ExecuteReader();
            //grid1.DataBind();
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




    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int check = 0;
        if (e.CommandName == "renew")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = grid1.Rows[rowIndex];

            string pol_no = row.Cells[3].Text;
            string name = row.Cells[9].Text;
            string email = "";
            string contact_no =  row.Cells[12].Text;

            try
            {
                con = new OracleConnection(Connection.con_str_oracle_cicco);
                cmd = new OracleCommand();
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;


                //EXEC PK_uw_t_ren_requests.PU_INS_REN_REQUESTS('YY00151A0000201', 'RANGANA', 'RABGA@CEI', '077720201', 'WEB')

                cmd.Parameters.Clear();
                cmd.CommandText = "PK_uw_t_ren_requests.PU_INS_REN_REQUESTS";
                cmd.Parameters.Add("wreq_policy_no", OracleType.VarChar, 20).Value = pol_no.ToUpper().Trim();
                cmd.Parameters.Add("wreq_name", OracleType.VarChar, 100).Value = name.ToUpper().Trim();
                cmd.Parameters.Add("wreq_email", OracleType.VarChar, 100).Value = email;
                cmd.Parameters.Add("wreq_contact_no", OracleType.VarChar, 40).Value = contact_no.Trim();
                cmd.Parameters.Add("wreq_req_type", OracleType.VarChar, 100).Value = "APP";

                checkinsert = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }

            if (checkinsert == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully sent the request');", true);
            }
        }

    }

    protected void btnview_Click(object sender, EventArgs e)
    {
        getToBeCancellation();
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("managermenu.aspx");
    }
}