<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchVisitHotel.aspx.cs" Inherits="rnrtp2.SearchVisitHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>visitor information</h1>
            <asp:Label ID="Label1" runat="server" Text="Ticket ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Hotel ID: "></asp:Label>
            <asp:TextBox ID="hid_textbox" runat="server" required="required"></asp:TextBox><br /><br />

            <h1>update information</h1>
            <asp:Label ID="Label3" runat="server" Text="Amount Spent: "></asp:Label>
            <asp:TextBox ID="spent_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label4" runat="server" Text="Days Stayed: "></asp:Label>
            <asp:TextBox ID="days_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label5" runat="server" Text="Room Number: "></asp:Label>
            <asp:TextBox ID="room_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
        </div>
    </form>
</body>
</html>
