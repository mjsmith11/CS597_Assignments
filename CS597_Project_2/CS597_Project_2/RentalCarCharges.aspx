<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalCarCharges.aspx.cs" Inherits="CS597_Project_2.RentalCarCharges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Rental Car Charge Calculator</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblType" runat="server" Text="Vehicle Type"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="ddlType" runat="server">
            <asp:ListItem Value="24.99">Economy</asp:ListItem>
            <asp:ListItem Value="29.99">Compact</asp:ListItem>
            <asp:ListItem Value="34.99">Intermediate</asp:ListItem>
            <asp:ListItem Value="44.99">Standard</asp:ListItem>
            <asp:ListItem Value="49.99">Full-Size</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblDays" runat="server" Text="Days"></asp:Label>
        &nbsp;&nbsp
        <asp:TextBox ID="tbxDays" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblCharges" runat="server" Text="Total Charges"></asp:Label>
        &nbsp;&nbsp
        <asp:TextBox ID="tbxCharges" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
        

    
    </div>
    </form>
</body>
</html>
