using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;


public partial class DeleteJob : System.Web.UI.Page
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
        if (Session["UserId"] == null) 
            return;

        int clientId;
        if (!int.TryParse(Session["UserId"].ToString(), out clientId))
            return;

        JobRepository repo = new JobRepository();
        DataTable dt = repo.GetJobsByClientId(clientId);

        ddlJobs.DataSource = dt;
        ddlJobs.DataTextField = "Title";
        ddlJobs.DataValueField = "JobId";
        ddlJobs.DataBind();

        ddlJobs.Items.Insert(0, new ListItem("-- Select a Job --", ""));
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ClientDashboard.aspx");
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int jobId;
        if (int.TryParse(ddlJobs.SelectedValue, out jobId))
        {
            JobRepository repo = new JobRepository();
            bool deleted = repo.DeleteJob(jobId);

            lblMessage.Text = deleted ? "Job deleted successfully." : "Failed to delete the job.";
            LoadClientJobs();
        }
        else
        {
            lblMessage.Text = "Please select a job to delete.";
        }
    }

}
