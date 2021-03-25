using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

public partial class login : System.Web.UI.Page
{
    OracleConnection conn = null;
    OracleCommand command,cmd = null;
    Object obj = null;
    string sfc_brn_code, sfc_code = null;
    int positionno = 0;
    protected void Page_Load(object sender, EventArgs e)
    {


        //TextBoxImei.Text = HttpUtility.UrlDecode(Request.QueryString["ic"]).Trim().ToUpper().ToString();
       
        //Session.RemoveAll();
        //LabelErr.Text = "";
        //if (Request.Cookies["userid"] != null) {
        //    TextBoxUsername.Text = Request.Cookies["userid"].Value;
        //    CheckBoxremember.Checked = true;

        //}

            

    }

    //protected void ButtonLogin_Click(object sender, EventArgs e)
    //{
    //    LabelErr.Text = "";

    //    //get field values
    //    string imei = TextBoxImei.Text.ToUpper();
    //    string epf = TextBoxUsername.Text.ToUpper();

    //    //Connection.con_str_oracle = Connection.con_str_oracle_cicco;
    //    int posno = getPosition();
    //    Session["posno"] = posno;
    //    Session["imei"] = TextBoxImei.Text;

    //    //login checking
    //    try
    //    {
    //        conn = new OracleConnection(Connection.con_str_oracle_cicco);
    //        conn.Open();//open connection
    //        string query = "select sfc_code,sfc_imei_no,sfc_brn_code FROM SM_M_SALES_FORCE WHERE sfc_code=:epf  AND  ( sfc_imei_no=:imei or sfc_imei_no2 = :imei)";
                                  
    //        command = new OracleCommand(query, conn);
    //        command.Parameters.Add(new OracleParameter("epf", epf));
    //        command.Parameters.Add(new OracleParameter("imei", imei));
      


    //        OracleDataReader rd = command.ExecuteReader();
    //        if (rd != null)
    //        {
    //            while (rd.Read())
    //            {

    //                Session["sfc_brn_code"] = rd.GetString(2);
    //                Session["sfc_code"] = rd.GetString(0);
                    
    //                //Session["mobile"] = rd.GetString(4);
    //                if (CheckBoxremember.Checked== true){
    //                    Response.Cookies["epfno"].Value = TextBoxUsername.Text;
    //                    Response.Cookies["epfno"].Expires = DateTime.Now.AddDays(15);

    //                }

    //                else
    //                {

    //                    Response.Cookies["epfno"].Expires = DateTime.Now.AddDays(-1);
    //                }

                    
    //                Session.Timeout = 30;
    //                LabelErr.Text = "correct Login Details !";
    //                Session["epf"] = epf;
                    
    //                Response.Redirect("Home.aspx");
    //            }
    //        }

    //        if (!rd.HasRows)
    //        {
    //            LabelErr.Text = "Retry,Incorrect Login Details !";
    //            TextBoxUsername.Text = "";
                
    //            //DropDownListDb.SelectedIndex = 0;

    //        }

    //        command.Dispose();
    //        conn.Close();

    //    }
    //    catch (OracleException ex)
    //    {
    //        LabelErr.Text = "Error : " + ex.Message.ToString();
    //    }

    //}

    //public int getPosition()
    //{
    //    try {
    //        conn=new OracleConnection(Connection.con_str_oracle_cicco);
    //        conn.Open();
    //        string sql = "select pk_sm_t_me_visits.FN_GET_HEAD_TYPE('"+ TextBoxImei.Text+ "') from dual";
    //        cmd = new OracleCommand(sql, conn);
    //        OracleDataReader rd = cmd.ExecuteReader();
    //        while (rd.Read())
           
    //        {
    //        positionno=Convert.ToInt16(rd[0].ToString());


    //        }
    //        conn.Close();
    //    }
    //    catch(Exception ex)
    //    {

    //    }
    //    return positionno;
    //}
}