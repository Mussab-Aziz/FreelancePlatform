using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class JobRepository
{
    private string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

    public void PostJob(int clientId, string title, string description, decimal price, int duration)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Jobs (ClientId, Title, Description, Price, Duration) VALUES (@ClientId, @Title, @Description, @Price, @Duration)", conn);
            cmd.Parameters.AddWithValue("@ClientId", clientId);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Duration", duration);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public DataTable GetJobsByClientId(int clientId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT JobId, Title FROM Jobs WHERE ClientId = @ClientId", conn);
            cmd.Parameters.AddWithValue("@ClientId", clientId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public bool DeleteJob(int jobId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Jobs WHERE JobId = @JobId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@JobId", jobId);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
    }

    public DataTable GetApplicationsByJobId(int jobId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT a.ApplicationId, a.FreelancerId, u.Name as FreelancerName, a.Status, a.CoverLetter
            FROM Applications a
            INNER JOIN Users u ON a.FreelancerId = u.UserId
            WHERE a.JobId = @JobId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@JobId", jobId);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public DataTable GetJobs()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Jobs", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
    public bool ApplyToJob(int freelancerId, int jobId, string coverLetter)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Applications WHERE FreelancerId = @FreelancerId AND JobId = @JobId", conn);
            checkCmd.Parameters.AddWithValue("@FreelancerId", freelancerId);
            checkCmd.Parameters.AddWithValue("@JobId", jobId);
            conn.Open();
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                return true;
            }

            conn.Close();

            SqlCommand insertCmd = new SqlCommand("INSERT INTO Applications (FreelancerId, JobId, Status, CoverLetter) VALUES (@FreelancerId, @JobId, 'Pending', @CoverLetter)", conn);
            insertCmd.Parameters.AddWithValue("@FreelancerId", freelancerId);
            insertCmd.Parameters.AddWithValue("@JobId", jobId);
            insertCmd.Parameters.AddWithValue("@CoverLetter", coverLetter);
            conn.Open();
            insertCmd.ExecuteNonQuery();
            return false;
        }
    }

}

