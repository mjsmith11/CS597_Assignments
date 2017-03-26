<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseScheduler.aspx.cs" Inherits="CS597_Project4.CourseScheduler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Course Scheduler</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCourses" Text="Available Courses:" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlCourses" runat="server" Height="26px" Width="58px">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" style="height: 26px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSchedule" runat="server" Text="Schedule" />
        </div>
    </form>
        <div id="divSelectedCourses" runat="server">
        </div>
        <div id="divSchedule" runat="server">
        </div>
    
</body>
</html>
