<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostPrice.aspx.cs" Inherits="GassBuddy.Web.App_Features.PostPrice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">        
    <div>
        <asp:Label ClientIDMode="Static" ID="LabelCoords" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" OnTextChanged="TextBox1_TextChanged" runat="server"></asp:TextBox>
    </div>
        <script type="text/javascript">
            navigator.geolocation.getCurrentPosition(function (data) {
                document.getElementById("TextBox1").value = data.coords.latitude + ", " + data.coords.longitude;
            console.log(data.coords);
            }, function (err) {

            }) 
        </script>
    </form>
</body>
</html>
