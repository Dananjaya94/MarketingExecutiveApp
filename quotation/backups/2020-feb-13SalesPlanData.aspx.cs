using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Web.Services;
using System.Net.Mail;

public partial class AllIslandPromotion : System.Web.UI.Page
{
    OracleDataReader rd;
    DataTable dt = null;
    public int getstate = 0;
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd1;
    int check = 0;
    double lastyearcost = 0.0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //populateTrantype();

        if (!this.IsPostBack)
        {

            if (Session["sfc_brn_code"].ToString() != "" && Session["sfc_code"].ToString() != "")
            {

                txtbranchcode.Text = Session["sfc_brn_code"].ToString();
                txtmecode.Text = Session["sfc_code"].ToString();
                TextBoxnewplan.Text = "0";
                TextBoxrenewalplan.Text = "0";
                txttotal.Text= "0";
                // getLeasingCompany();


            }

            else
            {
                Response.Redirect("acc_login.aspx");
            }

        }





    }


    public int savedata()
    {
        if (ValidationfallowupDetails())
        {
            int year =Convert.ToInt32( Convert.ToDateTime(TextBoxyear.Text).ToString("yyy").ToString());
            int month = Convert.ToInt32( Convert.ToDateTime(TextBoxyear.Text).ToString("MM").ToString());
            try
            {
                con = new OracleConnection(Connection.con_str_oracle_cicco);
                cmd = new OracleCommand();
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Clear();
                cmd.CommandText = "pk_sm_t_me_visits.PU_SALES_PLAN_DATA  ";
                cmd.Parameters.Add("wksp_sfc_code", OracleType.VarChar, 10).Value = txtmecode.Text;
                cmd.Parameters.Add("wksp_brn_code", OracleType.VarChar,5).Value = txtbranchcode.Text;
                cmd.Parameters.Add("wksp_prd_type", OracleType.VarChar,1).Value = DropDownListtype.SelectedValue;
                cmd.Parameters.Add("wksp_pln_year", OracleType.Number, 4).Value = year;
                cmd.Parameters.Add("wksp_pln_mon", OracleType.Number,2).Value = month;
                cmd.Parameters.Add("wksp_last_year", OracleType.Number, 17).Value = TextBoxlastyearcost.Text;
                cmd.Parameters.Add("wksp_new_plan", OracleType.Number, 17).Value = TextBoxnewplan.Text;
                cmd.Parameters.Add("wksp_ren_plan", OracleType.Number, 17).Value = TextBoxrenewalplan.Text;
                cmd.Parameters.Add("wksp_tot_target", OracleType.Number, 17).Value = txttotal.Text;


                check = cmd.ExecuteNonQuery();
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

        else
        {
            LabelMsg.ForeColor = System.Drawing.Color.Red;
            LabelMsg.Text = "Field must be entered";
        }
        return check;
    }

    public void clear()
    {

        TextBoxyear.Text = "";
        DropDownListtype.SelectedIndex = 0;
        TextBoxlastyearcost.Text = "";
        TextBoxnewplan.Text = "";
        TextBoxrenewalplan.Text = "";
        txttotal.Text = "";


        TextBoxyear.ForeColor = System.Drawing.Color.Gray;
        TextBoxlastyearcost.ForeColor = System.Drawing.Color.Gray;
        DropDownListtype.ForeColor = System.Drawing.Color.Gray;
        TextBoxnewplan.ForeColor = System.Drawing.Color.Gray;
        TextBoxrenewalplan.ForeColor = System.Drawing.Color.Gray;
        txttotal.ForeColor = System.Drawing.Color.Gray;



    }



    private Boolean ValidationfallowupDetails()
    {
        Boolean status = true;

        if (TextBoxyear.Text.Equals(""))
        {
            status = false;
            TextBoxyear.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxyear.BorderColor = System.Drawing.Color.Black;
        }



        if (DropDownListtype.SelectedIndex.Equals(0))
        {
            status = false;
            DropDownListtype.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            DropDownListtype.BorderColor = System.Drawing.Color.Black;
        }

        if (TextBoxlastyearcost.Text.Equals(""))
        {
            status = false;
            TextBoxlastyearcost.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxlastyearcost.BorderColor = System.Drawing.Color.Black;
        }

        if (TextBoxnewplan.Text.Equals(""))
        {
            status = false;
            TextBoxnewplan.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxnewplan.BorderColor = System.Drawing.Color.Black;
        }
        if (TextBoxrenewalplan.Text.Equals(""))
        {
            status = false;
            TextBoxrenewalplan.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxrenewalplan.BorderColor = System.Drawing.Color.Black;
        }


        return status;

    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {

        int chk = savedata();
        if (chk > 0)
        {
            LabelMsg.ForeColor = System.Drawing.Color.Green;
            LabelMsg.Text = "Success";
            clear();

        }

        else
        {

            LabelMsg.ForeColor = System.Drawing.Color.Red;
            LabelMsg.Text = "Fail";
        }
    }

    protected void ButtonClear_Click(object sender, EventArgs e)
    {
     //   clear();
    }

    protected void ButtonBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/salesMenu.aspx");
    }



    protected void Buttoncal_Click(object sender, EventArgs e)
    {
        if(TextBoxyear.Text!="")
        { 
        string year = Convert.ToDateTime(TextBoxyear.Text).ToString("yyy").ToString();
        string month= Convert.ToDateTime(TextBoxyear.Text).ToString("MM").ToString();
            string mecode = txtmecode.Text;
            TextBoxlastyearcost.Text = getlastyearamount( mecode,year,month).ToString();

        }
    }

    public double getlastyearamount(string mecode,string year,string month)
    {

        using (OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco))
        {

            using (OracleCommand cmd = new OracleCommand())
            {
                if (DropDownListtype.SelectedValue=="M")
                {
                    cmd.CommandText = "select nvl (sum(cp + rs + tc),0) lastyearsum from mv_uw_pol_new a where pol_marketing_executive_code = '" + mecode + "' " +
                                      "   and to_char(marketing_date, 'yyyy') = '" + year + "' " +
                                      "  and to_char(marketing_date, 'mm') = '" + month + "' " +
                                      "  and pol_cla_code in ('MC', 'M4', 'M3')  ";
                }
                else if (DropDownListtype.SelectedValue == "N")
                {
                    cmd.CommandText = "select nvl (sum(cp + rs + tc),0) lastyearsum from mv_uw_pol_new a where pol_marketing_executive_code = '" + mecode + "' " +
                                      "   and to_char(marketing_date, 'yyyy') = '" + year + "' " +
                                      "  and to_char(marketing_date, 'mm') = '" + month + "' " +
                                      "  and pol_cla_code not in ('MC', 'M4', 'M3')  ";
                }



                //cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (OracleDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lastyearcost = Convert.ToDouble(sdr[0].ToString());
                    }
                }
                conn.Close();
            }
            return lastyearcost;
        }

    }
}