using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class managers_prospect_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            TextBoxmecode.Text = Session["sfc_code"].ToString();
            TextBoximei.Text = Session["imei"].ToString();
        }
    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/managermenu.aspx");
    }

    [Obsolete]
    protected void LoadProspectDetails()
    {
        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "select pol_slc_brn_code, pol_marketing_executive_code, pk_uw_m_customers.pu_get_me_name(pol_marketing_executive_code) ME_NAME, pk_uw_m_customers.fn_get_cust_name(pol_cus_code)INSURED, (pol_period_to + 1) renewal_date, pol_prd_code, 'CURent INSURER' CURRENT_INSURER, (select moc_main_occ_name from sm_t_occupations where moc_main_occ_code = c.pop_moc_main_occ_code ) OCCUPATION, nvl((select mev_cur_premium from sm_t_me_visits where mev_cus_code = a.pol_cus_code ),0) CUR_PREMEIUM, pol_total_premium PREMIUM, a.pol_remarks REMARKS from uw_t_policies a,uw_t_pol_risks b, uw_t_pol_occupations c  where b.prs_plc_pol_seq_no = a.pol_seq_no and c.pop_prs_plc_pol_seq_no = a.pol_seq_no and c.pop_prs_plc_seq_no = b.prs_plc_seq_no and a.pol_status in('4', '5', '6'); ";
    }

    protected void btngetMe_Click(object sender, EventArgs e)
    {
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            //getmevisitsummary();

        }
        else { }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    [Obsolete]
    public static List<Object> populateprospectdetail()
    {

        //List<Prospect> Orc_data = new List<Prospect>();

        //try
        //{
        //    OracleConnection con = new OracleConnection(Connection.con_str_oracle_cicco);
        //    OracleCommand cmd = new OracleCommand();
        //    //cmd.CommandText = "select pol_slc_brn_code, pol_marketing_executive_code, pk_uw_m_customers.pu_get_me_name(pol_marketing_executive_code) ME_NAME, pk_uw_m_customers.fn_get_cust_name(pol_cus_code)INSURED, (pol_period_to + 1) renewal_date, pol_prd_code, 'CURent INSURER' CURRENT_INSURER, (select moc_main_occ_name from sm_t_occupations where moc_main_occ_code = c.pop_moc_main_occ_code ) OCCUPATION, nvl((select mev_cur_premium from sm_t_me_visits where mev_cus_code = a.pol_cus_code ),0) CUR_PREMEIUM, pol_total_premium PREMIUM, a.pol_remarks REMARKS from uw_t_policies a,uw_t_pol_risks b, uw_t_pol_occupations c  where b.prs_plc_pol_seq_no = a.pol_seq_no and c.pop_prs_plc_pol_seq_no = a.pol_seq_no and c.pop_prs_plc_seq_no = b.prs_plc_seq_no and a.pol_status in('4', '5', '6')";
        //    cmd.CommandText = "select bra_branch_code from ac_m_brama";
        //    cmd.Connection = con;

        //    con.Open();

        //    using (OracleDataReader sdr = cmd.ExecuteReader())
        //    {
        //        while (sdr.Read())
        //        {
        //            Prospect p = new Prospect();
        //            p.BranchCode = sdr[0].ToString();
        //            //p.ExcecutiveCode = sdr[1].ToString();
        //            //p.MeName = sdr[2].ToString();
        //            //p.Insurer = sdr[3].ToString();
        //            //p.ProductCode = sdr[4].ToString();
        //            //p.CurrentInsurer = sdr[5].ToString();
        //            //p.Occupation = sdr[6].ToString();
        //            //p.CurretnPremium = sdr[7].ToString();
        //            //p.Premium = sdr[8].ToString();
        //            //p.Remarks = sdr[9].ToString();



        //            Orc_data.Add(p);
        //        }
        //    }
        //    con.Close();
        //}
        //catch(Exception ex)
        //{
        //    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        //    Console.WriteLine(ex);
        //}
        //Thread.Sleep(5000);

        //return Orc_data;

        string sql = "select bra_branch_code from ac_m_brama";

        //List<Prospect> items = new List<Prospect>();
        List<Object> items = new List<Object>();

        OracleConnection con = new OracleConnection(Connection.con_str_oracle_cicco);
        try
        {
            OracleCommand cmd = new OracleCommand();
            con.Open();
            OracleCommand command = new OracleCommand(sql, con);
            OracleDataReader rd = command.ExecuteReader();

            while (rd.Read())
            {
                items.Add(rd[0].ToString());
                //items.Add(rd[1].ToString());
                //items.Add(rd[2].ToString());
                //items.Add(rd[3].ToString());
                //items.Add(rd[4].ToString());
                //items.Add(rd[5].ToString());
                //items.Add(rd[6].ToString());
                //items.Add(rd[7].ToString());
                //items.Add(rd[8].ToString());
                //items.Add(rd[9].ToString());
                //    items.Add(new Prospect
                //    {
                //        BranchCode = rd[0].ToString(),
                //        //ExcecutiveCode = rd[1].ToString(),
                //        //MeName = rd[2].ToString(),
                //        //Insurer = rd[3].ToString(),
                //        //ProductCode = rd[4].ToString(),
                //        //CurrentInsurer = rd[5].ToString(),
                //        //Occupation = rd[6].ToString(),
                //        //CurretnPremium = rd[7].ToString(),
                //        //Premium = rd[8].ToString(),
                //        //Remarks = rd[9].ToString()
                //});

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            con.Dispose();
        }
        return items;

    }

    //
    //try
    //{
    //    conn.Open();
    //    OracleDataAdapter adp = new OracleDataAdapter(cmd);
    //    OracleDataReader rdr;
    //    rdr = cmd.ExecuteReader();



    //}
    //catch (Exception ex)
    //{
    //}
    //finally
    //{
    //    conn.Close();
    //}

    //JavaScriptSerializer TheSerializer = new JavaScriptSerializer()
    //var TheJson = null;
    ////// for this you need to add using System.Web.Script.Serialization;
    //return TheJson;




}