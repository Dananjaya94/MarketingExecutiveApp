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
    OracleCommand command = null;
    Object obj = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.RemoveAll();
        LabelErr.Text = "";
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        LabelErr.Text = "";

        //get field values
        
        string un = TextBoxUsername.Text.ToUpper();
        string password_cipher=Encryption.EncryptString(TextBoxPassword.Text.Trim(), "abcd");

        //Connection.con_str_oracle = Connection.con_str_oracle_ceyt;

        //login checking
        try
        {
            conn = new OracleConnection(Connection.con_str_oracle_ceyt);
            conn.Open();//open connection
            string query = "select sfc_surname,sfc_first_name || ' '  || sfc_surname SFC_NAME, SFC_BRN_CODE FROM SM_M_SALES_FORCE WHERE sfc_code=:userName  AND sfc_me_random_pw='" + password_cipher + "' ";

            command = new OracleCommand(query, conn);
            command.Parameters.Add(new OracleParameter("userName", un));

            OracleDataReader rd = command.ExecuteReader();
            if (rd != null)
            {
                while (rd.Read())
                {
                    Session["sfc_surname"] = rd.GetString(0);
                    //Session["db"] = "CICL";//DropDownListDb.Text;
                    Session.Timeout = 30;
                    LabelErr.Text = "correct Login Details !";
                    Response.Redirect("quotation.aspx");
                }
            }

            if (!rd.HasRows)
            {
                LabelErr.Text = "Retry,Incorrect Login Details !";
                TextBoxUsername.Text = "";
                TextBoxPassword.Text = "";
                //DropDownListDb.SelectedIndex = 0;

            }

            command.Dispose();
            conn.Close();

        }
        catch (OracleException ex)
        {
            LabelErr.Text = "Error : " + ex.Message.ToString();
        }

    }
}