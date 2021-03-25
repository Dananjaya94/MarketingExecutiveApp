using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customerdocupload : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;
    OracleTransaction oratran;


    //public static string con_str_oracle_cicl = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
    //                        "(HOST=CICCO-SCAN)(PORT=1521)))(CONNECT_DATA=(SERVER=CICL)(SID=CICL2))); " +
    //                        " User ID=IIS_220;Password=M;";

    //public static string con_str_oracle_cicco = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
    //                            "(HOST=CICCO-SCAN)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME = CICCO))); " +
    //                            " User ID=IIS_220;Password=M;";

    //public static string con_str_oracle_eceyt = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
    //                            "(HOST=CICCO-SCAN)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME = CEYT))); " +
    //                            " User ID=cicl;Password=cicl;";

    int checksms = 0;
    int checksms1 = 0;
    int checkinsertsuccess = 0;
    static string randomno;
    string rndom;

    protected void Page_Load(object sender, EventArgs e)
    {
        //TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
        TextBoxmecode.Text = "51333";// Session["sfc_code"].ToString();
        //TextBoximei.Text = "204943";// Session["imei"].ToString();
        txtmessage.ReadOnly = true;
    }

    [WebMethod]
    public static string[] GetCustomers(string pol, string me)//(string prefix)
    {
        List<string> customers = new List<string>();

        if (pol.ToUpper().Length >= 5)
        {
            using (OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco))
            {
                //conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.CommandText = "select pol_policy_no,pol_seq_no,pk_uw_m_customers.fn_get_cust_phone(uw_t_policies.pol_cus_code) PHONE, " +
                                      "          pk_uw_m_customers.fn_get_cust_title_and_name(pol_cus_code) NAME, POL_SLC_brn_code " +//, " +
                                      //"  'Please upload the required documents to your Policy no : "+ pol.ToUpper() + " by using below link.' msg1, " +
                                      //"  'http://10.10.1.233/quotation/upload_cust_doc.aspx?pol= AV00XXXXXX&rand=FTJ56RG' msg2" +
                                      "  from uw_t_policies " +
                                      "  where pol_marketing_executive_code = '"+me.ToUpper()+"' " +
                                      "  and pol_status in ('4', '5', '6') " +
                                      "  and pol_policy_no like '" + pol.ToUpper() + "%'";
                    //return string.Format("Name: {0}{2}Age: {1}", name, age, Environment.NewLine);
                    cmd.Connection = conn;
                    conn.Open();
                    using (OracleDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            //customers.Add(string.Format("{0}-{1}-{2}-{3}-{4}-{5}", sdr["POL_POLICY_NO"], sdr["NAME"], sdr["PHONE"], sdr["POL_SLC_brn_code"], sdr["msg1"], sdr["msg2"]));
                            customers.Add(string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}", sdr["POL_POLICY_NO"], sdr["NAME"], sdr["PHONE"], sdr["POL_SLC_brn_code"],
                                           "Please upload the required documents to your Policy no : " + sdr["POL_POLICY_NO"] + " by using below link. "+ Environment.NewLine + "",
                                           "http://www.ceyins.lk/comprehensive_image_upload/index1.php?polno=" + sdr["pol_seq_no"] + "&refno=" + RandomUtil.GetRandomString() + "" + Environment.NewLine + "" + Environment.NewLine + "Ceylinco General Insurance Ltd", sdr["pol_seq_no"]));
                        }
                    }
                    conn.Close();
                }
            }
        }
        return customers.ToArray();
    }


    //private static string CreateRandomPassword(int length)
    //{
    //    // Create a string of characters, numbers, special characters that allowed in the password  
    //    //string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
    //    string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
    //    Random random = new Random();

    //    // Select one random character at a time from the string  
    //    // and create an array of chars  
    //    char[] chars = new char[length];
    //    for (int i = 0; i < length; i++)
    //    {
    //        chars[i] = validChars[random.Next(0, validChars.Length)];
    //    }
    //    return new string(chars);
    //}

    static class RandomUtil
    {
        /// <summary>
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            //randomno = "";

            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.

            randomno = path.ToUpper();
            return randomno;
        }
    }



    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/managermenu.aspx");
    }

    protected void sendsms_Click(object sender, EventArgs e)
    {
        if (txtphone.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Phone Number Cannot be Empty');", true);
            clear2();
        }
        else if (txtpolicyno.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Policy No Cannot be empty');", true);
            clear2();
        }
        else if (txtmsg1.Text=="" || txtmsg2.Text=="")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Massage Cannot be empty');", true);
            clear2();
        }
        else
        {
            checksms = smssend(txtmsg1.Text.ToUpper().Trim());
            if (checksms == 1)
            {
                checksms1 = smssend(txtmsg2.Text.Trim());
            }

            if (checksms == 1 && checksms1 == 1)
            {
                checkinsertsuccess = insert();
                //checkinsertsuccess = insert("MMMMMMMM");
                if (checkinsertsuccess == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('SMS has sent to your phone " + txtphone.Text.Trim() + "');", true);
                    clear();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Insert Faild');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('SMS Faild');", true);
                clear();
            }
        }
    }

    public int smssend(string msg)
    {
        int a = 0;
        string tpp;



        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicl);
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            oratran = con.BeginTransaction();
            cmd.Transaction = oratran;
            cmd.CommandText = "pk_cl_sms_process.pu_send_sms('" + txtphone.Text.Trim() + "','" + msg.Trim() + "')";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteScalar();
            oratran.Commit();
            con.Close();
            oratran.Dispose();
            cmd.Dispose();

            a = 1;

            //con = new OracleConnection(Connection.con_str_oracle_cicl);
            ////con.Open();
            //cmd = new OracleCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "pk_tender.pu_send_sms_suntel";// ('777745778', TRIM (wkmessage))
            //cmd.CommandType = CommandType.StoredProcedure;

            //tpp = gettelephone();
            //cmd.Parameters.Add("pusender", OracleType.VarChar, 10).Value = tpp;//gettelephone();//"0715784519";
            //cmd.Parameters.Add("pumessage", OracleType.VarChar, 500).Value = newpwd;

            ////con.Open();
            //a = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            a = 0;
        }
        finally
        {
            con.Close();
        }
        return a;
    }


    public int insert()
    {
        int checkinsert = 0;
        int checkdelete = 0;
        string msg = txtmsg1.Text.ToUpper().Trim() + txtmsg2.Text.ToUpper().Trim();

        //string querydelete = "delete from me_cus_upload_sms where me_sms_policy_no='" + txtpolicyno.Text.ToUpper().Trim() + "' " +
        //                     " and me_sms_phone='" + txtphone.Text.ToUpper().Trim() + "'";

        string queryinsert = "insert into me_cus_upload_sms (me_sms_policy_no,me_sms_name,me_sms_phone,me_sms_random,me_sms_msg,me_sms_pol_seq_no) " +
                                " values ('" + txtpolicyno.Text.ToUpper().Trim() + "','" + txtname2.Text.ToUpper().Trim() + "' " +
                                " ,'"+ txtphone.Text.ToUpper().Trim() + "','"+ getrandom() +"','"+ msg + "','"+txtpolseq.Text+"')";

        try
        {
            con = new OracleConnection(Connection.con_str_oracle_eceyt);
            con.Open();

            //cmd = new OracleCommand(querydelete, con);
            //checkdelete = cmd.ExecuteNonQuery();
            //cmd.Dispose();

            cmd = new OracleCommand(queryinsert, con);
            checkinsert = cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
        //if (checkinsert == 1)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Inserted');", true);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Insert Failed');", true);
        //}
        return checkinsert;
    }

    public string getrandom()
    {
        string value = txtmsg2.Text;//"Unit: 300 V";
        string separator = "refno=";

        // Part 1: get index of separator.
        int separatorIndex = value.IndexOf(separator);

        // Part 2: if separator exists, get substring.
        if (separatorIndex >= 0)
        {
            string result = value.Substring(separatorIndex + separator.Length).Substring(0,11);
            rndom = result;
            //Console.WriteLine("RESULT: {0}", result);
        }

        return rndom;
    }

    public void clear()
    {
        txtpolicyno.Text = "";
        txtname.Text = "";
        txtphone.Text = "";
        txtmessage.Text = "";
    }

    public void clear2()
    {
        txtname.Text = "";
        txtphone.Text = "";
        txtmessage.Text = "";
    }
}