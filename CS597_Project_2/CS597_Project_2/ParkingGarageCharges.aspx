<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParkingGarageCharges.aspx.cs" Inherits="CS597_Project_2.ParkingGarageCharges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Parking Garage Charge Calculator</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblHours" runat="server" Text ="Hours Parked"></asp:Label>
        &nbsp;&nbsp;&nbsp
        <asp:TextBox ID="tbxHours" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Total Cost"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbxCost" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
    </div>
    </form>
</body>
</html>
