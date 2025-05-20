using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["Role"] == null || Session["Role"].ToString() != "Client")
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnPostJob_Click(object sender, EventArgs e)
    {
        Response.Redirect("PostJob.aspx");
    }

    protected void btnViewApplications_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewApplications.aspx");
    }

    protected void btnDeleteJob_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeleteJob.aspx");
    }
}
