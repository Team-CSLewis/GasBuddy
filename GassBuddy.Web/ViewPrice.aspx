<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPrice.aspx.cs" Inherits="GassBuddy.Web.ViewPrice" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Hello <%# this.User.Identity.Name %> </h2>
    <h3>Find your gas station</h3>

    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label CssClass="col-md-2 control-label" ID="LabelCitySelect" runat="server">Select city</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList CssClass="form-control" ID="DropDownListCities" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="col-md-2 control-label" ID="LabelGasStationSelect" runat="server">Select GasStation Chain</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList CssClass="form-control" ID="DropDownChains" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-3">
                <asp:Button ID="ButtonSearch" OnClick="ButtonSearch_Click" CssClass="btn btn-info" runat="server" Text="Search gas station" />
            </div>
        </div>
    </div>

    <asp:GridView ID="GridViewGasStations" runat="server"
        CssClass="table table-hover table-striped"
        GridLines="None"
        UseAccessibleHeader="True"
        AllowPaging="true" PageSize="3"
        OnPageIndexChanging="GridViewGasStations_PageIndexChanging"
        AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataTextField="Name"
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="GasStationInfo.aspx?id={0}"
                HeaderText="Name" />
            <asp:BoundField DataField="DieselPrice" HeaderText="Diesel Price" />
            <asp:BoundField DataField="PetrolPrice" HeaderText="Petrol Price" />
            <asp:BoundField DataField="LpgPrice" HeaderText="Lpg Price" />
        </Columns>
    </asp:GridView>
</asp:Content>
