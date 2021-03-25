using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class managercollectionreport : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;

    int a,cnt=0;
    double totsum = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            // String username;
            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            TextBoxmecode.Text = Session["sfc_code"].ToString();
            TextBoximei.Text = Session["imei"].ToString();

            //TextBoxbranch.Text = "AV00";// Session["sfc_brn_code"].ToString();
            //TextBoxmecode.Text = "51333";// Session["sfc_code"].ToString();
            //TextBoximei.Text = "204943";// Session["imei"].ToString();
            getbranch();
        }
    }

    
    /*protected void getRefundRation()
    {
        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_brn_deb_out";

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
    */


    public void getCollectiondetails()
    {

        string sqlquery = "select " +
                     "   TO_CHAR(TRN_DATE, 'DD-MON-YYYY') TRN_DATE " +
                     "   , nvl(round(sum(CASH), 2), 0) " +
                     "   + nvl(round(sum(CHEQUE), 2), 0) " +
                     "   + nvl(round(sum(SVAT_PAYMENT), 2), 0) " +
                     "   + nvl(round(sum(CREDIT_CARD), 2), 0) " +
                     "   + nvl(round(sum(LOYALTY_CARD), 2), 0) " +
                     "   + nvl(round(sum(DEBIT_CARD), 2), 0) " +
                     "   + nvl(round(sum(TRAVELLERS_CHEQUE), 2), 0) " +
                     "   + nvl(round(sum(NON_CASH_PAYMENT), 2), 0) " +
                     "   + nvl(round(sum(EZ_CASH), 2), 0) " +
                     "   + nvl(round(sum(COMMISSION_SET_OFF), 2), 0) " +
                     "   + nvl(round(sum(EFT), 2), 0) " +
                     "   + nvl(round(sum(SEYLAN_CASH), 2), 0)  TOTAL " +
                     "     from ( " +
                     "         select " +
                     "         t_type " +
                     "         , brn " +
                     "         , DECODE(code,'00001', SUM(amount) ) CASH " +
                     "       , DECODE(code, '00002', SUM(amount)) CREDIT_CARD " +
                     "       , DECODE(code, '00003', SUM(amount)) LOYALTY_CARD " +
                     "       , DECODE(code, '00004', SUM(amount)) DEBIT_CARD " +
                     "       , DECODE(code, '00006', SUM(amount)) CHEQUE " +
                     "       , DECODE(code, '00007', SUM(amount)) TRAVELLERS_CHEQUE " +
                     "       , DECODE(code, '00008', SUM(amount)) NON_CASH_PAYMENT " +
                     "       , DECODE(code, '00009', SUM(amount)) SVAT_PAYMENT " +
                     "       , DECODE(code, '00010', SUM(amount)) EZ_CASH " +
                     "       , DECODE(code, '00011', SUM(amount)) SEYLAN_CASH " +
                     "       , DECODE(code, '00012', SUM(amount)) COMMISSION_SET_OFF " +
                     "       , DECODE(code, '00014', SUM(amount)) EFT " +
                     "   ,TRN_DATE " +
                     "       from ( " +
                     "       SELECT " +
                     "       'Dir' t_type " +
                     "       , DRC_BRN_CODE brn " +
                     "       , pdt_pay_code code " +
                     "       , pdt_conv_amount amount " +
                     "       , TRUNC(DRC_TRN_DATE)  TRN_DATE " +
                     "        FROM rc_t_dir_receipt A, rc_t_payments B " +
                     "       WHERE A.drc_seq_no = B.pdt_drc_seq_no " +
                     "       AND TRUNC(DRC_TRN_DATE) BETWEEN '"+ Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString() + "' AND '" + Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString() + "' " +
                     "       and pdt_cash_book = 34600 " +
                     "       AND DRC_BRN_CODE = '"+ DropDownListbranch.SelectedValue + "' " +
                     "       AND DRC_STATUS = 'A' " +
                     "       union all " +
                     "       select " +
                     "       'Deb Set' t_type " +
                     "       , dst_brn_code brn " +
                     "       , pdt_pay_code code " +
                     "       , pdt_conv_amount amount " +
                     "       , trunc(a.dst_trn_date) " +
                     "       from rc_t_debit_settle a, rc_t_payments b " +
                     "       where a.dst_seq_no = b.pdt_dst_seq_no " +
                     "       and trunc(a.dst_trn_date) BETWEEN '" + Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString() + "' AND '" + Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString() + "' " +
                     "       and pdt_cash_book = 34600 " +
                     "       and a.dst_brn_code = '" + DropDownListbranch.SelectedValue + "' " +
                     "       AND a.dst_status = 'A' " +
                     "       union all " +
                     "    select " +
                     "       'Sun' t_type " +
                     "       , src_brn_code brn " +
                     "       , pdt_pay_code code " +
                     "       , pdt_conv_amount amount " +
                     "       , trunc(a.src_trn_date) " +
                     "        from rc_t_sundry_receipt a, rc_t_payments b " +
                     "       where a.src_seq_no = b.pdt_src_seq_no " +
                     "       and trunc(a.src_trn_date) BETWEEN '" + Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString() + "' AND '" + Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString() + "' " +
                     "       and pdt_cash_book = 34600 " +
                     "       and a.src_brn_code = '" + DropDownListbranch.SelectedValue + "' " +
                     "       AND A.src_status = 'A' " +
                     "       union all " +
                     "    select " +
                     "       'Ret' t_type " +
                     "       , rcs_brn_code brn " +
                     "       , pdt_pay_code code " +
                     "       , pdt_conv_amount amount " +
                     "       , trunc(a.rcs_trn_date) " +
                     "        from rc_t_ret_cheq_settle a, rc_t_payments b " +
                     "       where a.rcs_seq_no = b.pdt_rcs_seq_no " +
                     "       and trunc(a.rcs_trn_date) BETWEEN '" + Convert.ToDateTime(txtfromdate.Text).ToString("dd-MMM-yyy").ToString() + "' AND '" + Convert.ToDateTime(txttodate.Text).ToString("dd-MMM-yyy").ToString() + "' " +
                     "       and pdt_cash_book = 34600 " +
                     "       and a.rcs_brn_code = '" + DropDownListbranch.SelectedValue + "' " +
                     "       and a.rcs_status = 'A' " +
                     "       ) " +
                     "       group by  t_type, brn, code,TRN_DATE " +
                     "   ),Ac_m_brama ,ac_r_region " +
                     "   where  brn = Ac_m_brama.bra_branch_code " +
                     "   and Ac_m_brama.bra_to_date is null " +
                     "   and Ac_m_brama.bra_branch_repo_new = rgn_code " +
                     //"   --and bra_branch_code = WKREGCODE
                     "   group by  ROLLUP(TRN_DATE)";


        try
        {
            //conn = new OracleConnection(Connection.con_str_oracle_ceyt); 
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            cmd = new OracleCommand(sqlquery, con);
            // con = new OracleConnection(Connection.con_str_oracle_cicco);

            con.Open();//open connection 

            OracleDataAdapter adp = new OracleDataAdapter(sqlquery, con);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            grid1.DataSource = dt;
            grid1.DataBind();

            foreach (GridViewRow grow in grid1.Rows)
            {
                cnt = cnt + 1;
                grow.Cells[1].Text = Convert.ToDouble(grow.Cells[1].Text).ToString("N2");

                totsum = totsum + Convert.ToDouble(grow.Cells[1].Text);

                grow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
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
    }

    protected void btngetMe_Click(object sender, EventArgs e)
    {
        if (txtfromdate.Text != "" && txttodate.Text != "" && DropDownListbranch.SelectedIndex != 0)
        {
            //getRefundRation();
            getCollectiondetails();
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
