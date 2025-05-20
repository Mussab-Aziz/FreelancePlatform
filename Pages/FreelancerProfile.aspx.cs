using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class FreelancerProfile : System.Web.UI.Page
{
    private string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        if (Session["UserId"] != null)
        {
            LoadProfile(Convert.ToInt32(Session["UserId"]));
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}

protected void LoadProfile(int userId)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM FreelancerProfiles WHERE UserId = @UserId", conn);
        cmd.Parameters.AddWithValue("@UserId", userId);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            txtSkills.Text = reader["Skills"].ToString();
            txtRate.Text = reader["HourlyRate"].ToString();
            ddlStatus.SelectedValue = reader["Status"].ToString();
        }
    }
}
protected void btnBack_Click(object sender, EventArgs e)
{
    Response.Redirect("~/Pages/JobList.aspx");
}

protected void btnSave_Click(object sender, EventArgs e)
{
    if (Session["UserId"] != null)
    {
        int userId = Convert.ToInt32(Session["UserId"]);
        string skills = txtSkills.Text;
        decimal rate = decimal.Parse(txtRate.Text);
        string status = ddlStatus.SelectedValue;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(@"
                IF EXISTS (SELECT 1 FROM FreelancerProfiles WHERE UserId = @UserId)
                    UPDATE FreelancerProfiles
                    SET Skills = @Skills, HourlyRate = @Rate, Status = @Status
                    WHERE UserId = @UserId
                ELSE
                    INSERT INTO FreelancerProfiles (UserId, Skills, HourlyRate, Status)
                    VALUES (@UserId, @Skills, @Rate, @Status)", conn);

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Skills", skills);
            cmd.Parameters.AddWithValue("@Rate", rate);
            cmd.Parameters.AddWithValue("@Status", status);

            conn.Open();
            cmd.ExecuteNonQuery();
            lblMessage.Text = "Profile saved successfully.";
        }


    }
}
protected void btnGoToJobs_Click(object sender, EventArgs e)
{
    Response.Redirect("~/Pages/JobList.aspx");
}
}