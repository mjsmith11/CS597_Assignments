<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchByAreaCode.aspx.cs" Inherits="CS597_Project_2.SearchByAreaCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <h1>Search By Area Code</h1>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="tbxAreaCode" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    
        <br />
        <br />
        <asp:GridView ID="gvDisplay" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
