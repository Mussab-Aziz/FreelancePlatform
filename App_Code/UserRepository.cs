using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class UserRepository
{
    private string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

    public void RegisterUser(string name, string email, string password, string role)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Role", role);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public DataTable Login(string email, string password)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email=@Email AND Password=@Password", conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
