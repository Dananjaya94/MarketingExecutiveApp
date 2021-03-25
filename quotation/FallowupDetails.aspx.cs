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

    protected void Page_Load(object sender, EventArgs e)
    {
        //populateTrantype();

        if (!this.IsPostBack)
        {


            TextBoxVisitNo.Text = HttpUtility.UrlDecode(Request.QueryString["visit_seq"]).Trim().ToUpper().ToString();

        }




    }


    public int savedata()
    {
        if (ValidationfallowupDetails()) {
            string businessclosedate = null,nextfollowdate=null;

            if (TextBoxaddbusclosdate.Text != "")
            {
                businessclosedate = TextBoxaddbusclosdate.Text;
            }

            else
            {
            }


            if (TextBoxnxtFallowdate.Text != "")
            {
                nextfollowdate = TextBoxnxtFallowdate.Text;
            }

            else
            {
            }

            try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            cmd = new OracleCommand();
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.Clear();
            cmd.CommandText = "pk_sm_t_me_visits.PU_INS_FOLLOW_DATA ";
            cmd.Parameters.Add("wkmfl_mev_seq_no", OracleType.VarChar, 20).Value = TextBoxVisitNo.Text;
            cmd.Parameters.Add("wkmfl_visit_date", OracleType.DateTime).Value = Convert.ToDateTime(TextBoxvisitDate.Text);
            cmd.Parameters.Add("wkmfl_mev_flo_date", OracleType.DateTime).Value = Convert.ToDateTime(nextfollowdate);
            cmd.Parameters.Add("wkmev_busi_closed", OracleType.VarChar, 5).Value = DropDownListbus.SelectedValue.ToString();
            cmd.Parameters.Add("wkmev_busi_closed_date", OracleType.DateTime).Value = Convert.ToDateTime(businessclosedate);
            cmd.Parameters.Add("wkmev_policy_no", OracleType.VarChar, 20).Value = TextBoxpolno.Text;
            cmd.Parameters.Add("wkmev_remarks", OracleType.VarChar, 100).Value = txtremarks.Text;


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
        TextBoxVisitNo.Text = "";
        TextBoxvisitDate.Text = "";
        TextBoxnxtFallowdate.Text = "";
        DropDownListbus.SelectedIndex = 0;
        TextBoxaddbusclosdate.Text = "";
        TextBoxpolno.Text = "";
        txtremarks.Text = "";

        
        TextBoxvisitDate.ForeColor = System.Drawing.Color.Gray;
        TextBoxnxtFallowdate.ForeColor = System.Drawing.Color.Gray;
        DropDownListbus.ForeColor = System.Drawing.Color.Gray;
        TextBoxaddbusclosdate.ForeColor = System.Drawing.Color.Gray;
        TextBoxpolno.ForeColor = System.Drawing.Color.Gray;
        txtremarks.ForeColor = System.Drawing.Color.Gray;



    }



    private Boolean ValidationfallowupDetails()
    {
        Boolean status = true;

        if (TextBoxvisitDate.Text.Equals(""))
        {
            status = false;
            TextBoxvisitDate.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxvisitDate.BorderColor = System.Drawing.Color.Black;
        }


 
        if (DropDownListbus.SelectedIndex.Equals(0))
        {
            status = false;
            DropDownListbus.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            DropDownListbus.BorderColor = System.Drawing.Color.Black;
        }


        if (DropDownListbus.SelectedItem.Value == "Y")
        {
            if (TextBoxpolno.Text.Equals(""))
            {
                status = false;
                TextBoxpolno.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                TextBoxpolno.BorderColor = System.Drawing.Color.Black;
            }


            if (TextBoxaddbusclosdate.Text.Equals(""))
            {
                status = false;
                TextBoxaddbusclosdate.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                TextBoxaddbusclosdate.BorderColor = System.Drawing.Color.Black;
            }


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
            LabelMsg.Text = "Mandatory data missing";
        }
     }

    protected void ButtonClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void ButtonBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Fallowupmenu.aspx");
    }
}