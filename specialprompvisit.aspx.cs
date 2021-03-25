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

                getvisittype();

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
            try
            {
                con = new OracleConnection(Connection.con_str_oracle_cicco);
                cmd = new OracleCommand();
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Clear();
                cmd.CommandText = "pk_sm_t_me_visits.PU_INS_VISIT_SPC_DATA  ";
                cmd.Parameters.Add("wkmeP_me_code", OracleType.VarChar, 5).Value = txtmecode.Text;
                cmd.Parameters.Add("wkmeP_visit_date", OracleType.DateTime).Value = Convert.ToDateTime(TextBoxvisitdate.Text);
                cmd.Parameters.Add("wkmeP_visit_TYPE", OracleType.VarChar, 100).Value = DropDownListvisittype.SelectedItem.Text;
                cmd.Parameters.Add("wkmeP_LOCATION", OracleType.VarChar, 100).Value = TextBoxlocation.Text;
                cmd.Parameters.Add("wkmep_remarks", OracleType.VarChar, 100).Value = TextBoxremark.Text;


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

     
        DropDownListvisittype.SelectedIndex = 0;
        TextBoxvisitdate.Text = "";
        TextBoxlocation.Text = "";
        TextBoxremark.Text = "";
    


     
        DropDownListvisittype.ForeColor = System.Drawing.Color.Gray;
        TextBoxvisitdate.ForeColor = System.Drawing.Color.Gray;
        TextBoxlocation.ForeColor = System.Drawing.Color.Gray;
        TextBoxremark.ForeColor = System.Drawing.Color.Gray;
  



    }



    private Boolean ValidationfallowupDetails()
    {
        Boolean status = true;




        if (DropDownListvisittype.SelectedIndex.Equals(0))
        {
            status = false;
            DropDownListvisittype.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            DropDownListvisittype.BorderColor = System.Drawing.Color.Black;
        }


        if (TextBoxvisitdate.Text.Equals(""))
        {
            status = false;
            TextBoxvisitdate.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxvisitdate.BorderColor = System.Drawing.Color.Black;
        }


        return status;

    }

    protected void getvisittype()
    {
        DropDownListvisittype.Items.Clear();
        DropDownListvisittype.Items.Add(new ListItem("----- Select Type -----", ""));
        string query = "select vtp_description,vtp_code from sm_t_me_visits_types";

        Common.FillLOV(DropDownListvisittype, query);

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
        Response.Redirect("~/VisitUpdateMenu.aspx");
    }





    //public double getlastyearamount(string mecode,string year,string month)
    //{
    //    using (OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco))
    //    {

    //        using (OracleCommand cmd = new OracleCommand())
    //        {
    //            cmd.CommandText = "select nvl (sum(cp + rs + tc),0) lastyearsum from mv_uw_pol_new a where pol_marketing_executive_code = '"+mecode+"' " +
    //                              "   and to_char(marketing_date, 'yyyy') = '"+year+"' " +
    //                              "  and to_char(marketing_date, 'mm') = '"+month+"' " +
    //                              "  and pol_cla_code in ('MC', 'M4', 'M3')  ";

    //            //cmd.Parameters.AddWithValue("@SearchText", prefix);
    //            cmd.Connection = conn;
    //            conn.Open();
    //            using (OracleDataReader sdr = cmd.ExecuteReader())
    //            {
    //                while (sdr.Read())
    //                {
    //                    lastyearcost = Convert.ToDouble(sdr[0].ToString());
    //                }
    //            }
    //            conn.Close();
    //        }
    //        return lastyearcost;
    //    }

    //}
}