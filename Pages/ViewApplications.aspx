<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewApplications.aspx.cs" Inherits="ViewApplications" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">

        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-warning d-none" EnableViewState="false" />

        <asp:Button ID="btnBack" runat="server" Text="Back to Dashboard" OnClick="btnBack_Click" CssClass="btn btn-secondary mb-4" />

        <h2 class="mb-4">View Applications</h2>

        <div class="row mb-3">
            <div class="col-md-6">
                <asp:DropDownList ID="ddlJobs" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlJobs_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>

        <asp:GridView ID="gvApplications" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped mt-4">
            <Columns>
                <asp:BoundField DataField="FreelancerName" HeaderText="Freelancer" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="CoverLetter" HeaderText="Cover Letter" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-outline-secondary mt-3" />
        <asp:Label ID="Label1" runat="server" ForeColor="Red" CssClass="d-block mt-2" />
        
    </div>
</asp:Content>
