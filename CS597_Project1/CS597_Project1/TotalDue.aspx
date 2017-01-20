<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TotalDue.aspx.cs" Inherits="CS597_Project1.TotalDue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Image Consulting Bill Calculator</h1>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblDiscount" runat="server" Text="Discount"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDiscount" runat="server" Height="20px" Width="200px">
                        <asp:ListItem Value="10">10 percent</asp:ListItem>
                        <asp:ListItem Value="20">20 percent</asp:ListItem>
                        <asp:ListItem Value="0">none</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblService" runat="server" Text="Service"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlService" runat="server" Height="20px" Width="200px">
                        <asp:ListItem Value="125">Makeover $125</asp:ListItem>
                        <asp:ListItem Value="60">Hair Styling $60</asp:ListItem>
                        <asp:ListItem Value="30">Manicure $30</asp:ListItem>
                        <asp:ListItem Value="200">Permanent Makeup $200</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotal" runat="server" Text="Total Due"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxTotal" runat="server" ReadOnly="True" Width ="192px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
    </div>
    </form>
</body>
</html>
