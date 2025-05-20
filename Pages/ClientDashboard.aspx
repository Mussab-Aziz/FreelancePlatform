<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientDashboard.aspx.cs" Inherits="ClientDashboard" MasterPageFile="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2 class="mb-4">Client Dashboard</h2>

    <div class="d-flex gap-2">
        <asp:Button ID="btnPostJob" runat="server" Text="Post a Job" CssClass="btn btn-primary" OnClick="btnPostJob_Click" />
        <asp:Button ID="btnViewApplications" runat="server" Text="View Applications" CssClass="btn btn-secondary" OnClick="btnViewApplications_Click" />
        <asp:Button ID="btnDeleteJob" runat="server" Text="Delete a Job" CssClass="btn btn-danger" OnClick="btnDeleteJob_Click" />
    </div>
</asp:Content>
