﻿<%@ Page
    MasterPageFile="~/Site.Master"
    Language="C#" AutoEventWireup="true" CodeBehind="PostPrice.aspx.cs" Inherits="GassBuddy.Web.LoggedUser.PostPrice" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Hello <%# this.User.Identity.Name %> </h2>

    <table id="PostPricePageContent" runat="server">
        <tr>
            <td class="col-md-8">
                <div id="gasstationForm" runat="server" class="form-horizontal">
                    <h3>Post your price for <%#: this.currentGasStation.Name %></h3>
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
                </div>
            </td>
            <td>
                <div id="mapCanvas" class="pull-right"></div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="userForm" runat="server" class="form-horizontal">
                    <h3>Add more info to your personal database</h3>
                    <div class="form-group">
                        <asp:Label ID="LabelFuelType" runat="server" CssClass="col-md-3 control-label">Fuel type</asp:Label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="DropDownListFuelTypes" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="LabelFuelQuantity" runat="server" CssClass="col-md-3 control-label" Text="Fuel quantity"></asp:Label>
                        <asp:TextBox ID="TextBoxFuelQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="LabelPricePerLitter" runat="server" CssClass="col-md-3 control-label" Text="Price per litter"></asp:Label>
                        <asp:TextBox ID="TextBoxPricePerLitter" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>
            </td>
            <td>
                <div class="form-group pull-left">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button ID="ButtonSubmitPrice" runat="server" OnClick="ButtonSubmitPrice_Click" Text="Post Prices" CssClass="btn btn-info" />
                    </div>
                </div>
            </td>
        </tr>
    </table>

    <asp:Button ID="ButtonBackToHome" Visible="false" OnClick="ButtonBackToHome_Click" CssClass="btn btn-info" runat="server" Text="Back to home page" />
    <h2 id="SuccessMessage" runat="server"></h2>

    
    <asp:TextBox ID="StationLat" runat="server"></asp:TextBox>
    <asp:TextBox ID="StationLon" runat="server"></asp:TextBox>
    

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script type="text/javascript" src="../Scripts/markerevent.js"></script>
</asp:Content>

