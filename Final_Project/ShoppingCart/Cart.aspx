<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ShoppingCart.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <asp:GridView ID="gvCartContents" runat="server" CellPadding="10" CellSpacing="5"></asp:GridView>

        <br />
        <asp:HyperLink ID="lnkContinue" runat="server" NavigateUrl="~/Store.aspx">Continue Shopping</asp:HyperLink>
    </div>
    </form>
</body>
</html>
