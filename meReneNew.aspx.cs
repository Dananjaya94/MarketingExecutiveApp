using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class meReneNew : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;
    int checkinsert;
    int a;
    string polseq;   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // String username;
            TextBoxbranch.Text = "AV00";//Session["sfc_brn_code"].ToString();//
            TextBoxmecode.Text = "08922"; //Session["sfc_code"].ToString();//
            //getMeData();
            getcusfeed();
        }
        //getMeData();
    }

    protected void getMeData()
    {

        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_eceyt);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_me_renewable_new";

        OracleParameter prm1 = new OracleParameter("io_cursor", OracleType.Cursor);
        prm1.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(prm1);

        OracleParameter prm6 = new OracleParameter("wkmecode", OracleType.VarChar);
        prm6.Direction = ParameterDirection.Input;
        prm6.Value = TextBoxmecode.Text;
        cmd.Parameters.Add(prm6);

        OracleParameter prm7 = new OracleParameter("wk_date", OracleType.VarChar);
        prm7.Direction = ParameterDirection.Input;
        prm7.Value = Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString();//txtfromdate.Text;
        cmd.Parameters.Add(prm7);

        OracleParameter prm8 = new OracleParameter("wk_date1", OracleType.VarChar);
        prm8.Direction = ParameterDirection.Input;
        prm8.Value = Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString(); ;// txttodate.Text;
        cmd.Parameters.Add(prm8);

        OracleParameter prm9 = new OracleParameter("wktyp", OracleType.VarChar);
        prm9.Direction = ParameterDirection.Input;
        prm9.Value = cmbcategory.SelectedValue;
        cmd.Parameters.Add(prm9);

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
        finally
        {
            conn.Close();
        }

    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

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
            string name = row.Cells[7].Text;
            string email = "";
            string contact_no = row.Cells[9].Text;


            Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequestpubrene.aspx?branch=" + Session["sfc_brn_code"].ToString() + "&sfc_code=" + Session["sfc_code"].ToString() + "&polno=" + pol_no + "");

            //Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequestpub.aspx?=");

            //////string pol_no = row.Cells[3].Text;
            //////string name = row.Cells[7].Text;
            //////string email = "";
            //////string contact_no = row.Cells[9].Text;

            //////try
            //////{
            //////    con = new OracleConnection(Connection.con_str_oracle_cicco);
            //////    cmd = new OracleCommand();
            //////    con.Open();
            //////    cmd.CommandType = CommandType.StoredProcedure;
            //////    cmd.Connection = con;


            //////    //EXEC PK_uw_t_ren_requests.PU_INS_REN_REQUESTS('YY00151A0000201', 'RANGANA', 'RABGA@CEI', '077720201', 'WEB')

            //////    cmd.Parameters.Clear();
            //////    cmd.CommandText = "PK_uw_t_ren_requests.PU_INS_REN_REQUESTS";
            //////    cmd.Parameters.Add("wreq_policy_no", OracleType.VarChar, 20).Value = pol_no.ToUpper().Trim();
            //////    cmd.Parameters.Add("wreq_name", OracleType.VarChar, 100).Value = name.ToUpper().Trim();
            //////    cmd.Parameters.Add("wreq_email", OracleType.VarChar, 100).Value = email;
            //////    cmd.Parameters.Add("wreq_contact_no", OracleType.VarChar, 40).Value = contact_no.Trim();
            //////    cmd.Parameters.Add("wreq_req_type", OracleType.VarChar, 100).Value = "APP";

            //////    checkinsert = cmd.ExecuteNonQuery();
            //////}
            //////catch (Exception ex)
            //////{

            //////    throw ex;
            //////}
            //////finally
            //////{
            //////    con.Close();
            //////}

            //////if (checkinsert == 1)
            //////{
            //////    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully sent the request');", true);
            //////}
        }
        //else if(e.CommandName == "whatsapp")
        //{

        //}
    }

    protected void btnview_Click(object sender, EventArgs e)
    {
        getMeData();
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("meMenu.aspx");
    }

    protected void Display(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex);
        GridViewRow row = grid1.Rows[rowIndex];

        txtpolicyno.Text = row.Cells[3].Text.Replace("&nbsp;", "");
        txtname.Text = row.Cells[7].Text.Replace("&nbsp;", "");
        txtcontact.Text = row.Cells[9].Text.Replace("&nbsp;", "");


        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        // ClientScript.RegisterClientScriptBlock(this.GetType(), "blah", "showhide();", true);

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        updatedata();
        //Your Saving code.
    }



    public void updatedata()
    {
        string todaydate = DateTime.Today.ToString("dd/MMM/yyyy");
        string date = null;

        if (txtdate.Text != "")
        {
            date = Convert.ToDateTime(txtdate.Text).ToString("dd/MMM/yyyy").ToString();
            //Convert.ToDateTime(txtrenewaldate.Text).ToString("dd-MMM-yyy").ToString();
            //DateTime.Parse(txtrenewaldate.Text);// Convert.ToDateTime(txtrenewaldate.Text).ToString("dd/MMM/yyyy").ToString();
            //fromdate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").ToString();
        }

        try
        {
            OracleConnection conn = new OracleConnection(Connection.con_str_oracle_eceyt);
            cmd = new OracleCommand();
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.Clear();
            cmd.CommandText = "PK_sm_t_me_visits.pu_update_renewal_visit";
            cmd.Parameters.Add("wkpolseq", OracleType.VarChar, 20).Value = getpolseq();
            cmd.Parameters.Add("wktype", OracleType.DateTime).Value = cmbcusfeed.SelectedValue;
            cmd.Parameters.Add("wkcomment", OracleType.VarChar, 50).Value = txtremarks.Text;
            cmd.Parameters.Add("wkdate", OracleType.DateTime).Value = Convert.ToDateTime(date);

            checkinsert = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

        if (checkinsert == 1)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Updated');", true);
        }
    }

    protected void getcusfeed()
    {
        cmbcusfeed.Items.Clear();
        cmbcusfeed.Items.Add(new ListItem("----- Select Feedback -----", ""));
        string query = " select lps_description,lps_code from uw_r_laps_reasons " +
                       " order by  lps_description";

        Common.FillLOV(cmbcusfeed, query);

    }

    public string getpolseq()
    {

        string sqlquot = "select pol_seq_no from uw_t_policies where pol_policy_no='' ";

        try
        {
            con = new OracleConnection(Connection.con_str_oracle);
            con.Open();

            cmd = new OracleCommand(sqlquot, con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                polseq = rd["pol_seq_no"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
        return polseq;
    }
}