<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="PostPrice.aspx.cs"
    Inherits="GassBuddy.Web.App_Features.PostPrice1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Hello <%# this.User.Identity.Name %> </h2>
    <h3>Post your price for <%#: this.currentGasStation.Name %></h3>

    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="LabelDieselPrice" runat="server" CssClass="col-md-2 control-label" Text="Diesel Price"></asp:Label>
            <asp:TextBox ID="TextBoxDieselPrice" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelPetrolPrice" runat="server" CssClass="col-md-2 control-label" Text="Petrol Price"></asp:Label>
            <asp:TextBox ID="TextBoxPetrolPrice" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelLpgPrice" runat="server" CssClass="col-md-2 control-label" Text="LPG Price"></asp:Label>
            <asp:TextBox ID="TextBoxLpgPrice" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
             <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="ButtonSubmitPrice" runat="server" OnClick="ButtonSubmitPrice_Click" Text="Post Prices" CssClass="btn btn-info" />
            </div>
        </div>
    </div>

</asp:Content>

