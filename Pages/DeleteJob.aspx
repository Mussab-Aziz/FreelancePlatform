<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteJob.aspx.cs" Inherits="DeleteJob" MasterPageFile="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="btnBack" runat="server" Text="Back to Dashboard" OnClick="btnBack_Click" CssClass="btn btn-secondary mb-4" />

    <h2 class="mb-4">Delete a Job</h2>

    <asp:DropDownList ID="ddlJobs" runat="server" CssClass="form-control mb-3"></asp:DropDownList>
    <asp:Button ID="btnDelete" runat="server" Text="Delete Job" CssClass="btn btn-danger" OnClick="btnDelete_Click" />

    <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 d-block text-success" />

</asp:Content>
