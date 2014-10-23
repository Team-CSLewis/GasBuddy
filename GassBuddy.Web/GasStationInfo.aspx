<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GasStationInfo.aspx.cs" Inherits="GassBuddy.Web.GasStationInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Hello <%# this.User.Identity.Name %> </h2>

    <table id="gasStationInfoPageContent" runat="server">
        <tr>
            <td class="col-md-8">
                <div id="gasstationForm" runat="server" class="form-horizontal">
                    <h3>Information for <%#: this.currentGasStation.Name %></h3>
                    <div class="form-group">
                        <asp:Label ID="LabelDieselPrice" runat="server" CssClass="col-md-3 control-label" Text="Diesel Price"></asp:Label>
                        <asp:Label ID="DieselPrice" runat="server" CssClass="col-md-3 control-label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelPetrolPrice" runat="server" CssClass="col-md-3 control-label" Text="Petrol Price"></asp:Label>
                        <asp:Label ID="PetrolPrice" runat="server" CssClass="col-md-3 control-label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelLpgPrice" runat="server" CssClass="col-md-3 control-label" Text="LPG Price"></asp:Label>
                        <asp:Label ID="LpgPrice" runat="server" CssClass="col-md-3 control-label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelAddress" runat="server" CssClass="col-md-3 control-label" Text="Address"></asp:Label>
                        <asp:Label ID="Address" runat="server" CssClass="col-md-3 control-label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelCity" runat="server" CssClass="col-md-3 control-label" Text="City"></asp:Label>
                        <asp:Label ID="City" runat="server" CssClass="col-md-3 control-label"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelChain" runat="server" CssClass="col-md-3 control-label" Text="Chain"></asp:Label>
                        <asp:Label ID="Chain" runat="server" CssClass="col-md-3 control-label"></asp:Label>
                    </div>
                </div>
            </td>
            <td>
                <div id="mapCanvas" class="pull-right"></div>
            </td>
        </tr>
    </table>

    <div id="userForm" runat="server" class="form-horizontal">
                    <h3>Users postetd to <%#: this.currentGasStation.Name %></h3>

                    <asp:GridView ID="GridUsersPosts" CssClass="table" runat="server"
                        AllowPaging="true" PageSize="3"
                        OnPageIndexChanging="GridUsersPosts_PageIndexChanging"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="User.UserName" HeaderText="Username" />
                            <asp:BoundField DataField="DateOfRefuel" HeaderText="Date of refuel" />
                            <asp:BoundField DataField="FuelQuantity" HeaderText="Fuel quantity" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total price" />
                            <asp:BoundField DataField="PricePerLitter" HeaderText="Price per litter" />
                            <asp:BoundField DataField="FuelType" HeaderText="Fuel type" />
                        </Columns>
                    </asp:GridView>
                </div>

    <asp:TextBox ID="StationLat" runat="server"></asp:TextBox>
    <asp:TextBox ID="StationLon" runat="server"></asp:TextBox>


    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script type="text/javascript" src="../Scripts/markerevent.js"></script>

</asp:Content>
