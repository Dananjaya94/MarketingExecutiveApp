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
    int check, checkMobil = 0;
    int a;
    string poltype;

    protected void Page_Load(object sender, EventArgs e)
    {
        //populateTrantype();

        if (!this.IsPostBack)
        {
            if (Session["sfc_code"] == null)
            {
                Response.Redirect("../home.aspx");
            }
            else
            {

                rbmotor.Checked = true;
            
                //load branch me lov
                //DropDownListServiceME.Items.Clear();
                //DropDownListServiceME.Items.Add(new ListItem("----- Select Branch ME -----", ""));
                //string query3 = "select  (SFC_CODE||'  '|| trim(pk_sm_m_sales_force.fn_get_name(SFC_CODE)))description,SFC_CODE value1,pk_sm_m_sales_force.fn_get_name(SFC_CODE) from " +
                //"sm_m_sales_force where sfc_active ='Y' AND sfc_brn_active ='Y' AND sfc_commissionalble ='Y' and sfc_brn_code='" + Session["branch_code"].ToString() + "'";
                //Common.FillLOV(DropDownListServiceME, query3);

                //DropDownListEvent.Items.Clear();
                //DropDownListEvent.Items.Add(new ListItem("----- Select Event -----", ""));
                //string query2 = "SELECT  hub_m_event, hub_code  FROM vph_m_events WHERE hub_m_bra_code ='CICL' ";
                //Common.FillLOV(DropDownListEvent, query2);

                cmbClass.Items.Clear();
                cmbClass.Items.Add(new ListItem("----- Select Class -----", ""));
                string query4 = "SELECT cla_description,cla_code FROM UW_R_CLASSES";
                Common.FillLOV(cmbClass, query4);

                Clear();

                //generate customer id
                string branch = Session["sfc_brn_code"].ToString();
                LabelCustomerId.Text = Common.GenerateId("select pk_vph_t_cus_info.fn_get_cus_SPC_no('" + branch + "') FROM DUAL");

            }

        }




    }



    protected void ButtonBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../home.aspx");
    }
    //clear fields
    private void Clear()
    {
       
      
        TextBoxCustomerName.Text = "";
        //TextBoxShopName.Text = "";
        TextBoxMobile.Text = "";
        txtsuminsured.Text = "";
        txtcurrpremium.Text = "";
        //DropDownListEvent.SelectedIndex = 0;
        TextBoxAddress.Text = "";
        TextBoxVehNo.Text = "";
        TextBoxFallowUpDate.Text = "";
        //DropDownListServiceME.SelectedIndex = 0;
cmbClass.SelectedIndex = 0;
cmbProduct.SelectedIndex = 0;
cmbprostype.SelectedIndex = 0;
        txtremarks.Text = "";
        cmbprostype.SelectedIndex = 0;

        txtremarks.BorderColor = System.Drawing.Color.Black;
        TextBoxCustomerName.BorderColor = System.Drawing.Color.Black;
      
        TextBoxMobile.BorderColor = System.Drawing.Color.Black;
        cmbClass.BorderColor = System.Drawing.Color.Black;
        TextBoxAddress.BorderColor = System.Drawing.Color.Black;
        TextBoxVehNo.BorderColor = System.Drawing.Color.Black;
        TextBoxFallowUpDate.BorderColor = System.Drawing.Color.Black;
        cmbProduct.BorderColor = System.Drawing.Color.Black;
        cmbprostype.BorderColor = System.Drawing.Color.Black;
        txtcurrpremium.BorderColor = System.Drawing.Color.Black;
        txtsuminsured.BorderColor = System.Drawing.Color.Black;
        cmbprostype.BorderColor = System.Drawing.Color.Black;
        cmbClass.BorderColor = System.Drawing.Color.Black;
        cmbProduct.BorderColor = System.Drawing.Color.Black;

        LabelCustomerId.Text = Common.GenerateId("select pk_vph_t_cus_info.fn_get_cus_SPC_no('" + Session["sfc_brn_code"].ToString() + "') FROM DUAL");

        //clear datagrid
        
       
       

   
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        

        if (rbmotor.Checked)
        {
            poltype = "MO";
        }
        else if(rbnonmotor.Checked)
        {
            poltype = "NM";
        }


        
    
        if (Session["sfc_code"] !=null)
        {
            TextBoxMe.Text = Session["sfc_code"].ToString();
        }
        else 
        {
            TextBoxMe.Text = " ";
        }
        
        int x = 0;

        DateTime todaydate = Convert.ToDateTime(DateTime.Now);
        DateTime sysdate = Convert.ToDateTime(TextBoxFallowUpDate.Text);
        
    

        if (ValidationCustomerDetails())
        {
            int checkMobileNo = checkNumber();
            if (checkMobileNo > 0) {
                if(!txtsuminsured.Text.Equals(""))
                    {
                    if (!txtcurrpremium.Text.Equals(""))
                    {
                        if (cmbprostype.SelectedValue.ToString() != "0")
                        {
                            if (todaydate < sysdate)
                            {
                                string fallow_date = Convert.ToDateTime(TextBoxFallowUpDate.Text).ToString("dd-MMM-yyy").ToString();
                                //customer details insert
                                string sql = "insert into VPH_SPC_PROMO (vpc_hub_code, vpc_brn_code, vpc_cus_code, vpc_cus_name, vpc_me_code, " +
                                             " vpc_phone_1, vpc_address, vpc_renewal_date, vpc_status,vpc_vehicle_no,vpc_sum_insured," +
                                            "  vpc_premium, vpc_remarks, vpc_pros_type,vpc_cla_code,vpc_prd_code,vpc_pol_type ) " +
                                             " values('SP0005', '" + Session["sfc_brn_code"].ToString() + "', " +
                                             " '" + LabelCustomerId.Text + "', '" + TextBoxCustomerName.Text + "', '" + TextBoxMe.Text+ "',  " +
                                            "  '" + TextBoxMobile.Text + "','" + TextBoxAddress.Text + "', '" + fallow_date + "', 'P','" + TextBoxVehNo.Text + "', " +
                                            " '" + txtsuminsured.Text.Trim() + "','" + txtcurrpremium.Text.Trim() + "','" + txtremarks.Text + "','" + cmbprostype.SelectedValue.ToString() + "', " +
                                            " '"+ cmbClass.SelectedValue.ToString() + "','" + cmbProduct.SelectedValue.ToString() + "','" + poltype+"')";



                                x = Common.Save(sql);
                                //insurance details insert



                                //return results : messages
                                if (x == 1)
                                {
                                    LabelMsg.ForeColor = System.Drawing.Color.Green;
                                    LabelMsg.Text = "insert success!";
                                    updatecusID();
                                    Clear();
                                }
                                else if (x == 0)
                                {
                                    LabelMsg.ForeColor = System.Drawing.Color.Red;
                                    LabelMsg.Text = "error values : customer details";
                                }
                            }

                            else
                            {
                                LabelMsg.ForeColor = System.Drawing.Color.Red;
                                LabelMsg.Text = "error values : The Date which is entered should be greater than the current date";
                            }
                        }
                        else
                        {
                            LabelMsg.ForeColor = System.Drawing.Color.Red;
                            LabelMsg.Text = "error values : Select Prospect Type";
                        }
                    }
                    else
                    {
                        LabelMsg.ForeColor = System.Drawing.Color.Red;
                        LabelMsg.Text = "error values : Premium connot be null";
                    }
                }
                else
                {
                    LabelMsg.ForeColor = System.Drawing.Color.Red;
                    LabelMsg.Text = "error values : Sum insured connot be null";
                }
            /*********/
        }
            else
            {
                LabelMsg.ForeColor = System.Drawing.Color.Red;
                LabelMsg.Text = "error values : Invalid Mobile No";

            }

        }
        else
        {
            LabelMsg.ForeColor = System.Drawing.Color.Red;
            LabelMsg.Text = "error values : customer details";
        }
 
    }

 


    private Boolean ValidationCustomerDetails()
    {
        Boolean status = true;

     
       

        if (TextBoxCustomerName.Text.Equals(""))
        {
            status = false;
            TextBoxCustomerName.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxCustomerName.BorderColor = System.Drawing.Color.Black;
        }
   
        
        if (TextBoxMobile.Text.Equals(""))
        {
            status = false;
            TextBoxMobile.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxMobile.BorderColor = System.Drawing.Color.Black;
        }

        
        if (TextBoxFallowUpDate.Text.Equals(""))
        {
            status = false;
            TextBoxFallowUpDate.BorderColor = System.Drawing.Color.Red;
        }
        else
        {
            TextBoxFallowUpDate.BorderColor = System.Drawing.Color.Black;
        }

        


        return status;
    }




    protected void ButtonClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public int checkNumber()

    {

        int chkNumber = 0;

        string sq = "SELECT " +

        "  nvl(to_number(pk_all_general.fn_valid_mobile_no('" + TextBoxMobile.Text + "')),0)value " +

        " FROM DUAL ";

        try

        {

            con = new OracleConnection(Connection.con_str_oracle_cicco);

            con.Open();

            OracleCommand cmd1 = new OracleCommand(sq, con);

            OracleDataReader rd1 = cmd1.ExecuteReader();

            //if (rd1.HasRows)

            //{

            while (rd1.Read())

            {

                chkNumber = Convert.ToInt32(rd1[0]);

            }

            //}

        }

        catch (Exception ex)

        {

            throw ex;

        }

        finally

        {

            con.Close();

        }

        return chkNumber;

    }


    protected void updatecusID() {

        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;
        cmd.CommandText = "pk_vph_t_cus_info.pu_update_cus_seq";

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("wkbrn", OracleType.VarChar).Value = Session["sfc_brn_code"].ToString();

        cmd.Parameters.Add("wkcol", OracleType.VarChar).Value = "SPC";


        try
        {
            conn.Open();

            a = cmd.ExecuteNonQuery();

        }
        catch (Exception ex) {
        }
        conn.Close();
    }


    protected void rbmotor_CheckedChanged(object sender, EventArgs e)
    {
        if (rbmotor.Checked)
        {
            lblVehi.Text = "Vehicle No";
        }
        else if (rbnonmotor.Checked)
        {
            lblVehi.Text = "Risk Name";
        }
    }

    protected void rbnonmotor_CheckedChanged(object sender, EventArgs e)
    {
        if (rbmotor.Checked)
        {
            lblVehi.Text = "Vehicle No";
        }
        else if (rbnonmotor.Checked)
        {
            lblVehi.Text = "Risk Name";
        }
    }

    protected void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmbProduct.Items.Clear();
        cmbProduct.Items.Add(new ListItem("----- Select Product -----", ""));
        string query5 = "SELECT prd_description,prd_code FROM UW_M_PRODUCTS WHERE PRD_CLA_CODE = '" + cmbClass.SelectedValue+"'";
        Common.FillLOV(cmbProduct, query5);
    }
}