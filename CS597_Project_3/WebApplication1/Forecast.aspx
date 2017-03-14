<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forecast.aspx.cs" Inherits="WebApplication1.Forecast" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Weather Forecast</h1>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="lblZip" runat="server" Text="Zip Code(s)"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbxZip" runat="server" Width="173px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="Get Forecast" OnClick="btnSubmit_Click" />
        <br />
        <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
&nbsp;
    
    </div>
        <div id="divForecast" runat="server">

        </div>
    </form>
</body>
</html>
