<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" MasterPageFile="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width: 400px; margin-top: 50px;">
        <h2 class="page-heading mb-4">Sign Up</h2>

        <asp:TextBox ID="txtName" runat="server" CssClass="form-control mb-3" Placeholder="Name" />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" Placeholder="Email" />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control mb-3" Placeholder="Password" />

        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select mb-3">
            <asp:ListItem Text="Select Role" Value="" />
            <asp:ListItem Text="Client" Value="Client" />
            <asp:ListItem Text="Freelancer" Value="Freelancer" />
        </asp:DropDownList>

        <asp:Button ID="btnSignup" runat="server" Text="Sign Up" CssClass="btn btn-primary w-100" OnClick="btnSignup_Click" />

        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-3 d-block" />
    </div>
</asp:Content>
