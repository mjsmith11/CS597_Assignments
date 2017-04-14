<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="CS597_Project_5.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Movie Search</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblTerm" runat="server" Text="Search Term:"></asp:Label>
    
    &nbsp;&nbsp;
        <asp:TextBox ID="tbxTerm" runat="server" Width="168px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    
    </div>
        <br />
    <div id="divResults" runat="server"></div>
</body>
</html>
