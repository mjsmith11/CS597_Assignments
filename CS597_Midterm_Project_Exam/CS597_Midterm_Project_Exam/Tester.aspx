<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="CS597_Midterm_Project_Exam.Tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Enter new bug</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbxSubject" runat="server" MaxLength="50"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPriority" runat="server" Text="Priority"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlPriority" runat="server">
            <asp:ListItem>High</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            <asp:ListItem>Low</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="tbxDescription" runat="server" MaxLength="50"></asp:TextBox>
    
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    
    </div>
    </form>
</body>
</html>
