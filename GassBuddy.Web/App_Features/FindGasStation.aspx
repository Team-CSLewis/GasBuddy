<%@ Page
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="FindGasStation.aspx.cs"
    Inherits="GassBuddy.Web.App_Features.PostPrice" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Hello <%# this.User.Identity.Name %> </h2>     
    <h3>Post your price</h3>      
        <div>            
            <asp:Label CssClass="col-lg-2.control-label" ID="LabelCitySelect" runat="server">Select city</asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DropDownListCities" runat="server"></asp:DropDownList>
        </div>
        <div>            
            <asp:Label CssClass="col-lg-2.control-label" ID="LabelGasStationSelect" runat="server">Select GasStation Chain</asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DropDownChains" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Button ID="ButtonSearch" OnClick="ButtonSearch_Click" CssClass="btn btn-info" runat="server" Text="Search gas station" />
        </div>
        <br />
        <asp:GridView ID="GridViewGasStations" CssClass="table" runat="server" 
                AllowPaging="true" PageSize="3" 
                OnPageIndexChanging="GridViewGasStations_PageIndexChanging"                
                AutoGenerateColumns="False">
                <Columns>                                      
                    <asp:HyperLinkField DataTextField="Name"
                        DataNavigateUrlFields="Id"
                        DataNavigateUrlFormatString="PostPrice.aspx?id={0}"
                        HeaderText="Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />                    
                </Columns>
            </asp:GridView>
</asp:Content>
