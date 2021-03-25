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
    int count = 0;

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
                txttotal.Text = "0";


            }

            else
            {
                Response.Redirect("acc_login.aspx");
            }

        }



    }


    public int loaddata()
    {
        int year = Convert.ToInt32(Convert.ToDateTime(TextBoxyear.Text).ToString("yyy").ToString());
        int month = Convert.ToInt32(Convert.ToDateTime(TextBoxyear.Text).ToString("MM").ToString());
        try {
            OracleConnection con = new OracleConnection(Connection.con_str_oracle_cicco);
            con.Open();
            string sql= "SELECT sp_last_year, sp_new_plan, sp_ren_plan,sp_tot_target   FROM SM_T_SALES_PLAN "+
                        " WHERE sp_pln_year = '"+year+"' AND sp_pln_mon = '"+month+"' and sp_prd_type = '"+DropDownListtype.SelectedValue+"' AND sp_sfc_code = '"+txtmecode.Text+"' "+
                        "  AND sp_brn_code = '"+ txtbranchcode.Text + "'";
            OracleCommand cmd = new OracleCommand(sql, con);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                TextBoxlastyearcost.Text = rd[0].ToString();
                TextBoxnewplan.Text = rd[1].ToString();
                TextBoxrenewalplan.Text = rd[2].ToString();
                txttotal.Text = rd[3].ToString();
                count++;

            }
            con.Close();
        }

        catch(Exception ex)
        { }

        finally
        {
           
        }
        return count;
    }

    public int updatedata()
    {
        int year = Convert.ToInt32(Convert.ToDateTime(TextBoxyear.Text).ToString("yyy").ToString());
        int month = Convert.ToInt32(Convert.ToDateTime(TextBoxyear.Text).ToString("MM").ToString());
        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            cmd = new OracleCommand();
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.Clear();
            cmd.CommandText = "pk_sm_t_me_visits.PU_SALES_PLAN_DATA_UPDATE  ";
            cmd.Parameters.Add("wksp_sfc_code", OracleType.VarChar, 10).Value = txtmecode.Text;
            cmd.Parameters.Add("wksp_brn_code", OracleType.VarChar, 5).Value = txtbranchcode.Text;
            cmd.Parameters.Add("wksp_prd_type", OracleType.VarChar, 1).Value = DropDownListtype.SelectedValue;
            cmd.Parameters.Add("wksp_pln_year", OracleType.Number, 4).Value = year;
            cmd.Parameters.Add("wksp_pln_mon", OracleType.Number, 2).Value = month;
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
        return check;
    }



    protected void Buttonview_Click(object sender, EventArgs e)
    {
        if(DropDownListtype.SelectedIndex!=0 && TextBoxyear.Text != "")
        {

         int checkcount=loaddata();
            if (checkcount > 0) {

            }

            else
            {
                ButtonSave.Visible = false;
            }

        }
    }


//public void clear()
//{
//    TextBoxVisitNo.Text = "";
//    TextBoxvisitDate.Text = "";
//    TextBoxnxtFallowdate.Text = "";
//    DropDownListbus.SelectedIndex = 0;
//    TextBoxaddbusclosdate.Text = "";
//    TextBoxpolno.Text = "";
//    txtremarks.Text = "";


//    TextBoxvisitDate.ForeColor = System.Drawing.Color.Gray;
//    TextBoxnxtFallowdate.ForeColor = System.Drawing.Color.Gray;
//    DropDownListbus.ForeColor = System.Drawing.Color.Gray;
//    TextBoxaddbusclosdate.ForeColor = System.Drawing.Color.Gray;
//    TextBoxpolno.ForeColor = System.Drawing.Color.Gray;
//    txtremarks.ForeColor = System.Drawing.Color.Gray;



//}



//private Boolean ValidationfallowupDetails()
//{
//    Boolean status = true;

//    if (TextBoxvisitDate.Text.Equals(""))
//    {
//        status = false;
//        TextBoxvisitDate.BorderColor = System.Drawing.Color.Red;
//    }
//    else
//    {
//        TextBoxvisitDate.BorderColor = System.Drawing.Color.Black;
//    }



//    if (DropDownListbus.SelectedIndex.Equals(0))
//    {
//        status = false;
//        DropDownListbus.BorderColor = System.Drawing.Color.Red;
//    }
//    else
//    {
//        DropDownListbus.BorderColor = System.Drawing.Color.Black;
//    }





//    return status;

//}

protected void ButtonSave_Click(object sender, EventArgs e)
    {

    int chk = updatedata();
    if (chk > 0)
    {
        LabelMsg.ForeColor = System.Drawing.Color.Green;
        LabelMsg.Text = "Successfully update";
      

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
}