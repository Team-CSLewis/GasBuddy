<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="PostPrice.aspx.cs"
    Inherits="GassBuddy.Web.LoggedUser.PostPrice1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Hello <%# this.User.Identity.Name %> </h2>

    <div id="gasstationForm" runat="server" class="form-horizontal">
        <h3>Post your price for <%#: this.currentGasStation.Name %></h3>
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
    </div>

    <div id="userForm" runat="server" class="form-horizontal">
        <h3>Add more info to your personal database</h3>
        <div class="form-group">
            <div class="col-md-2">
                <asp:Label ID="LabelFuelType" runat="server" CssClass="control-label pull-right" Text="Fuel type"></asp:Label>
            </div>
            
            <div class="col-md-3">
                <asp:DropDownList ID="DropDownListFuelTypes" CssClass="form-control" runat="server">
                    <asp:ListItem>Diesel</asp:ListItem>
                    <asp:ListItem>Petrol</asp:ListItem>
                    <asp:ListItem>Lpg</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>

        <div class="form-group">
            <asp:Label ID="LabelFuelQuantity" runat="server" CssClass="col-md-2 control-label" Text="Fuel quantity"></asp:Label>
            <asp:TextBox ID="TextBoxFuelQuantity" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelPricePerLitter" runat="server" CssClass="col-md-2 control-label" Text="Price per litter"></asp:Label>
            <asp:TextBox ID="TextBoxPricePerLitter" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="ButtonSubmitPrice" runat="server" OnClick="ButtonSubmitPrice_Click" Text="Post Prices" CssClass="btn btn-info" />
            </div>
        </div>
    </div>

    <h2 ID="SuccessMessage" runat="server"></h2>
    <asp:Button ID="ButtonBackToHome" Visible="false" OnClick="ButtonBackToHome_Click" CssClass="btn btn-info" runat="server" Text="Back to home page" />
</asp:Content>

