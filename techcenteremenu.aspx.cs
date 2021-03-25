using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class techcenteremenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void quotreqest_Click(Object sender, EventArgs e)
    {
        //Response.Write("<script>alert('Server Side Code is Executed')</script>");
        //Response.Redirect("http://10.10.1.220/quotrequest/login.aspx"); 
        //Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequest.aspx");
        Response.Redirect("http://202.124.181.76/underwritereq/loginpub.aspx?sfc=" + Session["sfc_code"].ToString() + "&lgbran=" + Session["sfc_brn_code"].ToString() + "&type=Q");
    }


    protected void newreqest_Click(Object sender, EventArgs e)
    {
        //Response.Write("<script>alert('Server Side Code is Executed')</script>");
        //Response.Redirect("http://10.10.1.220/quotrequest/login.aspx"); 
        //Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequest.aspx");
        Response.Redirect("http://202.124.181.76/underwritereq/loginpub.aspx?sfc=" + Session["sfc_code"].ToString() + "&lgbran=" + Session["sfc_brn_code"].ToString() + "&type=N");
    }

    protected void renewalreqest_Click(Object sender, EventArgs e)
    {
        //Response.Write("<script>alert('Server Side Code is Executed')</script>");
        //Response.Redirect("http://10.10.1.220/quotrequest/login.aspx"); 
        Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequestpub.aspx?branch=" + Session["sfc_brn_code"].ToString() + "&sfc_code=" + Session["sfc_code"].ToString() + "");
        //Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequestpub.aspx");
    }

    protected void polammendment_Click(Object sender, EventArgs e)
    {
        //Response.Write("<script>alert('Server Side Code is Executed')</script>");
        //Response.Redirect("http://10.10.1.220/quotrequest/login.aspx"); 
        //Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequest.aspx");
        Response.Redirect("http://202.124.181.76/underwritereq/pubpolammendment.aspx?brncode=" + Session["sfc_brn_code"].ToString() + "&sfc_code=" + Session["sfc_code"].ToString() + "");
    }
}