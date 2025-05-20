using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class ViewApplications : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadClientJobs();
        }
    }

    private void LoadClientJobs()
    {
        string clientIdStr = Session["UserId"] != null ? Session["UserId"].ToString() : string.Empty;

        if (string.IsNullOrEmpty(clientIdStr))
        {
            Response.Redirect("~/Login.aspx");
            return;
        }

        int clientId;
        if (!int.TryParse(clientIdStr, out clientId))
        {
            lblMessage.Text = "Invalid client ID.";
            return;
        }

        JobRepository repo = new JobRepository();

        
        DataTable jobs = repo.GetJobs();

        DataView dv = new DataView(jobs);
        dv.RowFilter = "ClientId = " + clientId;

        ddlJobs.DataSource = dv;
        ddlJobs.DataTextField = "Title";
        ddlJobs.DataValueField = "JobId";
        ddlJobs.DataBind();

        ddlJobs.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select a Job --", ""));
    }


    protected void ddlJobs_SelectedIndexChanged(object sender, EventArgs e)
    {
        int jobId;
        if (int.TryParse(ddlJobs.SelectedValue, out jobId))
        {
            LoadApplications(jobId);
        }
        else
        {
            gvApplications.DataSource = null;
            gvApplications.DataBind();
            lblMessage.Text = "Please select a valid job.";
        }
    }

    private void LoadApplications(int jobId)
    {
        JobRepository repo = new JobRepository();
        DataTable dtApplications = repo.GetApplicationsByJobId(jobId);

        if (dtApplications.Rows.Count > 0)
        {
            gvApplications.DataSource = dtApplications;
            gvApplications.DataBind();
            lblMessage.Text = "";
        }
        else
        {
            gvApplications.DataSource = null;
            gvApplications.DataBind();
            lblMessage.Text = "No applications found for this job.";
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ClientDashboard.aspx");
    }
}
