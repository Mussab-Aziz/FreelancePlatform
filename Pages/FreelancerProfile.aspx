<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FreelancerProfile.aspx.cs" Inherits="FreelancerProfile" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnBack" runat="server" Text="Back to Jobs" OnClick="btnBack_Click" CssClass="btn btn-secondary mb-4" />

    <div class="form-container">
        <h2 class="page-heading mb-4">Freelancer Profile</h2>

        <asp:TextBox ID="txtSkills" runat="server" CssClass="form-control mb-3" placeholder="Skills" />

        <asp:TextBox ID="txtRate" runat="server" CssClass="form-control mb-3" placeholder="Hourly Rate" />

        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control mb-4">
            <asp:ListItem Text="Available" Value="Available" />
            <asp:ListItem Text="Away" Value="Away" />
        </asp:DropDownList>

        <div class="d-flex gap-2 mb-4">
            <asp:Button ID="btnSave" runat="server" Text="Save Profile" OnClick="btnSave_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnGoToJobs" runat="server" Text="Jobs" OnClick="btnGoToJobs_Click" CssClass="btn btn-secondary" />
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" />
    </div>
</asp:Content>
