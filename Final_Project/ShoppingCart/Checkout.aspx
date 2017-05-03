<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ShoppingCart.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Checkout Complete</h1>
    <div>
        <asp:GridView ID="gvSummary" runat="server"></asp:GridView>
        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
