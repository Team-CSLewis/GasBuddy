<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GassBuddy.Web.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well">
        <h1>Welcome to Gas Buddy</h1>
        <p class="lead">Find cheapest fuel in your city.</p>
    </div>

    <div class="row">
        <asp:GridView ID="GridViewStations" runat="server"
                      ItemType="GassBuddy.Models.GasStation" AutoGenerateColumns="False"
                      DataKeyNames="Id" AllowPaging="true"
                      OnPageIndexChanging="GridViewStations_OnPageIndexChanging"
                      CssClass="table table-responsive table-striped table-hover table-bordered">
            <Columns>
                <asp:HyperLinkField DataTextField="Name"
                                    DataNavigateUrlFields="Id"
                                    DataNavigateUrlFormatString="~/LoggedUser/PostPrice.aspx?id={0}"
                                    HeaderText="Name"/>

                <asp:DynamicField DataField="PetrolPrice"/>
                <asp:DynamicField DataField="DieselPrice"/>
                <asp:DynamicField DataField="LpgPrice"/>
            </Columns>
        </asp:GridView>
    </div>

    <div class="row">
        <div class="col-md-3  text-center">
            <span>Total station:</span>
            <strong>
                <asp:Literal ID="LiteralStationsCount" runat="server"/>
            </strong>
        </div>
        <div class="col-md-3 text-center">
            <span >Avarage diesel price:</span>
            <strong>
                <asp:Literal ID="AvgDiselPrice" runat="server"/>
            </strong>
        </div>
        <div class="col-md-3 text-center">
            <span>Avarage petrol price:</span>
            <strong>
                <asp:Literal ID="AvgPetrolPrice" runat="server"/>
            </strong>
        </div>
        <div class="col-md-3 text-center">
            <span>Avarage LPG price:</span>
            <strong>
                <asp:Literal ID="AvgLPGPrice" runat="server"/>
            </strong>
        </div>
    </div>
</asp:Content>