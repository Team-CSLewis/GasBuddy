<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPanel.master" AutoEventWireup="true" CodeBehind="NewGasStation.aspx.cs" Inherits="GassBuddy.Web.Admin.NewGasStation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminPanels" runat="server">
    <h1>Add New Gas Station</h1>
    <div runat="server" id="NewStationForm" visible="true">
        <div class="form-group">
            <asp:Label ID="LabelStationName" runat="server" CssClass="col-md-3 control-label" Text="Station Name"></asp:Label>
            <asp:TextBox ID="TbStationName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorStationName"
                runat="server"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Station name is required!"
                ControlToValidate="TbStationName" />
        </div>
        <div class="form-group">
            <asp:Label ID="LabelCity" runat="server" CssClass="col-md-3 control-label" Text="Station City"></asp:Label>
            <asp:TextBox ID="TbCity" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorCity"
                runat="server"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="City is required!"
                ControlToValidate="TbCity" />
        </div>
        <div class="form-group">
            <asp:Label ID="LabelStationAddress" runat="server" CssClass="col-md-3 control-label" Text="Station Address"></asp:Label>
            <asp:TextBox ID="TbStationAddress" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorStationAddress"
                runat="server"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Station address is required!"
                ControlToValidate="TbStationAddress" />
        </div>
        <div class="form-group">
            <asp:Label ID="LabelDescription" runat="server" CssClass="col-md-3 control-label" Text="Description"></asp:Label>
            <asp:TextBox ID="TbDescription" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorDescription"
                runat="server"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Description address is required!"
                ControlToValidate="TbDescription" />
        </div>
        <div class="form-group">
            <asp:Label ID="LabelLocation" runat="server" CssClass="col-md-3 control-label" Text="Location"></asp:Label>
            <asp:TextBox ID="TbLocation" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorLocation"
                runat="server"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Location address is required!"
                ControlToValidate="TbLocation" />
            <asp:RegularExpressionValidator
                ID="RegularExpressionValidatorLocation"
                runat="server"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Location is incorrect!"
                ControlToValidate="TbLocation"
                ValidationExpression="^\d+(.\d+)(;\d+)(.\d+)$" />
        </div>
        <div class="form-group">
            <asp:Label CssClass="col-md-3 control-label" ID="LabelGasStationSelect" runat="server">GasStation Chain</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList CssClass="form-control" ID="DropDownChains" DataValueField="Id" DataTextField="Name" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group pull-left">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="AddStation" runat="server" OnClick="AddStation_Click" Text="Add Station" CssClass="btn btn-info" />
            </div>
        </div>
    </div>
    <asp:Button ID="ButtonBackToHome" Visible="false" OnClick="ButtonBackToHome_Click" CssClass="btn btn-info" runat="server" Text="Back to home page" />
    <h2 id="SuccessMessage" visible="false" runat="server"></h2>
</asp:Content>
