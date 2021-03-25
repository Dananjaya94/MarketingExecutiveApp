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


    int a;

    protected void Page_Load(object sender, EventArgs e)
    {

        // String username;
        TextBoxbranch.Text = Session["sfc_brn_code"].ToString();
        TextBoxmecode.Text = Session["sfc_code"].ToString();
       

    }

    protected void getMeData()
    {

        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;
      
        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_me_sales_plan_header";


        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);
        prm1.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(prm1);


        OracleParameter prm2 = new OracleParameter("wkmecode", OracleType.VarChar);

        prm2.Direction = ParameterDirection.Input;

        prm2.Value = TextBoxmecode.Text;

        cmd.Parameters.Add(prm2);


        OracleParameter prm3 = new OracleParameter("wkmebrn", OracleType.VarChar);

        prm3.Direction = ParameterDirection.Input;

        prm3.Value = TextBoxbranch.Text.ToUpper();

        cmd.Parameters.Add(prm3);


        OracleParameter prm4 = new OracleParameter("wktype", OracleType.VarChar);

        prm4.Direction = ParameterDirection.Input;

        prm4.Value = DropDownListtype.SelectedValue;

        cmd.Parameters.Add(prm4);

        OracleParameter prm5 = new OracleParameter("wk_year", OracleType.VarChar);

        prm5.Direction = ParameterDirection.Input;

        prm5.Value = Convert.ToDateTime(TextBoxyear.Text).ToString("yyy").ToString();

        cmd.Parameters.Add(prm5);



        OracleParameter prm6 = new OracleParameter("wk_month", OracleType.VarChar);

        prm6.Direction = ParameterDirection.Input;

        prm6.Value = Convert.ToDateTime(TextBoxyear.Text).ToString("MM").ToString();

        cmd.Parameters.Add(prm6);


        try
        {
            conn.Open();
            //OracleDataAdapter adp = new OracleDataAdapter(cmd);
            OracleDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows) { 
            while (rd.Read())
            {
                
                TextBoxmecode.Text = rd[0].ToString();
                TextBoxmename.Text = rd[1].ToString();
                TextBoxtype.Text = rd[2].ToString();
                TextBoxviewyear.Text = rd[3].ToString();
                TextBoxmonth.Text = rd[4].ToString();
                TextBoxnewplan.Text = rd[5].ToString();
                TextBoxrenewalplan.Text = rd[6].ToString();
                TextBoxtotal.Text = rd[7].ToString();
                TextBoxlastyear.Text = rd[8].ToString();
                TextBoxachievement.Text = rd[9].ToString();
                TextBoxgrowth.Text = rd[10].ToString();

            }
            }
 

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }

    }



    protected void getMesaledata()
    {

   


        OracleConnection conn = new OracleConnection(Connection.con_str_oracle_cicco);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;

        //cmd.Parameters.Clear();
        cmd.CommandText = "pk_app_me_reports.open_me_sales_plan_det";


        OracleParameter prm1 = new OracleParameter("IO_CURSOR", OracleType.Cursor);

        prm1.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(prm1);


        OracleParameter prm2 = new OracleParameter("wkmecode", OracleType.VarChar);

        prm2.Direction = ParameterDirection.Input;

        prm2.Value = TextBoxmecode.Text;

        cmd.Parameters.Add(prm2);


        OracleParameter prm3 = new OracleParameter("wkmebrn", OracleType.VarChar);

        prm3.Direction = ParameterDirection.Input;

        prm3.Value = TextBoxbranch.Text.ToUpper();

        cmd.Parameters.Add(prm3);


        OracleParameter prm4 = new OracleParameter("wktype", OracleType.VarChar);

        prm4.Direction = ParameterDirection.Input;

        prm4.Value = DropDownListtype.SelectedValue;

        cmd.Parameters.Add(prm4);

        OracleParameter prm5 = new OracleParameter("wk_year", OracleType.VarChar);

        prm5.Direction = ParameterDirection.Input;

        prm5.Value = Convert.ToDateTime(TextBoxyear.Text).ToString("yyy").ToString();

        cmd.Parameters.Add(prm5);



        OracleParameter prm6 = new OracleParameter("wk_month", OracleType.VarChar);

        prm6.Direction = ParameterDirection.Input;

        prm6.Value = Convert.ToDateTime(TextBoxyear.Text).ToString("MM").ToString();

        cmd.Parameters.Add(prm6);

        try
        {
            conn.Open();
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();

            adp.Fill(dt);

            grid1.DataSource = dt;
            grid1.DataBind();

            //conn.Open();
            //grid1.EmptyDataText = "No Records Found";

            //grid1.DataSource = cmd.ExecuteReader();

            //grid1.DataBind();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }

    }



    protected void btngetMe_Click(object sender, EventArgs e)
    {
        if (TextBoxyear.Text != "" && DropDownListtype.SelectedIndex != 0) { 
        getMeData();
        getMesaledata();

        }
    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Buttonback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/salesMenu.aspx");
    }
}