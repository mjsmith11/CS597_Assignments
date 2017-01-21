<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthlyPayment.aspx.cs" Inherits="CS597_Project1.MonthlyPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Car Payment Calculator</h1>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblPrice" runat="server" Text="Car Price"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDownPayment" runat="server" Text="Down Payment"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxDownPayment" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAPR" runat="server" Text="Annual Percentage Rate"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxAPR" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblYears" runat="server" Text="Years"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxYears" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMonthlyPayment" runat="server" Text="Monthly Payment"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxMonthlyPayment" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
        <br />
    </div>
    </form>
</body>
</html>
