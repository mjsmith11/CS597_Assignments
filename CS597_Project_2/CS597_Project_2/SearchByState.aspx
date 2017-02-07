<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchByState.aspx.cs" Inherits="CS597_Project_2.SearchByState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Search By State</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddlStates" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStates_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gvDisplay" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
