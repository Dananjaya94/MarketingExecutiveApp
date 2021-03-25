using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class empregistration : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;

//    public static string con_str_oracle_pnj = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
//"(HOST=10.10.5.193)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=CIGPAY)(SID=PNJ))); " +
//" User Id=Ceygen;Password=ceygen;";

//    public static string con_str_oracle_cey = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
//"(HOST=10.10.1.238)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=CIGPAY)(SID=CIGPAY))); " +
//" User Id=Ceygen;Password=ceygen;";




    protected void Page_Load(object sender, EventArgs e)
    {
        // String username;
        TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
        TextBoxmecode.Text = Session["sfc_code"].ToString();

        Panel2.Visible = false;
    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/empperfomancemenu.aspx");
    }

    protected void btngetMe_Click(object sender, EventArgs e)
    {
        getmepayroll();

        //Panel2.Visible = true;
    }

    public void getmepayroll()
    {
        string sqlquot = "select emp_number,emp_epf_number,emp_sales_code,emp_active_hrm_flg,emp_active_payroll_flg,emp_display_name " +
                         " , emp_nic_no,(select centre_name from hs_pr_cost_centre@cigpay where centre_code=hs_hr_employee.centre_code) branch " +
                         "   from hs_hr_employee@cigpay" +
                         "   where emp_nic_no = '"+txtsearchNIC.Text.Trim().ToUpper()+"' " +
                         "   AND emp_active_payroll_flg = 1 " +
                         "   AND emp_active_hrm_flg = 1";

        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            con.Open();

            cmd = new OracleCommand(sqlquot, con);
            rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {

                    txtname.Text = rd["emp_display_name"].ToString();
                    txtnic.Text = rd["emp_nic_no"].ToString();
                    txtatachdbranch.Text = rd["branch"].ToString();
                    txtempno.Text = rd["emp_number"].ToString();
                    txtepfno.Text = rd["emp_epf_number"].ToString();
                }
                Panel2.Visible = true;
            }
            else
            {
                Panel2.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Valid NIC Number');", true);

            }
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

    protected void btnconfirm_popmodel_click(object sender, EventArgs e)
    {
        lblname.Text = txtname.Text;
        lblnic.Text = txtnic.Text;
        lblbranch.Text = txtatachdbranch.Text;
        lblempno.Text = txtempno.Text;
        lblepfno.Text = txtepfno.Text;

        lblname.ReadOnly = true;
        lblnic.ReadOnly = true;
        lblbranch.ReadOnly = true;
        lblempno.ReadOnly = true;
        lblepfno.ReadOnly = true;

        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        string sqlupdate = "UPDATE SM_M_SALES_FORCE SET sfc_ref_no ='"+lblepfno.Text+"' WHERE  sfc_code = '"+ TextBoxmecode.Text + "'";

        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            con.Open();

            cmd = new OracleCommand(sqlupdate, con);
            cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Updated');", true);
            clear();
        }
    }


    public void clear()
    {
        lblname.Text = "";
        txtname.Text = "";
        lblnic.Text = "";
        txtnic.Text = "";
        lblbranch.Text = "";
        txtatachdbranch.Text = "";
        lblempno.Text = "";
        txtempno.Text = "";
        lblepfno.Text = "";
        txtepfno.Text = "";
        txtsearchNIC.Text = "";

        Panel2.Visible = false;

    }

}