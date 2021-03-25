using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;

public partial class user_creation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session.RemoveAll();
            LabelErr.Text = "";
            LoadDefault();
        }
    }
 
    protected void ButtonFind_Click(object sender, EventArgs e)
    {
        BindData();
        ButtonSubmit.Visible = true;
    }

    //bind data to the grid view : user defined method 
    private void BindData()
    {
        //Response.Write(value_date);
        DataTable dt = new DataTable();

        using (OracleConnection oracon = new OracleConnection(Connection.con_str_oracle_ceyt))
        {
            using (OracleCommand cmd = oracon.CreateCommand())
            {
                string query = "select to_char(trim(sfc_initials)||' '||trim(sfc_first_name)||' '||trim(sfc_surname))full_name,sfc_nic_no,sfc_mobile1 " +
" from sm_m_sales_force where sfc_code='" + TextBoxEpfNo.Text.Trim() + "'";

                cmd.CommandText = query;
                oracon.Open();

                OracleDataAdapter sda = new OracleDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(dt);


                ViewState["CurrentTable"] = dt;
                if (dt.Rows.Count > 0)
                {
                    // BIND QUERY RESULT WITH THE GRIDVIEW.
                    GridViewDetails.DataSource = dt;
                    GridViewDetails.DataBind();

                }
            }
        }

    }

    protected void cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        //1.auto generated password
        string random_pw = Random.GeneratePassword();
        string cipherText = Encryption.EncryptString(random_pw, "abcd");
        //string plaintext = Encryption.DecryptString(cipherText, "abcd");

        //2.save to cicco sm_m_sales_force new column sfc_me_random_pw
        savePassword(cipherText);

        //3.generate sms
        string mobile = GetMobileNo();       
        string message = TextBoxEpfNo.Text+ " your ME web application password is : "  +random_pw;
        GenerateSMS(mobile,message);

        LoadDefault();
    }
    /*
     * get mobile number ME
     * */
    private string GetMobileNo()
    {
        string mobile = "";
        try
        {
            OracleConnection oracon = new OracleConnection(Connection.con_str_oracle_ceyt);
            oracon.Open();
            //query to load branch placed with
            string query = "select sfc_mobile1 from sm_m_sales_force where sfc_code='"+TextBoxEpfNo.Text+"'";
            OracleCommand cmd = new OracleCommand(query, oracon);
            OracleDataReader rd = cmd.ExecuteReader();
            if (rd != null)
            {
                while (rd.Read())
                {
                    mobile =  rd.GetString(0);
                }
            }
            else
            {
                mobile = "0771234567";
            }
            oracon.Close();

        }
        catch (Exception ex)
        {
            Response.Write(" error " + ex.Message);

        }
        return mobile;
    }
    /*
     * generate sms
     * */
    private void GenerateSMS(string mobile,string message)
    {
        //code for un pl/sql procedure
        using (OracleConnection objConn = new OracleConnection(Connection.con_str_oracle_cicl))
        {
            OracleCommand objCmd = new OracleCommand();
            objCmd.Connection = objConn;

            objCmd.CommandText = "Pk_lahiru.pu_send_sms_suntel('"+mobile+"','"+message+"')";
            objCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                objConn.Open();
                objCmd.ExecuteNonQuery();
                //LabelMsg.Text = "New Records updated sucessfully";
                LabelErr.ForeColor = System.Drawing.Color.Green;
                String error = "success sms sent";
                LabelErr.Text = error;
            }
            catch (Exception ex)
            {
                // LabelSuccess.Text = "New Records updated sucessfully";
                //LabelMessage.Text = ex.ToString();
            }
            objConn.Close();
        }
    }
    /*
     * save password in sm_m_sales_force
     * */
    private void savePassword(string random_pw)
    {
        string epf=TextBoxEpfNo.Text.Trim();

        OracleConnection oracon = new OracleConnection(Connection.con_str_oracle_ceyt);
        try
        {
            oracon.Open();
            string query="update sm_m_sales_force "+
                        "set sfc_me_random_pw='"+random_pw+"' "+
                        "where sfc_code='"+epf+"'";
            OracleCommand cmd = new OracleCommand( query, oracon);

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            LabelErr.ForeColor = System.Drawing.Color.Green;
            String error = "success";
            LabelErr.Text = error;            
        }
        catch (OracleException ex)
        {
            LabelErr.ForeColor = System.Drawing.Color.Red;
            String error = "error";
            LabelErr.Text = error;
           
        }
        finally
        {
            oracon.Close();
        }
    }

    /*
     * load default form
     * */
    public void LoadDefault()
    {
        TextBoxEpfNo.Text = "";
        //LabelErr.Text = "";
        GridViewDetails.DataSource = null;
        GridViewDetails.DataBind();
        ButtonSubmit.Visible = false;
    }
}