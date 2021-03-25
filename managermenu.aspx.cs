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
            if (Session["posno"].ToString() != "1" && Session["posno"].ToString() != "2" && Session["posno"].ToString() != "3")
            {
                Response.Redirect("HomeSecond.aspx");
            }
            else
            {
            }
        }

        //lblusername.Text = Session["userName"].ToString();
    }
}