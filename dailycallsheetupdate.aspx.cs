using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dailycallsheetupdate : System.Web.UI.Page
{

    string VISIT_DATE;
    string INSURED;
    string MOBILE_NO;
    string ADDRESS;
    string OCCUPATION;
    string PRESENT_INSURED;
    string SUM_INSURED;
    string PREMIUM;
    string PRODUCT;
    string RENEWAL_DATE;
    string FOLLOWUP_DATE;
    string RISK_NAME;
    string REMARKS;
    string BUSINESS_CLOSED;
    string CLOSED_DATE;
    string POLICY_NO;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.PreviousPage != null)
        {
            int rowIndex = int.Parse(Request.QueryString["RowIndex"]);
            GridView GridView1 = (GridView)this.Page.PreviousPage.FindControl("grid1");
            GridViewRow row = GridView1.Rows[rowIndex];
            //lblId.Text = row.Cells[0].Text;
            //lblName.Text = (row.FindControl("lblName") as Label).Text;
            //lblCountry.Text = row.Cells[2].Text;

            VISIT_DATE = row.Cells[1].Text;
            INSURED = row.Cells[2].Text;
            MOBILE_NO = row.Cells[3].Text;
            ADDRESS = row.Cells[4].Text;
            OCCUPATION = row.Cells[5].Text;
            PRESENT_INSURED = row.Cells[6].Text;
            SUM_INSURED = row.Cells[7].Text;
            PREMIUM = row.Cells[8].Text;
            PRODUCT = row.Cells[9].Text;
            RENEWAL_DATE = row.Cells[10].Text;
            FOLLOWUP_DATE = row.Cells[11].Text;
            RISK_NAME = row.Cells[12].Text;
            REMARKS = row.Cells[13].Text;
            BUSINESS_CLOSED = row.Cells[14].Text;
            CLOSED_DATE = row.Cells[15].Text;
            POLICY_NO = row.Cells[16].Text;
        }
    }

}