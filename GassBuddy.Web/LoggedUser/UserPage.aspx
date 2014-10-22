<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="UserPage.aspx.cs"
    Inherits="GassBuddy.Web.LoggedUser.UserPage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Hello, <%: this.User.Identity.Name %>.</h2>
    <h3>Statistic of refuels</h3>

    <div class="form-horizontal">
        <div class="form-group">
            <ul class="list-group col-md-3">
                <li class="list-group-item">
                    <label class="control-label">Total money:</label>
                    <span id="totalMoneyAmount" runat="server"></span>
                </li>
                <li class="list-group-item">
                    <label class="control-label">Total litters:</label>
                    <span id="totalLitterAmount" runat="server"></span>
                </li>
                <li class="list-group-item">
                    <label class="control-label">Total period:</label>
                    <span id="totalPeriod" runat="server"></span>
                </li>
            </ul>
        </div>
    </div>


    <div class="form-horizontal">
        <h3>Refuels</h3>
        <asp:ListView ID="ListViewUserPosts" runat="server"
            ItemType="GassBuddy.Models.UserHistory">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="form-group">
                    <ul class="list-group">
                        <li class="col-md-3 list-group-item">
                            <label class="control-label">Date of refuel:</label>
                            <p><%#: Item.DateOfRefuel %></p>
                            <label class="control-label">Fuel type:</label>
                            <p><%#: Item.FuelType %></p>
                            <label class="control-label">Fuel quantity:</label>
                            <p><%#: Item.FuelQuantity %></p>
                            <label class="control-label">Price per litter:</label>
                            <p><%#: Item.PricePerLitter %></p>
                            <label class="control-label">Total Price:</label>
                            <p><%#: Item.TotalPrice %></p>
                            <label class="control-label">Gas Station:</label>
                            <p><%#: Item.GasStation.Name %></p>
                        </li>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>



    <asp:DataPager ID="DataPagerUserPosts" runat="server"
        PagedControlID="ListViewUserPosts" PageSize="1"
        QueryStringField="page">

        <Fields>
            <asp:NextPreviousPagerField
                ShowFirstPageButton="true" ShowNextPageButton="false"
                ShowPreviousPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
        </Fields>

    </asp:DataPager>

</asp:Content>
