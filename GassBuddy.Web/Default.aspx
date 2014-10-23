<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GassBuddy.Web.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="well">
        <div class="row">
            <div class="col-md-9">
                <h1>Welcome to Gas Buddy</h1>
                <p class="lead">Find cheapest fuel in your city.</p>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-md-6 pull-right">
            <asp:Label CssClass="col-md-3 col-md-offset-1 label label-primary"
                       ID="LabelCitySelect" runat="server">
                Select city
            </asp:Label>
            <div class="col-md-12">
                <asp:DropDownList CssClass="form-control" AutoPostBack="True"
                                  OnSelectedIndexChanged="DropDownListCities_OnSelectedIndexChanged"
                                  ID="DropDownListCities" runat="server">
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="row">
        <asp:GridView ID="GridViewStations" runat="server" AllowSorting="True"
                      OnSorting="GridViewStations_OnSorting"
                      ItemType="GassBuddy.Models.GasStation" AutoGenerateColumns="False"
                      DataKeyNames="Id" AllowPaging="true"
                      OnPageIndexChanging="GridViewStations_OnPageIndexChanging"
                      CssClass="table table-responsive table-striped table-hover table-bordered">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="hyperDetails" runat="server"
                                       NavigateUrl='<%# "~/GasStationInfo?id=" + Eval("Id") %>'
                                       Text=<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>/>
                    </ItemTemplate>
                </asp:TemplateField>
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