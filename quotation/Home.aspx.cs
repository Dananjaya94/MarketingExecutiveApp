using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    [Obsolete]
    OracleConnection conn = null;
    [Obsolete]
    OracleCommand command, cmd = null;
    Object obj = null;
    string sfc_brn_code, sfc_code = null;
    int positionno = 0;

    [Obsolete]
    protected void Page_Load(object sender, EventArgs e)
    {


        TextBoxImei.Text = HttpUtility.UrlDecode(Request.QueryString["ic"]).Trim().ToUpper().ToString();
        TextBoxepf.Text = HttpUtility.UrlDecode(Request.QueryString["epf"]).Trim().ToUpper().ToString();
        TextBoxbranch.Text = getBranch();
        TextBoxposition.Text = getPosition().ToString();
        Session["sfc_brn_code"] = TextBoxbranch.Text;
        Session["sfc_code"] = TextBoxepf.Text;
        Session["posno"] = TextBoxposition.Text;
        Session["imei"] = TextBoxImei.Text;

        //Session["sfc_brn_code"] = "AV00";
        //Session["sfc_code"] = "51333";
        //Session["posno"] = "1";
        //Session["imei"] = "456789";

        Response.Redirect("HomeSecond.aspx");

    }

    [Obsolete]
    protected string getBranch()
    {

        try
        {
            conn = new OracleConnection(Connection.con_str_oracle_cicco);
            conn.Open();//open connection
            string query = "select sfc_brn_code from sm_m_sales_force a where sfc_code='"+ TextBoxepf.Text + "'";




            command = new OracleCommand(query, conn);
            OracleDataReader rd = command.ExecuteReader();
            if (rd != null)
            {
                while (rd.Read())
                {

                    sfc_brn_code = rd.GetString(0);
                   

                }
            }

           

            command.Dispose();
            conn.Close();

        }
        catch (OracleException ex)
        {
            Console.WriteLine(ex);
        }
        return sfc_brn_code;

    }

    [Obsolete]
    public int getPosition()
    {
        try
        {
            conn = new OracleConnection(Connection.con_str_oracle_cicco);
            conn.Open();
            string sql = "select pk_sm_t_me_visits.FN_GET_HEAD_TYPE('" + TextBoxImei.Text + "') from dual";
            cmd = new OracleCommand(sql, conn);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())

            {
                positionno = Convert.ToInt16(rd[0].ToString());


            }
            conn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return positionno;
    }


}