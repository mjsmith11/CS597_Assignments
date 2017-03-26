<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseScheduler.aspx.cs" Inherits="CS597_Project4.CourseScheduler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>
    <!--<link rel="stylesheet" type="text/css" href="https://unpkg.com/purecss@0.6.2/build/pure-min.css" />-->
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
            <asp:Button ID="btnSchedule" runat="server" Text="Schedule" OnClick="btnSchedule_Click" />
        </div>
        <div id="divSelectedCourses" runat="server">
            <h3>Selected Courses</h3>
            <ul class="courses">
                <li id="liSelected1" runat="server"><asp:Label ID="lblSelected1" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;<asp:Button ID="btnDelete1" runat="server" Text="Remove" class="delete" OnClick="btnDelete1_Click"/></li>
                <li id="liSelected2" runat="server"><asp:Label ID="lblSelected2" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;<asp:Button ID="btnDelete2" runat="server" Text="Remove" class="delete" OnClick="btnDelete2_Click"/></li>
                <li id="liSelected3" runat="server"><asp:Label ID="lblSelected3" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;<asp:Button ID="btnDelete3" runat="server" Text="Remove" class="delete" OnClick="btnDelete3_Click"/></li>
                <li id="liSelected4" runat="server"><asp:Label ID="lblSelected4" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;<asp:Button ID="btnDelete4" runat="server" Text="Remove" class="delete" OnClick="btnDelete4_Click"/></li>
            </ul>
        </div>
    </form>
        <div id="divSchedule" runat="server">
        </div>
    
</body>
</html>
