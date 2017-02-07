<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateSearch.aspx.cs" Inherits="CS597_Project_2.StateSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
<asp:sqldatasource runat="server" ConnectionString="<%$ ConnectionStrings:StudentsDB %>" ProviderName="<%$ ConnectionStrings:StudentsDB.ProviderName %>" SelectCommand="SELECT * FROM [Academics]"></asp:sqldatasource>
