using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class Home : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!this.IsPostBack)
        //{
        //    //if (Session["userName"] == null || Session["pwd"] == null)
        //    //{
        //    //    Response.Redirect("Login.aspx");
        //    //}

        //}
        //lblusername.Text = Session["userName"].ToString();

       // HtmlAnchor btn = buttonreg as HtmlAnchor;
       // btn.ServerClick += new EventHandler(pendocregister_Click);
    }




    protected void pendocregister_Click(Object sender, EventArgs e)
    {
        //Response.Write("<script>alert('Server Side Code is Executed')</script>");
        //Response.Redirect("http://10.10.1.220/quotrequest/login.aspx"); 
          Response.Redirect("http://www.ceyins.lk/he01/index.php?mee=" + Session["sfc_code"].ToString() + "");
        //Response.Redirect("http://202.124.181.76/underwritereq/loginpub.aspx?sfc=" + Session["sfc_code"].ToString() + "&lgbran=" + Session["sfc_brn_code"].ToString() + "&type=Q");
    }
}