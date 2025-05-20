using System;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserRepository repo = new UserRepository();
        DataTable dt = repo.Login(txtEmail.Text, txtPassword.Text);

        if (dt.Rows.Count > 0)
        {
            string role = dt.Rows[0]["Role"].ToString();
            Session["UserId"] = dt.Rows[0]["UserId"];
            Session["Role"] = role;

            if (role == "Client")
            {
                lblMessage.Text = "Redirecting to dashboard..."; 
                Response.Redirect("~/Pages/ClientDashboard.aspx");
            }

            else
            {
                lblMessage.Text = "Redirecting to Jobs...";
                Response.Redirect("~/Pages/JobList.aspx");
            }
        }
        else
        {
            lblMessage.Text = "Invalid credentials.";
        }
    }
}
