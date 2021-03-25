using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Configuration;

public partial class report : System.Web.UI.Page
{
    DataTable dt = null;
    ArrayList init_values;
    ArrayList init_perils;
    ArrayList init_code;

    string totalPerilAmt;

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!Request.FilePath.Contains("Error"))
        {
            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
            }
            if (strPreviousPage == "")
            {
                Response.Redirect("Error.aspx");
            }
        }

        ClearTables();

        if (ViewState["Details"] == null)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Peril Description");
            datatable.Columns.Add("Perils");
            datatable.Columns.Add("Value");
            ViewState["Details"] = datatable;
        }


        string product=Session["product"].ToString();
        string productType = Session["productType"].ToString();
        string sumIns = Session["sumins"].ToString();
        string name = Session["name"].ToString();
        string vehicle = Session["vno"].ToString();

        totalPerilAmt = Session["totalPerilAmt"].ToString();
        //string premium = Session["premium"].ToString();
        string polfee = Session["polfee"].ToString();
        string nbl = Session["nbl"].ToString();
        string adminf = Session["adminf"].ToString();
        string vat = Session["vat"].ToString();
        string finaltot = Session["finaltot"].ToString();

        string sfname=Session["sfname"].ToString();
        string sfcode=Session["sfmobile"].ToString();

        init_values = (ArrayList)Session["perilnames"];
        init_perils = (ArrayList)Session["perilvalues"];
        init_code = (ArrayList)Session["perilcode"];

        LabelName.Text      = name;
        LabelProduct.Text   = product;
        LabelPType.Text     = productType;
        LabelVehicle.Text   = vehicle;
        LabelSumInsured.Text = sumIns;

        LabelpolicyFee.Text = polfee;
        LabelVat.Text       = vat;
        LabelAdminFee.Text  = adminf;
        LabelNBT.Text       = nbl;

        lblsfname.Text = sfname;
        lblsfmobile.Text = sfcode;

        //LabelPerilTotal.Text = totalPerilAmt;
        LabelTotal.Text = finaltot;

        FillPerils();
        if (Session["ncb_value"] != null) { 
        
        int ncb_vale=Convert.ToInt32(Session["ncb_value"].ToString());
        if (ncb_vale<=35)
        {
            btnExport.Visible = true;
        }
        else
        {
            btnExport.Visible = false;
        }

        }

    }

    private void ClearTables()
    {
        ViewState["Details"] = null;
        GridViewDetails.DataSource = null;
        GridViewDetails.DataBind();

    }

    private void FillPerils()
    {
        dt = (DataTable)ViewState["Details"];

        for (int j = 0; j < init_values.Count; j++)
        {
            if (init_values[j].ToString() == "0" || init_values[j].ToString() == "0.0" || init_values[j].ToString() == "0.00")
            {

            }
            else
            {
                dt.Rows.Add(init_perils[j].ToString(),init_values[j].ToString(),init_code[j].ToString());
            }
        }
        
        ViewState["Details"] = dt;
        GridViewDetails.DataSource = dt;       
        GridViewDetails.DataBind();
        
       // GridViewDetails.Columns[3].Visible = false;

        //BorderStyle="Solid" GridLines="Both"

        //GridViewDetails.GridLines="Both";
        GridViewDetails.FooterRow.Cells[0].Text = "Peril Total";
        GridViewDetails.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
        GridViewDetails.FooterRow.Cells[0].Font.Bold = true;
        GridViewDetails.FooterRow.Cells[1].Text = totalPerilAmt;
        GridViewDetails.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        GridViewDetails.FooterRow.Cells[1].Font.Bold = true;

        GridViewDetails.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        GridViewDetails.HeaderRow.Cells[0].Font.Bold = true;
        GridViewDetails.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
        GridViewDetails.HeaderRow.Cells[1].Font.Bold = true;
    }

    protected void GridViewDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        
            int i = ((DataTable)((GridView)sender).DataSource).Columns.IndexOf("Value");
            for (int j = 0; j < e.Row.Cells.Count; j++)
            {

                if (j == i-1)
                {
                    e.Row.Cells[j].HorizontalAlign = HorizontalAlign.Right;
                }
                else
                {
                    e.Row.Cells[j].HorizontalAlign = HorizontalAlign.Left;
                }
            }

            if (e.Row.Cells[2].Text.Contains("NC"))
            {
                e.Row.Cells[0].Font.Bold = true;
                //e.Row.Cells[1].Font.Bold = true;
            }

        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Premium Indicator.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        employeelistDiv.RenderControl(htmlTextWriter);

        StringReader stringReader = new StringReader(stringWriter.ToString());
        Document Doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
        HTMLWorker htmlparser = new HTMLWorker(Doc);
        PdfWriter.GetInstance(Doc, Response.OutputStream);

        Doc.Open();
        htmlparser.Parse(stringReader);
        Doc.Close();
        Response.Write(Doc);

        Response.End();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    protected void GridViewDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
    }
}