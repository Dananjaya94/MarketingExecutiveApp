using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        //TextBoxImei.Text = HttpUtility.UrlDecode(Request.QueryString["ic"]).Trim().ToUpper().ToString();
        //TextBoxepf.Text = HttpUtility.UrlDecode(Request.QueryString["epf"]).Trim().ToUpper().ToString();
        if (!this.IsPostBack)
        {
            //if (Session["userName"] == null || Session["pwd"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}


           

        }
        //lblusername.Text = Session["userName"].ToString();
    }




}