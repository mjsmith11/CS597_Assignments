<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Developer.aspx.cs" Inherits="CS597_Midterm_Project_Exam.Developer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Bug Assignments</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvBugs" runat="server">
        </asp:GridView>
    
        <br />
        <asp:Label ID="lblBug" runat="server" Text="Choose Bug"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlBug" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblSteps" runat="server" Text="Steps for Resolution"></asp:Label>
        <br />
        <asp:TextBox ID="tbxSteps" runat="server" MaxLength="255" Rows="4" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnFixed" runat="server" Text="Fixed" OnClick="btnFixed_Click" />
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    
    </div>
    </form>
</body>
</html>
