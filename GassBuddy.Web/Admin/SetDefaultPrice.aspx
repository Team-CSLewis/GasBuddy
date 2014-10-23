<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPanel.master" AutoEventWireup="true" CodeBehind="SetDefaultPrice.aspx.cs" Inherits="GassBuddy.Web.Admin.SetDefaultPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminPanels" runat="server">
    <div runat="server" id="FormForPrice" visible="true">
        <div class="form-group">
            <asp:Label ID="LabelDieselPrice" runat="server" CssClass="col-md-3 control-label" Text="Diesel Price"></asp:Label>
            <asp:TextBox ID="TextBoxDieselPrice" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelPetrolPrice" runat="server" CssClass="col-md-3 control-label" Text="Petrol Price"></asp:Label>
            <asp:TextBox ID="TextBoxPetrolPrice" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelLpgPrice" runat="server" CssClass="col-md-3 control-label" Text="LPG Price"></asp:Label>
            <asp:TextBox ID="TextBoxLpgPrice" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group pull-left">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="BtnSetPrice" runat="server" OnClick="BtnSetPrice_Click" Text="Post Prices" CssClass="btn btn-info" />
            </div>
        </div>
    </div>

    <asp:Button ID="ButtonBackToHome" Visible="false" OnClick="ButtonBackToHome_Click" CssClass="btn btn-info" runat="server" Text="Back to home page" />
    <h2 id="SuccessMessage" visible="false" runat="server"></h2>
</asp:Content>
