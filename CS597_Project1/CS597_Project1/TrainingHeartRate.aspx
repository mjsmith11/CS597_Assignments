<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainingHeartRate.aspx.cs" Inherits="CS597_Project1.TrainingHeartRate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
    </style>
</head>
<body>
    <h1>Training Heart Rate Calculator</h1>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbxAge" runat="server" MaxLength="3" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRestingHR" runat="server" Text="Resting Heart Rate"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbxRestingHR" runat="server" MaxLength="3" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTrainingHR" runat="server" Text="Training Heart Rate"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbxTrainingHR" runat="server" ReadOnly="True" Width="300px"></asp:TextBox>
                </td>
            </tr>
        </table>    
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
        <br />
    </div>
    </form>
</body>
</html>
