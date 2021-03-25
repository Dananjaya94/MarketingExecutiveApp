using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class quotation : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;

    double totalPerilAmt = 0.00;
    int cnt = 0;

    double premium = 0.00;
    double polfee = 0.00;
    double nbl = 0.00;
    double adminf = 0.00;
    double vat = 0.00;

    double finaltot = 0.00;

    double bp = 0.00;
    double hp = 0.00;
    double p4 = 0.00;

    double hpcheck = 0.00;
    double fdcheck = 0.00;
    double srcccheck = 0.00;
    double eccheck = 0.00;
    double rfcheck = 0.00;
    double rmcheck = 0.00;
    double uccheck = 0.00;
    double tabcheck = 0.00;


     /*
     * list create
     * */
    ArrayList init_values = new ArrayList();
    ArrayList init_perils = new ArrayList();

    String user = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            TextBoxUser.Text = HttpUtility.UrlDecode(Request.QueryString["user"]).Trim().ToUpper().ToString();
            
            
            populateProduct();
            Table1.Visible = false;
            tblTotal.Visible = false;
            btnCalRatio.Visible = false;
            btnExportPDF.Visible = false;
        }
    }

    public void populateProduct()
    {
        //string sqlquery = "select qtr_prd_code,qtr_prd_name from UW_QT_R_PRODUCTS";
        string sqlquery = "select qtr_prd_code,qtr_prd_name,'('||qtr_prd_code||') - '||qtr_prd_name prod_desk from UW_QT_R_PRODUCTS";

        try
        {
            db = new Connection();
            con = db.GetConnection;

            con.Open();

            cmd = new OracleCommand(sqlquery, con);
            cmbProduct.DataSource = cmd.ExecuteReader();
            cmbProduct.Items.Clear();
            cmbProduct.Items.Add(new ListItem("-- Select Product --", "0"));
            //cmbProduct.Items[0].Enabled = false;
            cmbProduct.DataTextField = "prod_desk";
            cmbProduct.DataValueField = "qtr_prd_code";
            cmbProduct.DataBind();
            //cmbProduct.Items[0].Attributes.Add("disabled", "disabled");
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

    public void populateProdtype()
    {
        //string sqlquery = "select qtr_prd_code,qtr_prd_name from UW_QT_R_PRODUCTS";
        string sqlquery = "select qty_prd_code,qty_prd_type,qty_type_desc,'('||qty_prd_type||') - '||qty_type_desc prodtype_desk from UW_QT_M_PRD_TYPES where qty_prd_code='" + cmbProduct.SelectedItem.Value.ToString() + "'";
        try
        {
            db = new Connection();
            con = db.GetConnection;

            con.Open();

            cmd = new OracleCommand(sqlquery, con);
            cmbProductType.DataSource = cmd.ExecuteReader();
            cmbProductType.Items.Clear();
            cmbProductType.Items.Add(new ListItem("-- Select Product Type --", "0"));
            //cmbProduct.Items[0].Enabled = false;
            cmbProductType.DataTextField = "prodtype_desk";
            cmbProductType.DataValueField = "qty_prd_type";
            cmbProductType.DataBind();
            //cmbProduct.Items[0].Attributes.Add("disabled", "disabled");
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

    protected void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateProdtype();
    }

    protected void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        // perilCalculation();
    }

    protected void btnCalPeril_Click(object sender, EventArgs e)
    {
        //  grid1.DataSource = null;
        //   grid1.DataBind();

        grid1.Columns[4].Visible = true;
        grid1.Columns[5].Visible = true;
        grid1.Columns[6].Visible = true;


        if (txtSumInsured.Text != "")
        {
            perilCalculation();

            gettaxrates();
            /****/
            btnCalRatio.Visible = true;


            //disable textboxes for last textboxes
            foreach (GridViewRow grow in grid1.Rows)
            {
                TextBox txtRaito = (TextBox)grow.FindControl("txtratio");
                DropDownList ddlratio = (DropDownList)grow.FindControl("ddlratio");

                string prdcode = grow.Cells[4].Text;//get product code
                string status = grow.Cells[5].Text;//get status                
                if (status.Equals("Y"))
                {
                    
                    ddlratio.Enabled = false;
                    txtRaito.Enabled = false;

                }

                if (prdcode.Equals("NC"))
                {
                    ddlratio.Visible = true;
                    txtRaito.Visible = false;
                }
                else
                {
                    ddlratio.Visible = false;
                    txtRaito.Visible = true;
                }
            }

            grid1.Columns[4].Visible = false;
            grid1.Columns[5].Visible = false;
            grid1.Columns[6].Visible = false;

            btnExportPDF.Visible = true;
            /****/
        }
        else
        {
            //Response.Write("<script>alert('Sum Insured Cannot be Empty');</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Sum Insured Cannot be Empty');", true);

            btnExportPDF.Visible = false;
            btnCalRatio.Visible = false;
        }


    }

    public void perilCalculation()
    {
        double extra = 0.0;
        //double suminsured = 0.0;
        string product = cmbProduct.SelectedItem.Value.ToString();
        string pordType = cmbProductType.SelectedItem.Value.ToString();

        string sqlquery = "select qtp_rate,qtp_user_para,qtp_prl_code,qtp_prl_code_desc,(('" + Convert.ToDouble(txtSumInsured.Text.Trim()) + "'*qtp_rate)/100)+qtp_loading1+qtp_loading2 Amount from UW_QT_M_PRD_PERIL_RATE " +
                          " where qtp_prd_code='" + product + "' " +
                          " and qtp_type_code='" + pordType + "' ";
        // " and qtp_prl_code='BP'";

        try
        {
            db = new Connection();
            con = db.GetConnection;

            con.Open();

            OracleDataAdapter adp = new OracleDataAdapter(sqlquery, con);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            grid1.DataSource = dt;
            grid1.DataBind();

            foreach (GridViewRow grow in grid1.Rows)
            {
                string aaa = grow.Cells[4].Text;

                if (aaa.Equals("BP") || aaa.Equals("RF"))
                {
                    if (aaa.Equals("HP"))
                    {
                        extra = Convert.ToDouble(grow.Cells[3].Text) + 500.0;
                    }
                    else
                    {
                        extra = Convert.ToDouble(grow.Cells[3].Text);
                    }

                    //auto check BP and Road Safety Fund
                    CheckBox chkdel = (CheckBox)grow.FindControl("chkGrid");
                    chkdel.Checked = true;

                    if (chkdel.Checked)
                    {
                        //totalPerilAmt += Convert.ToDouble(grow.Cells[2].Text);
                        totalPerilAmt += extra;//dr["amount"]);row.Cells[0].Text
                        cnt = cnt + 1;
                    }

                    chkdel.Enabled = false;

                    //textbox 

                    /****changed taxes according to the perils ****gettaxrates();*****/
                    gettaxrates();
                    getfulltotal();
                }
                /*************/
                else
                {
                    grow.Cells[3].Text = "0";
                }
                /***********/

                string code = grow.Cells[4].Text;//get product code
                string status = grow.Cells[5].Text;//get product code
                double qtprate = Convert.ToDouble(grow.Cells[6].Text);//get qtprate
                if (!status.Equals("Y"))
                {
                    TextBox txtRaito = (TextBox)grow.FindControl("txtratio");
                    txtRaito.Enabled = false;
                    DropDownList ddlratio = (DropDownList)grow.FindControl("ddlratio");
                    ddlratio.Enabled = false;
                }
                else
                {
                    double val = 0;
                    string prd_codee = grow.Cells[4].Text;//get product code
                    if (prd_codee.Equals("NC"))
                    {
                        DropDownList ddlratio = (DropDownList)grow.FindControl("ddlratio");
                        val = Convert.ToDouble(ddlratio.SelectedValue.ToString());
                        grow.Cells[3].Text = (val * qtprate).ToString();

                    }
                    else 
                    {
                        TextBox txtRaito = (TextBox)grow.FindControl("txtratio");
                        val = Convert.ToDouble(grow.Cells[3].Text);
                        grow.Cells[3].Text = (val * qtprate).ToString();
                        txtRaito.Text = "0";
                    }
                }

            }

            grid1.FooterRow.Cells[2].Text = "Peril Total";
            grid1.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[2].Font.Bold = true;
            grid1.FooterRow.Cells[3].Text = totalPerilAmt.ToString("N2");
            grid1.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            grid1.FooterRow.Cells[3].Font.Bold = true;

            //grid1.Columns[4].Visible = false;
            //grid1.Columns[5].Visible = false;
            //grid1.Columns[6].Visible = false;

            /************************/

            con.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void gettaxrates()
    {
        string sqlquery = "select premium,polfee,nbl,adminf, round((premium+polfee+adminf+nbl)/100 *PK_uw_r_tax_validity.fn_get_tax_percentage('G',TRUNC(sysdate)),2) VAT " +
                          " from (  " +
                          " select t2.* ,  round((premium+polfee+adminf)/100 * PK_uw_r_tax_validity.fn_get_tax_percentage('B',TRUNC(sysdate)),2) nbl " +
                          " from ( " +
                          " select t1.*, round((premium)/100 * PK_uw_r_tax_validity.fn_get_tax_percentage('N',TRUNC(sysdate)),2) adminf " +
                          " from ( " +
                          " select '" + totalPerilAmt + "' premium " +
                          "        ,200 polfee " +
                          " from dual " +
                          " ) t1 ) t2 ) t3 ";


        try
        {
            db = new Connection();
            con = db.GetConnection;
            con.Open();
            cmd = new OracleCommand(sqlquery, con);
            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    //txtYear.Text = rd["year"].ToString();
                    //cmbYear.SelectedValue = rd["year"].ToString();
                    premium = Convert.ToDouble(rd["premium"].ToString());
                    polfee = Convert.ToDouble(rd["polfee"].ToString());
                    nbl = Convert.ToDouble(rd["nbl"].ToString());
                    adminf = Convert.ToDouble(rd["adminf"].ToString());
                    vat = Convert.ToDouble(rd["VAT"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();

            Table1.Visible = true;
            tblTotal.Visible = true;
        }

        //Label1.Text = premium.ToString();// + polfee + nbl + adminf + vat;
        Label2.Text = polfee.ToString("N2");// + polfee + nbl + adminf + vat;
        Label3.Text = nbl.ToString("N2");// + polfee + nbl + adminf + vat;
        Label4.Text = adminf.ToString("N2");// + polfee + nbl + adminf + vat;
        Label5.Text = vat.ToString("N2");// + polfee + nbl + adminf + vat;

    }

    protected void chkHeader_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)grid1.HeaderRow.FindControl("chkHeader");
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkGrid");
            TextBox txtRaito = (TextBox)row.FindControl("txtratio");
            DropDownList ddlratio = (DropDownList)row.FindControl("ddlratio");

            string status = row.Cells[5].Text;//get status
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
                //lblMessage.Text = "";

                /**************/
                if (ChkBoxRows.Checked && status.Equals("Y"))
                {
                    txtRaito.Enabled = true;
                    ddlratio.Enabled = true;
                }
                /***************/


            }
            else
            {
                ChkBoxRows.Checked = false;

                string aaa = row.Cells[4].Text;

                if (aaa.Equals("BP") || aaa.Equals("RF"))
                {
                    ChkBoxRows.Checked = true;
                }
                /**************/
                if (!ChkBoxRows.Checked && status.Equals("Y"))
                {
                    txtRaito.Enabled = false;
                    if (status.Equals("Y"))
                    {
                        txtRaito.Text = "0";
                        ddlratio.SelectedValue = "0";
                        row.Cells[3].Text = "0";
                    }
                }
                /***************/
            }
            ///********/
            // double ssss = Convert.ToDouble(grow.Cells[3].Text);

            getcheckvalue();

            if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("HP"))
            {
                row.Cells[3].Text = hpcheck.ToString("N2");
            }
            else if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("FD"))
            {
                row.Cells[3].Text = fdcheck.ToString("N2");
            }
            else if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("RC"))
            {
                row.Cells[3].Text = srcccheck.ToString("N2");
            }
            //else if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("BP"))
            //{
            //    row.Cells[3].Text = srcccheck.ToString("N2");
            //}
            else if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("EC"))
            {
                row.Cells[3].Text = eccheck.ToString("N2");
            }
            else if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("RF"))
            {
                row.Cells[3].Text = rfcheck.ToString("N2");
            }
            else if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("RM"))
            {
                row.Cells[3].Text = rmcheck.ToString("N2");
            }
            else if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("UC"))
            {
                row.Cells[3].Text = uccheck.ToString("N2");
            }
            else if (ChkBoxRows.Checked && row.Cells[4].Text.Equals("TAB"))
            {
                row.Cells[3].Text = tabcheck.ToString("N2");
            }
            ///************/
        }
        //getperiltotal();
        /****changed taxes according to the perils ****gettaxrates();*****/
        //gettaxrates();
        //getfulltotal();

        getratio();
    }

    protected void chkGrid_OnCheckedChanged(object sender, EventArgs e)
    {
       foreach (GridViewRow grow in grid1.Rows)
        {
            string status = grow.Cells[5].Text;//get product code
            CheckBox chkdel = (CheckBox)grow.FindControl("chkGrid");
            TextBox txtRaito = (TextBox)grow.FindControl("txtratio");
            DropDownList ddlratio = (DropDownList)grow.FindControl("ddlratio");

            if (chkdel.Checked && status.Equals("Y"))
            {
                txtRaito.Enabled = true;
                ddlratio.Enabled = true;
            }
            else
            {
                txtRaito.Enabled = false;
                ddlratio.Enabled = false;
                if (status.Equals("Y"))
                {
                    ddlratio.SelectedValue = "0";
                    txtRaito.Text = "0";
                    grow.Cells[3].Text = "0";
                }
               
            }
           ///********/
           // double ssss = Convert.ToDouble(grow.Cells[3].Text);

            getcheckvalue();

            if (chkdel.Checked && grow.Cells[4].Text.Equals("HP"))
            {
                grow.Cells[3].Text = hpcheck.ToString("N2");
            }
            else if (chkdel.Checked && grow.Cells[4].Text.Equals("FD"))
            {
                grow.Cells[3].Text = fdcheck.ToString("N2");
            }
            else if (chkdel.Checked && grow.Cells[4].Text.Equals("RC"))
            {
                grow.Cells[3].Text = srcccheck.ToString("N2");
            }
            //else if (chkdel.Checked && grow.Cells[4].Text.Equals("BP"))
            //{
            //    grow.Cells[3].Text = srcccheck.ToString("N2");
            //}
            else if (chkdel.Checked && grow.Cells[4].Text.Equals("EC"))
            {
                grow.Cells[3].Text = eccheck.ToString("N2");
            }
            else if (chkdel.Checked && grow.Cells[4].Text.Equals("RF"))
            {
                grow.Cells[3].Text = rfcheck.ToString("N2");
            }
            else if (chkdel.Checked && grow.Cells[4].Text.Equals("RM"))
            {
                grow.Cells[3].Text = rmcheck.ToString("N2");
            }
            else if (chkdel.Checked && grow.Cells[4].Text.Equals("UC"))
            {
                grow.Cells[3].Text = uccheck.ToString("N2");
            }
            else if (chkdel.Checked && grow.Cells[4].Text.Equals("TAB"))
            {
                grow.Cells[3].Text = tabcheck.ToString("N2");
            }
           ///************/
        }

        //getperiltotal();
       getratio();
    }

    /***************if check box is clicked, value will be desplayed 'getcheckvalue()' ***********/
    public void getcheckvalue() 
    {
        //double suminsured = 0.0;
        string product = cmbProduct.SelectedItem.Value.ToString();
        string pordType = cmbProductType.SelectedItem.Value.ToString();

        string sqlquery = "select qtp_rate,qtp_user_para,qtp_prl_code,qtp_prl_code_desc,(('" + Convert.ToDouble(txtSumInsured.Text.Trim()) + "'*qtp_rate)/100)+qtp_loading1+qtp_loading2 Amount from UW_QT_M_PRD_PERIL_RATE " +
                          " where qtp_prd_code='" + product + "' " +
                          " and qtp_type_code='" + pordType + "' ";
        // " and qtp_prl_code='BP'";

        try
        {
            db = new Connection();
            con = db.GetConnection;

            con.Open();

            cmd = new OracleCommand(sqlquery, con);
            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    if (rd[2].ToString() == "HP")
                    {
                        hpcheck = Convert.ToDouble(rd["Amount"].ToString());
                    }
                    else if (rd[2].ToString() == "FD")
                    {
                        fdcheck = Convert.ToDouble(rd["Amount"].ToString());
                    }
                    else if (rd[2].ToString() == "RC")
                    {
                        srcccheck = Convert.ToDouble(rd["Amount"].ToString());
                    }
                    else if (rd[2].ToString() == "EC")
                    {
                        eccheck = Convert.ToDouble(rd["Amount"].ToString());
                    }
                    else if (rd[2].ToString() == "RF")
                    {
                        rfcheck = Convert.ToDouble(rd["Amount"].ToString());
                    }
                    else if (rd[2].ToString() == "RM")
                    {
                        rmcheck = Convert.ToDouble(rd["Amount"].ToString());
                    }
                    else if (rd[2].ToString() == "UC")
                    {
                        uccheck = Convert.ToDouble(rd["Amount"].ToString());
                    }
                    else if (rd[2].ToString() == "TAB")
                    {
                        tabcheck = Convert.ToDouble(rd["Amount"].ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
            /***********************/
    }

    public void getperiltotal()
    {
        foreach (GridViewRow grow in grid1.Rows)
        {
            CheckBox chkdel = (CheckBox)grow.FindControl("chkGrid");
            //chkdel.Checked = true;

            if (chkdel.Checked)
            {
                totalPerilAmt += Convert.ToDouble(grow.Cells[3].Text);//dr["amount"]);row.Cells[0].Text
                cnt = cnt + 1;

                /****changed taxes according to the perils ****gettaxrates();*****/
                gettaxrates();
                getfulltotal();
            }
            else 
            {
                grow.Cells[3].Text = "0.00";
            }

        }

        grid1.FooterRow.Cells[2].Text = "Peril Total";
        grid1.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        grid1.FooterRow.Cells[2].Font.Bold = true;
        grid1.FooterRow.Cells[3].Text = totalPerilAmt.ToString("N2");
        grid1.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        grid1.FooterRow.Cells[3].Font.Bold = true;

    }

    public void getfulltotal()
    {
        finaltot = premium + polfee + nbl + adminf + vat;

        lblfinalTot.Text = finaltot.ToString("N2");
    }

    protected void btnCalRatio_Click(object sender, EventArgs e)
    {
        getratio();
    }

    public void getratio() 
    {
        double numofUnit;
        double amount;
        grid1.Columns[4].Visible = true;
        grid1.Columns[5].Visible = true;
        grid1.Columns[6].Visible = true;


        string product = cmbProduct.SelectedItem.Value.ToString();
        string pordType = cmbProductType.SelectedItem.Value.ToString();
        double suminsured = Convert.ToDouble(txtSumInsured.Text);

        //if (txtratio.text == "")
        //{

        //}
        for (int i = 0; i < grid1.Rows.Count; i++)
        {
            GridViewRow gRow = grid1.Rows[i];

            string perilcode = gRow.Cells[4].Text;//get product code
            string s;

            if (perilcode.Equals("NC"))
            {
                DropDownList ddlratio = (DropDownList)gRow.FindControl("ddlratio");
                s = ddlratio.SelectedValue.ToString();
            }
            else
            {
                TextBox txtbox1 = (TextBox)gRow.FindControl("txtratio");
                s = txtbox1.Text.Trim();
            }

            if (!s.Equals(""))
            {
                numofUnit = Convert.ToDouble(s);

                /****************/
                if (perilcode.Equals("NC"))
                {
                    amount = getNCB(product, numofUnit);
                    gRow.Cells[3].Text = amount.ToString("N2");
                }
                else
                {
                    amount = getUnitsthroughPackage(product, pordType, perilcode, suminsured, numofUnit);
                    gRow.Cells[3].Text = amount.ToString("N2");
                }
                /***************/



            }


        }

        getperiltotal();
        gettaxrates();
        getfulltotal();

        grid1.Columns[4].Visible = false;
        grid1.Columns[5].Visible = false;
        grid1.Columns[6].Visible = false;

    }

    public double getNCB(string product,double numofUnit) 
    {
  

        for (int i = 0; i < grid1.Rows.Count; i++)
        {
            GridViewRow gRow = grid1.Rows[i];
            CheckBox chkdel = (CheckBox)gRow.FindControl("chkGrid");
            
            string perilcode = gRow.Cells[4].Text;//get product code

            if (chkdel.Checked && perilcode == "BP")
	        {
		        bp=Convert.ToDouble(gRow.Cells[3].Text);
	        }
            else if (chkdel.Checked && perilcode == "HP")
            {
                hp=Convert.ToDouble(gRow.Cells[3].Text);
            }
            else if (chkdel.Checked && perilcode == "P4")
            {
                p4=Convert.ToDouble(gRow.Cells[3].Text);
            }
         }
        
        
        
        string sq = "SELECT " +
            "nvl(to_number(pk_uw_qt_m_prd_peril_rate.fn_get_qot_NCB_premium('" + product + "','" + bp + "','" + hp + "'," + p4 + ",0,0,'" + numofUnit + "')),0)value " +
                         //   pk_uw_qt_m_prd_peril_rate.fn_get_qot_NCB_premium('1A',10000,5000,0,0,0,15)
            "FROM DUAL";

        double amt = 0;

        try
        {
            db = new Connection();
            con = db.GetConnection;
            con.Open();
            OracleCommand cmd1 = new OracleCommand(sq, con);
            OracleDataReader rd1 = cmd1.ExecuteReader();

            //if (rd1.HasRows)
            //{
            while (rd1.Read())
            {
                amt = Convert.ToDouble("-" + rd1[0]);
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

        return amt;
    }

    public double getUnitsthroughPackage(string product, string pordType, string perilcode, double suminsured, double numofUnit)
    {
        string sq = "SELECT "+
            "nvl(to_number(pk_uw_qt_m_prd_peril_rate.fn_get_qot_prl_premium('" + product + "','" + pordType + "','" + perilcode + "'," + suminsured + ",'" + numofUnit + "')),0)value " +
            "FROM DUAL";

        double amt=0;

        try
        {
            db = new Connection();
            con = db.GetConnection;
            con.Open();
            OracleCommand cmd1 = new OracleCommand(sq, con);
            OracleDataReader rd1 = cmd1.ExecuteReader();

            //if (rd1.HasRows)
            //{
                while (rd1.Read())
                {
                    amt = Convert.ToDouble(rd1[0]);
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

        return amt;
    }
    
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {
        getValues();

        Session["product"] = cmbProduct.SelectedItem.ToString();
        Session["productType"] = cmbProductType.SelectedItem.ToString();
        Session["sumins"] = Convert.ToDouble(txtSumInsured.Text);
        Session["name"] = TextBoxName.Text;
        Session["vno"] = TextBoxVehicle.Text;

        Session["perilnames"] = init_values;
        Session["perilvalues"] = init_perils;

        Session["totalPerilAmt"] = grid1.FooterRow.Cells[3].Text;//totalPerilAmt;
      //  Session["premium"] = Label2.Text;//premium;
        Session["polfee"] = Label2.Text;
        Session["nbl"] = Label3.Text;
        Session["adminf"] = Label4.Text;
        Session["vat"] = Label5.Text;
        Session["finaltot"] = lblfinalTot.Text;//finaltot;

        //Server.Transfer("report.aspx?user=" + TextBoxUser.Text);
        Response.Redirect("report.aspx?user=" + TextBoxUser.Text);


        

    }
    
    public void getValues() 
    {
        string product = cmbProduct.SelectedItem.Value.ToString();
        string pordType = cmbProductType.SelectedItem.Value.ToString();

        try
        {
            double suminsured = Convert.ToDouble(txtSumInsured.Text);
            double numofUnit = 0;

            foreach (GridViewRow grow in grid1.Rows)
            {
               string aaa = grow.Cells[4].Text;

               CheckBox chkdel = (CheckBox)grow.FindControl("chkGrid");
               chkdel.Checked = true;

                /********************/


               string perilcode = grow.Cells[4].Text;//get product code
               string ratio;

               if (perilcode.Equals("NC"))
               {
                   DropDownList ddlratio = (DropDownList)grow.FindControl("ddlratio");
                   ratio = ddlratio.SelectedValue.ToString();
               }
               else
               {
                   TextBox txtbox1 = (TextBox)grow.FindControl("txtratio");
                   ratio = txtbox1.Text.Trim();
               }


                /*****************/


                if (!ratio.Equals(""))
                {
                    numofUnit = Convert.ToDouble(ratio);
                }

                string value = grow.Cells[3].Text;
                string valueperil = grow.Cells[1].Text;
                init_values.Add(value);
                init_perils.Add(valueperil);             
    
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
       
    }

    //protected void txtratio_TextChanged(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow grow in grid1.Rows)
    //    {
    //        string prd_code = grow.Cells[4].Text;//get product code
    //        CheckBox chkdel = (CheckBox)grow.FindControl("chkGrid");
    //        TextBox txtRaito = (TextBox)grow.FindControl("txtratio");
    //        if (chkdel.Checked && prd_code.Equals("NC"))
    //        {
    //            //txtRaito.Enabled = true;
    //        }
    //        else
    //        {
    //            //txtRaito.Enabled = false;
    //            //if (status.Equals("Y"))
    //            //{
    //            //    txtRaito.Text = "0";
    //            //    grow.Cells[3].Text = "0";
    //            //}
    //        }
    //    }
    //}

    protected void ddlratio_SelectedIndexChanged(object sender, EventArgs e)
    {
        getratio();
    }
}