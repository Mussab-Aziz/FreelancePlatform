using System;
using System.Data;

public partial class Signup : System.Web.UI.Page
{
    protected void btnSignup_Click(object sender, EventArgs e)
    {
        
        try
        {
            UserRepository repo = new UserRepository();
            repo.RegisterUser(txtName.Text, txtEmail.Text, txtPassword.Text, ddlRole.SelectedValue);
            lblMessage.Text = "User registered successfully!";
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error: " + ex.Message;
        }
    }
}
