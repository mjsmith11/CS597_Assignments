<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchByGPA.aspx.cs" Inherits="CS597_Project_2.SearchByGPA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Search by GPA</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="tbxGPA" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    
        <br />
        <asp:GridView ID="gvDisplay" runat="server">
        </asp:GridView>
    
    </div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
