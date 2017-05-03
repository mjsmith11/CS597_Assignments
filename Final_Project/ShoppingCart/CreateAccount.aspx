<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="ShoppingCart.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>New Account Sign Up</h1>
    <form id="form1" runat="server">
    <div>
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbxName" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbxLogin" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Create User" OnClick="btnAdd_Click" />
        <br />
        <br />
        <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">Go To Login</asp:HyperLink>
    </div>
    </form>
</body>
</html>
