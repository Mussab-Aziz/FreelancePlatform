<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostJob.aspx.cs" Inherits="PostJob" MasterPageFile="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnBack" runat="server" Text="Back to Dashboard" OnClick="btnBack_Click" CssClass="btn btn-secondary mb-3" />

    <h2 class="mb-4">Post a Job</h2>

    <div class="mb-3">
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Placeholder="Job Title" />
    </div>

    <div class="mb-3">
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Placeholder="Description" TextMode="MultiLine" Rows="5" />
    </div>

    <div class="mb-3">
        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" Placeholder="Price" />
    </div>

    <div class="mb-3">
        <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control" Placeholder="Duration (days)" />
    </div>

    <asp:Button ID="btnPost" runat="server" CssClass="btn btn-primary" Text="Post Job" OnClick="btnPost_Click" />

    <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 text-success" />
</asp:Content>
