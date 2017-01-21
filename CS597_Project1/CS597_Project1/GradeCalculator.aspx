<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeCalculator.aspx.cs" Inherits="CS597_Project1.GradeCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Grade Calculator</h1>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Student Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblQuiz" runat="server" Text="Quiz Score"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxQuiz" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAssignment" runat="server" Text="Assignment Score"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxAssignment" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMidterm" runat="server" Text="Midterm Exam Score"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxMidterm" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFinal" runat="server" Text="Final Exam Score"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxFinal" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblGrade" runat="server" Text="Grade"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbxPercentage" runat="server" ReadOnly="true"></asp:TextBox> &nbsp; <asp:TextBox ID="tbxLetter" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
    </table>
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
    </div>
    </form>
</body>
</html>
