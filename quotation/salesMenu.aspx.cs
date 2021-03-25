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
        if (!this.IsPostBack)
        {
            //if (Session["sfc_code"].ToString() != "08370" && Session["sfc_code"].ToString() != "51333")
            //{

            //    Response.Redirect("Home.aspx");

            //}
            //else {
            //}

        }
        //lblusername.Text = Session["userName"].ToString();
    }
}