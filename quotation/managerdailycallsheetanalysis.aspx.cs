using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class managerdailycallsheetanalysis : System.Web.UI.Page
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
            //// String username;
            //TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            //TextBoxmecode.Text = Session["sfc_code"].ToString();
            //TextBoximei.Text = Session["imei"].ToString();

            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            //TextBoxmecode.Text = "51333";// Session["sfc_code"].ToString();
            //TextBoximei.Text = "204943";// Session["imei"].ToString();
            getFilter();
            getME();
        }
    }

    protected void getRefundRation()
    {
        string me;

        if (DropDownListME.SelectedIndex==0)
        {
            me = "%";
        }
        else
        {
            me = DropDownListME.SelectedValue;
        }

        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_dss_br_reports.OPEN_DGM_DAILY_CALL_SHEET";

        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);
        prm1.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(prm1);

        OracleParameter prm2 = new OracleParameter("WK_DATE", OracleType.VarChar);
        prm2.Direction = ParameterDirection.Input;
        prm2.Value = Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString();
        cmd.Parameters.Add(prm2);

        OracleParameter prm3 = new OracleParameter("WK_DATE1", OracleType.VarChar);
        prm3.Direction = ParameterDirection.Input;
        prm3.Value = Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString();
        cmd.Parameters.Add(prm3);

        OracleParameter prm4 = new OracleParameter("WKREGCODE", OracleType.VarChar);
        prm4.Direction = ParameterDirection.Input;
        prm4.Value = TextBoxbranch.Text;
        cmd.Parameters.Add(prm4);

        OracleParameter prm5 = new OracleParameter("WKFMTTYPE", OracleType.VarChar);
        prm5.Direction = ParameterDirection.Input;
        prm5.Value = DropDownListfilter.SelectedValue;
        cmd.Parameters.Add(prm5);

        OracleParameter prm6 = new OracleParameter("WK_IND_CODE", OracleType.VarChar);
        prm6.Direction = ParameterDirection.Input;
        prm6.Value = me;
        cmd.Parameters.Add(prm6);

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



    protected void btngetMe_Click(object sender, EventArgs e)
    {
        if (txtfromdate.Text != "" && txttodate.Text != "" && DropDownListfilter.SelectedIndex != 0)
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

    protected void getFilter()
    {
        DropDownListfilter.Items.Clear();
        DropDownListfilter.Items.Add(new ListItem("----- Select Filetr Type -----", ""));
        string query = " select 'Details' description,'A' val from dual " +
                       " union all " +
                       " select 'Call Sheet Summary' description,'S1' val from dual";
        Common.FillLOV(DropDownListfilter, query);
    }

    protected void getME()
    {
        DropDownListME.Items.Clear();
        DropDownListME.Items.Add(new ListItem("----- Select ME -----", ""));
        string query = " SELECT sfc_code || ' - ' || trim(PK_SM_M_SALES_FORCE.fn_get_name(sfc_code) || ' - ' || sfc_brn_code) ME,S.sfc_code " +
                       " FROM SM_M_SALES_FORCE S where  S.sfc_active = 'Y' AND S.sfc_commissionalble = 'Y' " +
                       " AND EXISTS (SELECT * FROM AC_M_BRAMA A WHERE A.bra_branch_code = '"+ TextBoxbranch.Text + "' AND A.bra_branch_code = SFC_BRN_CODE) " +
                       " order by 1";
        Common.FillLOV(DropDownListME, query);

        //try
        //{
        //    con = new OracleConnection(Connection.con_str_oracle);
        //    con.Open();//open connection

        //    cmd = new OracleCommand(query, con);
        //    DropDownListME.DataSource = cmd.ExecuteReader();
        //    DropDownListME.Items.Clear();
        //    DropDownListME.Items.Add(new ListItem("-- Select Title --"));
        //    //cmbtitle.Items[0].Enabled = false;
        //    DropDownListME.DataTextField = "tit_title_desc";
        //    DropDownListME.DataValueField = "tit_title_code";
        //    DropDownListME.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //    con.Close();
        //}

    }
}

