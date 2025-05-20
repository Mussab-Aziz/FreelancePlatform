using System;

    public partial class PostJob : System.Web.UI.Page
    {

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ClientDashboard.aspx");
        }

    protected void btnPost_Click(object sender, EventArgs e)
{
    try
    {

    if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
    string.IsNullOrWhiteSpace(txtDescription.Text) ||
    string.IsNullOrWhiteSpace(txtPrice.Text) ||
    string.IsNullOrWhiteSpace(txtDuration.Text))
    {
    lblMessage.Text = "All fields are required.";
    lblMessage.ForeColor = System.Drawing.Color.Red;
    return;
}

        
        string title = txtTitle.Text.Trim();
        string description = txtDescription.Text.Trim();
        decimal price = Convert.ToDecimal(txtPrice.Text);
        int duration = Convert.ToInt32(txtDuration.Text);

        
        if (Session["UserId"] != null)
        {
            int clientId = Convert.ToInt32(Session["UserId"]);

            
            JobRepository jobRepo = new JobRepository();
            jobRepo.PostJob(clientId, title, description, price, duration);

            lblMessage.Text = "Job posted successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtDuration.Text = "";
        }
        else
        {
            lblMessage.Text = "Session expired. Please log in again.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
    catch (FormatException)
    {
        lblMessage.Text = "Price and Duration must be valid numbers.";
        lblMessage.ForeColor = System.Drawing.Color.Red;
    }
    catch (Exception ex)
    {
        lblMessage.Text = "Error: " + ex.Message;
        lblMessage.ForeColor = System.Drawing.Color.Red;
    }
}
}