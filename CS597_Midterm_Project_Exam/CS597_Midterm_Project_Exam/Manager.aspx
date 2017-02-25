<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="CS597_Midterm_Project_Exam.Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 43px;
        }
        .auto-style2 {
            width: 256px;
        }
    </style>
</head>
<body>
    <h1>Bug Assignment</h1>
    <form id="form1" runat="server">
    <div>
    <table><tr>
        <td>
        <asp:Label ID="lblBug" runat="server" Text="Bug"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlBug" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBug_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblDeveloper" runat="server" Text="Developer"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlDeveloper" runat="server">
        </asp:DropDownList>
    
        <br />
        <br />
        <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
    
        <br />
        <br />
            </td>
        <td class="auto-style1"></td>
        <td class="auto-style2">
            <h4>Bug Details</h4>
            <asp:DetailsView ID="dvBugDisplay" runat="server" Height="50px" Width="252px">
        </asp:DetailsView>
        </td>
        </tr></table>
        <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    
    </div>
    </form>
</body>
</html>
