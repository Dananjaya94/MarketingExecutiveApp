using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    OracleConnection conn = null;
    OracleCommand command, cmd = null;
    Object obj = null;
    string sfc_brn_code, sfc_code = null;
    int positionno = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
       txtbrncode.Text= Session["sfc_brn_code"].ToString();
       txtmecode.Text= Session["sfc_code"].ToString();
       txtposno.Text= Session["posno"].ToString();
       txtimei.Text= Session["imei"].ToString();


    }

    protected void Anchor_Click(Object sender, EventArgs e)
    {
        //Code which needs to be executed on serverside
        //Response.Write("<script>alert('Server Side Code is Executed')</script>");
        //Session["sfc_brn_code"] = "CO0011";

        string result = Session["sfc_brn_code"].ToString().Substring(0, 2);

        if (result == "CO")
        {

            Response.Redirect("http://202.124.181.76/quotrequest/login.aspx");
        }
        else
        {
            Response.Redirect("http://202.124.181.76/underwritereq/loginpub.aspx?sfc=" + Session["sfc_code"].ToString() + "&type=Q");
        }
    }


    protected void techsupport_Click(Object sender, EventArgs e)
    {

            //Response.Write("<script>alert('Server Side Code is Executed')</script>");
            //Response.Redirect("http://10.10.1.220/quotrequest/login.aspx"); 
            //Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequest.aspx");
            Response.Redirect("http://202.124.181.76/techsupport/home.aspx?me=" + txtmecode.Text+ "&imei="+txtimei.Text+"&pos="+txtposno.Text);


    }


    protected void techcenter_Click(Object sender, EventArgs e)
    {

        //Response.Write("<script>alert('Server Side Code is Executed')</script>");
        //Response.Redirect("http://10.10.1.220/quotrequest/login.aspx"); 
        //Response.Redirect("http://202.124.181.76/renewalrequest/renewalrequest.aspx");
        Response.Redirect("techcenteremenu.aspx");


    }

}