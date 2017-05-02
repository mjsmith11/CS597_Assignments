<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseQuantity.aspx.cs" Inherits="ShoppingCart.ChooseQuantity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblBook" runat="server" Font-Size="Larger" Font-Bold="True"></asp:Label><br />
        <asp:Label ID="lblCopies" runat="server" Text="How Many Copies?"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCopies" runat="server" Height="16px" Width="149px">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add To Cart" />
        <br />
        <br />
        <div id="divSuccess" runat="server">
            <asp:Label ID="lblSuccess" runat="server" Text="Book Added to Cart"></asp:Label>
            <br /><br />
            <asp:HyperLink ID="lnkContinue" runat="server" NavigateUrl="~/Store.aspx">Continue Shopping</asp:HyperLink>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:HyperLink ID="lnkCheckout" runat="server" NavigateUrl="~/Checkout.aspx">Checkout</asp:HyperLink>
        </div>
    
    </div>
    </form>
</body>
</html>
