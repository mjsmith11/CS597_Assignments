<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="CS597_Project_5.MovieDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divMovieInfo" runat="server">
        </div>
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </form>
</body>
</html>
