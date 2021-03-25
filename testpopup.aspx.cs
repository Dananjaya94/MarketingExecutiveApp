using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testpopup : System.Web.UI.Page
{
    Connection db;
    OracleConnection con;
    OracleCommand cmd;
    OracleDataReader rd;
    double purchasecost = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.getRepairDetails();

        }
    }

    public void getRepairDetails()
    {
        string sqlquery = "select asst_rpr_serial_no,TO_CHAR(asst_rpr_from_date,'dd-Mon-yyyy') FROM_DATE,TO_CHAR(asst_rpr_to_date,'dd-Mon-yyyy') TO_DATE " +
                          ",asst_rpr_remarks REPAIR_DESCRIPTION,to_char(asst_rpr_cost,'999,999,999.99') REPAIR_COST,asst_rpr_person REPAIR_PERSON " +
                          " from it_t_asst_repair_det ";

        try
        {
            con = new OracleConnection(Connection.con_str_oracle_cicco);
            con.Open();

            OracleDataAdapter adp = new OracleDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            grdrepdata.DataSource = dt;
            grdrepdata.DataBind();
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
}