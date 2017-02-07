<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchByClass.aspx.cs" Inherits="CS597_Project_2.SearchByClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <h1>Search by Class</h1>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged">
            <asp:ListItem Value="fr">Freshman</asp:ListItem>
            <asp:ListItem Value="so">Sophomore</asp:ListItem>
            <asp:ListItem Value="ju">Junior</asp:ListItem>
            <asp:ListItem Value="se">Senior</asp:ListItem>
        </asp:DropDownList>
    
        <br />
        <br />
        <asp:GridView ID="gvDisplay" runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    
    </div>
    </form>
</body>
</html>
