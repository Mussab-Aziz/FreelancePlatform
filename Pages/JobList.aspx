<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobList.aspx.cs" Inherits="JobList" MasterPageFile="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="sub-header mb-4">
        <asp:Button ID="btnEditProfile" runat="server" Text="Edit My Profile" OnClick="btnEditProfile_Click" CssClass="btn btn-primary" />
    </div>

    <h2 class="mb-4">Job Listings</h2>

    <asp:GridView ID="gvJobs" runat="server" AutoGenerateColumns="False" 
        OnRowCommand="gvJobs_RowCommand" DataKeyNames="JobId" CssClass="table table-bordered table-striped">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="${0}" />
            <asp:BoundField DataField="Duration" HeaderText="Duration (days)">
                <ItemStyle CssClass="text-center" />
            </asp:BoundField>
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button 
                        ID="btnApply" 
                        runat="server" 
                        Text="Apply" 
                        CommandName="OpenCoverLetter" 
                        CommandArgument='<%# Container.DataItemIndex %>' 
                        CssClass="btn btn-success btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlCoverLetter" runat="server" CssClass="border rounded p-3 mt-4" Visible="false" style="background-color:#f8f9fa;">
        <h3>Submit Application</h3>
        <asp:TextBox ID="txtCoverLetter" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" Placeholder="Write your cover letter..."></asp:TextBox>
        <div class="mt-3">
            <asp:HiddenField ID="hfJobId" runat="server" />
            <asp:Button ID="btnSubmitApplication" runat="server" Text="Submit Application" OnClick="btnSubmitApplication_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" CssClass="btn btn-secondary ms-2" />
        </div>
    </asp:Panel>

    <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 text-success" />

</asp:Content>
