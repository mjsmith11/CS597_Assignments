<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="ShoppingCart.Store" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--This table isn't rendering correctly in visual studio, but it does render correctly in MS Edge and Chrome-->
        <table>
            <tr>
                <th>
                    <asp:Label ID="lblBook" runat="server" Text="Book"></asp:Label>
                </th>
                <th>
                    <asp:Label ID="lblQty" runat="server" Text="Quantity"></asp:Label>
                 </th>
                <th></th>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlBooks" runat="server" Width="360px" Height="24px" AutoPostBack="True" OnSelectedIndexChanged="ddlBooks_SelectedIndexChanged">
                    </asp:DropDownList>
               </td>

                <td>
                    <asp:DropDownList ID="ddlQty" runat="server" Height="24px" Width="89px">
                    </asp:DropDownList>
               </td>
                <td>
                    <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" />
                </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
