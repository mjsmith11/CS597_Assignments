<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchByMajor.aspx.cs" Inherits="CS597_Project_2.SearchByMajor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <h1>Search By Major</h1>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddlMajors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajors_SelectedIndexChanged">
        </asp:DropDownList>
    
        <br />
        <br />
        <asp:GridView ID="gvDisplay" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
