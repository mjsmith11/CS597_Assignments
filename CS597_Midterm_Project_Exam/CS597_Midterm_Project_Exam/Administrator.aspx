<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="CS597_Midterm_Project_Exam.Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>New User</h1>
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
        <asp:Label ID="lblType" runat="server" Text="User Type"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlType" runat="server">
            <asp:ListItem>Tester</asp:ListItem>
            <asp:ListItem>Manager</asp:ListItem>
            <asp:ListItem>Developer</asp:ListItem>
            <asp:ListItem>Administrator</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add User" OnClick="btnAdd_Click" />
        <br />
        <br />
        <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        <br />
    
    </div>
    </form>
</body>
</html>
