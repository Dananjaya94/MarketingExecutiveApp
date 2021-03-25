using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.OracleClient;

/// <summary>
/// Summary description for service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class service : System.Web.Services.WebService
{

    public service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
 
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
   

    public string[] GetCity(string prefix)
    {

        List<string> cities = new List<string>();
        using (OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco))
        {

            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = "select cty_code, cty_desc from uw_r_city_det where " +
                "trim (cty_desc) like '" + prefix.ToUpper() + "%'";
                //cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        cities.Add(string.Format("{0}-{1}", sdr["cty_desc"], sdr["cty_code"]));
                    }
                }
                conn.Close();
            }
            return cities.ToArray();
        }
    }

    [WebMethod]

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetListofNames(string mec_cus_me ,string firstname)
    {

        List<string> names = new List<string>();
        using (OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco))
        {

            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = "SELECT mec_cus_title|| '.' || mec_cus_first_name || ' ' ||  mec_cus_mob || ' '|| mec_cus_adr_str FULLNAME,mec_cus_first_name,mec_cus_code,"+
                                  "  mec_cus_title,mec_cus_last_name,mec_cus_adr_no,mec_cus_adr_str,mec_cus_adr_city,mec_cus_tel, " +
                                 "   mec_cus_mob FROM SM_T_ME_CUSTOMERS WHERE  mec_cus_first_name like'"+ firstname.ToUpper().Trim() + "%' and mec_cus_me = '" + mec_cus_me + "'";

                //cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        names.Add(string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}", sdr["mec_cus_first_name"], sdr["FULLNAME"], sdr["mec_cus_code"], sdr["mec_cus_title"], 
                            sdr["mec_cus_last_name"], sdr["mec_cus_adr_no"], sdr["mec_cus_adr_str"], sdr["mec_cus_adr_city"], sdr["mec_cus_tel"], sdr["mec_cus_mob"]));
                    }
                }
                conn.Close();
            }
            return names.ToArray();
        }
    }

    [WebMethod]

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]


    public string[] GetleasingCompany(string leasingname)
    {

        List<string> leasingcompany = new List<string>();
        using (OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco))
        {

            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = "select fin_code,fin_name from sm_t_fin_intrest where" +
                " fin_name like '" + leasingname.ToUpper() + "%'";
                //cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        leasingcompany.Add(string.Format("{0}-{1}", sdr["fin_name"], sdr["fin_code"]));
                    }
                }
                conn.Close();
            }
            return leasingcompany.ToArray();
        }
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetOccupation(string occupation)
    {

        List<string> leasingcompany = new List<string>();
        using (OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco))
        {

            using (OracleCommand cmd = new OracleCommand())
            {
                //cmd.CommandText = "select fin_code,fin_name from sm_t_fin_intrest where" +
                //" fin_name like '" + occupation.ToUpper() + "%'";

                cmd.CommandText = "SELECT moc_main_occ_name, moc_main_occ_code FROM SM_T_OCCUPATIONS WHERE moc_main_occ_name like '" + occupation.ToUpper() + "%' and moc_print = 'Y'  ORDER BY moc_main_occ_code";


                //cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        leasingcompany.Add(string.Format("{0}-{1}", sdr["moc_main_occ_name"], sdr["moc_main_occ_code"]));
                    }
                }
                conn.Close();
            }
            return leasingcompany.ToArray();
        }
    }

}
