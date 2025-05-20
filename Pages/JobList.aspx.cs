using System;
using System.Data;

public partial class JobList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindJobs();
        }
    }

    private void BindJobs()
    {
        JobRepository repo = new JobRepository();
        DataTable dt = repo.GetJobs();
        gvJobs.DataSource = dt;
        gvJobs.DataBind();
    }

    protected void gvJobs_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "OpenCoverLetter")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int jobId = Convert.ToInt32(gvJobs.DataKeys[rowIndex].Value);
            hfJobId.Value = jobId.ToString();
            pnlCoverLetter.Visible = true;
        }
    }

    protected void btnSubmitApplication_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            int freelancerId = Convert.ToInt32(Session["UserId"]);
            int jobId = Convert.ToInt32(hfJobId.Value);
            string coverLetter = txtCoverLetter.Text;

            JobRepository repo = new JobRepository();
            bool alreadyApplied = repo.ApplyToJob(freelancerId, jobId, coverLetter);

            lblMessage.Text = alreadyApplied
                ? "You have already applied to this job."
                : "Application submitted successfully.";

            pnlCoverLetter.Visible = false;
            txtCoverLetter.Text = "";
        }
        else
        {
            lblMessage.Text = "Please log in to apply.";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlCoverLetter.Visible = false;
        txtCoverLetter.Text = "";
    }

    protected void btnEditProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/FreelancerProfile.aspx");
    }

}
