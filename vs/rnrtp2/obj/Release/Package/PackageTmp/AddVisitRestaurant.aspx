<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVisitRestaurant.aspx.cs" Inherits="rnrtp2.AddVisitRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>add visitor to restaurant</h1>
            <asp:Label ID="Label1" runat="server" Text="Ticket ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Restaurant ID: "></asp:Label>
            <asp:TextBox ID="rid_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Amount Spent: "></asp:Label>
            <asp:TextBox ID="spent_textbox" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
