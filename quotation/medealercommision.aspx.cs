using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class medealercommision : System.Web.UI.Page
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
            TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
            TextBoxmecode.Text = Session["sfc_code"].ToString();
            TextBoximei.Text = Session["imei"].ToString();
            //getbranch();
            //getme();
        }
    }

    protected void getmevisitdetails()
    {

        int cnt = 0;
        double totsum = 0;
        double totprim = 0;

        string sql = "SELECT * FROM " +
                     "   ( " +
                     "   SELECT POL_SLC_BRN_CODE BRANCH_CODE, POL_PRD_CODE PRODUCT_CODE, POL_POLICY_NO POLICY_NO" +
                     "   , NAME " +
                     "   , TO_CHAR(MARKETING_DATE, 'DD-MON-YYYY') MARKETING_DATE " +
                     "   , REF_NO " +
                     "   , POL_TYPE " +
                     "   , DECODE(POL_TYPE, 'N', CP + RS + TC, 0) PREMIUM_NEW " +
                     "   , CASE WHEN POL_TYPE = 'F' AND POL_ANY_HISTORY = 'N' AND POL_STATUS = 9 and POL_SUM_INSURED = 0  THEN CP + RS + TC ELSE 0 END  REFUNDS_NEW " +
                     "   , DECODE(POL_TYPE, 'N', 1, 0) NOS_NEW " +
                     "   , CASE WHEN POL_TYPE = 'F' AND POL_STATUS = 9 and POL_SUM_INSURED = 0  AND POL_ANY_HISTORY = 'N' THEN - 1 ELSE 0 END  REFUNDS_NOS_NEW " +
                     "   , (SELECT UW_R_VEH_TYPE_DEF.veh_type_alias FROM UW_R_VEH_TYPE_DEF WHERE UW_R_VEH_TYPE_DEF.veh_type_name IN " +
                     "   (NVL( " +
                     "   (SELECT MV_UW_VTYPE_INFO.pol_prs_type_desc FROM MV_UW_VTYPE_INFO WHERE MV_UW_VTYPE_INFO.pol_policy_no = MV.pol_policy_no) " +
                     "   , (SELECT  pol_prs_type_desc FROM UW_R_VEHICLE_TYPE_DEFAULT D WHERE D.pol_prd_code = MV.pol_prd_code) " +
                     "   ))) VEHICLE_TYPE " +
                     "    ,NVL((SELECT MAX('Y') FROM AC_T_CREDITOR AC, AC_M_CREDITOR AM WHERE " +
                     "   AC.crt_profit_center = AM.cre_profit_center " +
                     "   AND AC.crt_cred_code = AM.cre_cred_code " +
                     "   AND NVL(AM.cre_type_uw, AM.cre_type) = '5' " +
                     "   AND MV.pol_policy_no = AC.crt_policy_no " +
                     "   AND MV.ref_no = AC.crt_ref_2 " +
                     "   ),'N') LEASED " +
                     "    ,MV.pol_marketing_executive_code || ' - ' || PK_SM_M_SALES_FORCE.fn_get_name(pol_marketing_executive_code) ME_INFO " +
                     "   FROM MV_UW_POL_NEW MV, AC_M_BRAMA AM,AC_R_REGION AR " +
                     "   WHERE REF_NO IS NOT NULL " +
                     "   AND MV.POL_SLC_BRN_CODE = AM.bra_branch_code " +
                     "   AND AM.bra_to_date IS NULL " +
                     "   AND AM.bra_branch_repo_new = AR.rgn_code " +
                     "   and POL_prd_code not in ('1M','1F','1X','1W','1P','1Q') " +
                     "   AND POL_CLA_CODE = 'MC' " +
                     "   AND POL_TYPE IN('N', 'F') " +
                     "   AND POL_MARKETING_EXECUTIVE_CODE = '"+ TextBoxmecode.Text + "' " +
                     "   AND EXISTS (SELECT /*+ INDEX(CM_P_ORG_PARAMS OPM_PK) */ * FROM CM_P_ORG_PARAMS WHERE OPM_DESCRIPTION = 'ACTIVE' AND OPM_NUMBER_VALUE = 1 " +
                     "   AND OPM_BRANCH = POL_SLC_BRN_CODE) " +
                     "   AND MARKETING_DATE BETWEEN TO_DATE('"+ txtfromdate.Text + "', 'MM/DD/YYYY') AND TO_DATE('"+txttodate.Text+"', 'MM/DD/YYYY') " +
                     "   ) " +
                     "   WHERE VEHICLE_TYPE = 'CAR' AND LEASED = 'N' " +
                     "   UNION " +
                     "   /*NON CARS*/ " +
                     "   SELECT* FROM " +
                     "   ( " +
                     "   SELECT POL_SLC_BRN_CODE BRANCH_CODE, POL_PRD_CODE PRODUCT_CODE, POL_POLICY_NO POLICY_NO" +
                     "   , NAME " +
                     "   , TO_CHAR(MARKETING_DATE,'DD-MON-YYYY') MARKETING_DATE " +
                     "   ,REF_NO " +
                     "   ,POL_TYPE " +
                     "   ,DECODE(POL_TYPE, 'N', CP + RS + TC, 0) PREMIUM_NEW " +
                     "   ,CASE WHEN POL_TYPE = 'F' AND POL_ANY_HISTORY = 'N' AND POL_STATUS = 9 and POL_SUM_INSURED = 0  THEN CP+RS + TC ELSE 0 END REFUNDS_NEW " +
                     "   ,DECODE(POL_TYPE, 'N', 1, 0) NOS_NEW " +
                     "   ,CASE WHEN POL_TYPE = 'F' AND POL_STATUS = 9 and POL_SUM_INSURED = 0  AND POL_ANY_HISTORY = 'N' THEN - 1 ELSE 0 END REFUNDS_NOS_NEW " +
                     "   ,(SELECT UW_R_VEH_TYPE_DEF.veh_type_alias FROM UW_R_VEH_TYPE_DEF WHERE UW_R_VEH_TYPE_DEF.veh_type_name IN " +
                     "   (NVL( " +
                     "   (SELECT MV_UW_VTYPE_INFO.pol_prs_type_desc FROM MV_UW_VTYPE_INFO WHERE MV_UW_VTYPE_INFO.pol_policy_no = MV.pol_policy_no) " +
                     "   , (SELECT  pol_prs_type_desc FROM UW_R_VEHICLE_TYPE_DEFAULT D WHERE D.pol_prd_code = MV.pol_prd_code) " +
                     "   ))) VEHICLE_TYPE " +
                     "   ,NVL((SELECT MAX('Y') FROM AC_T_CREDITOR AC, AC_M_CREDITOR AM WHERE " +
                     "   AC.crt_profit_center = AM.cre_profit_center " +
                     "   AND AC.crt_cred_code = AM.cre_cred_code " +
                     "   AND NVL(AM.cre_type_uw, AM.cre_type) = '5' " +
                     "   AND MV.pol_policy_no = AC.crt_policy_no " +
                     "   AND MV.ref_no = AC.crt_ref_2 " +
                     "   ),'N') LEASED " +
                     "   ,MV.pol_marketing_executive_code || ' - ' || PK_SM_M_SALES_FORCE.fn_get_name(pol_marketing_executive_code) ME_INFO " +
                     "   FROM MV_UW_POL_NEW MV, AC_M_BRAMA AM,AC_R_REGION AR " +
                     "   WHERE " +
                     "   REF_NO IS NOT NULL " +
                     "   AND MV.POL_SLC_BRN_CODE = AM.bra_branch_code " +
                     "   AND AM.bra_to_date IS NULL " +
                     "   AND AM.bra_branch_repo_new = AR.rgn_code " +
                     "   and POL_prd_code not in ('1M','1F','1X','1W','1P','1Q') " +
                     "   AND POL_CLA_CODE = 'MC' " +
                     "   AND POL_MARKETING_EXECUTIVE_CODE = '" + TextBoxmecode.Text + "' " +
                     "   AND POL_TYPE IN('N', 'F') " +
                     "   AND EXISTS (SELECT /*+ INDEX(CM_P_ORG_PARAMS OPM_PK) */ * FROM CM_P_ORG_PARAMS WHERE OPM_DESCRIPTION = 'ACTIVE' AND OPM_NUMBER_VALUE = 1 AND OPM_BRANCH = POL_SLC_BRN_CODE)  " +
                     "   AND MARKETING_DATE " +
                     "   BETWEEN TO_DATE('"+ txtfromdate.Text + "', 'MM/DD/YYYY') AND TO_DATE('"+ txttodate.Text + "', 'MM/DD/YYYY')) " +
                     "   WHERE VEHICLE_TYPE!= 'CAR'";



        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);

            OracleDataAdapter adp = new OracleDataAdapter(sql, con);
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
            //    cnt = cnt + 1;
            //    grow.Cells[10].Text = Convert.ToDouble(grow.Cells[10].Text).ToString("N2");
            //    grow.Cells[11].Text = Convert.ToDouble(grow.Cells[11].Text).ToString("N2");

            //    totsum = totsum + Convert.ToDouble(grow.Cells[10].Text);
            //    totprim = totprim + Convert.ToDouble(grow.Cells[11].Text);

            //    grow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
            //    grow.Cells[11].HorizontalAlign = HorizontalAlign.Right;
            //}

            //grid1.FooterRow.Cells[0].Text = cnt.ToString();
            //grid1.FooterRow.Cells[0].Font.Bold = true;
            //grid1.FooterRow.Cells[9].Text = "Total";
            //grid1.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
            //grid1.FooterRow.Cells[9].Font.Bold = true;
            //grid1.FooterRow.Cells[10].Text = totsum.ToString("N2");
            //grid1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
            //grid1.FooterRow.Cells[10].Font.Bold = true;
            //grid1.FooterRow.Cells[11].Text = totprim.ToString("N2");
            //grid1.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Right;
            //grid1.FooterRow.Cells[11].Font.Bold = true;

        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }

    }







    protected void btngetMe_Click(object sender, EventArgs e)
    {
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            getmevisitdetails();

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
    //protected void getbranch()
    //{
    //    DropDownListbranch.Items.Clear();
    //    //DropDownListbranch.Items.Add(new ListItem("----- Select Branch -----", ""));
    //    string query = " select   pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code " +
    //                  "  from sm_t_branch_heads where mgr_imei = '" + TextBoximei.Text + "' " +
    //                  "  UNION all " +
    //                  "  select  pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code from sm_t_branch_heads where agm_imei = '" + TextBoximei.Text + "' " +
    //                  "  union all select  pk_ac_m_brama.get_brn_description(bra_branch_code) branch_des,bra_branch_code from sm_t_branch_heads where dgm_imei = '" + TextBoximei.Text + "'";
    //    Common.FillLOV(DropDownListbranch, query);

    //}

    //protected void getme()
    //{
    //    DropDownListme.Items.Clear();
    //    DropDownListme.Items.Add(new ListItem("----- All MEs -----", "%"));
    //    string query = "select sfc_code||' - '||sfc_initials||' '||sfc_surname namee,sfc_code from sm_m_sales_force " +
    //                   "     where sfc_brn_code = '" + TextBoxbranch.Text + "' " +
    //                   "     AND sfc_active = 'Y' " +
    //                   " order by sfc_code ";
    //    Common.FillLOV(DropDownListme, query);

    //}
}