<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVisitHotel.aspx.cs" Inherits="rnrtp2.AddVisitHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id="AddVisitHotel">
    <form id="form1" runat="server">
        <div>
            <h1><font color="black">Add visitor to hotel</font></h1>
            <fieldset>
        
                <asp:Label ID="Label1" runat="server" Text="Ticket ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Hotel ID: "></asp:Label>
                <asp:TextBox ID="hid_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Labe1" runat="server" Text="Amount Spent: "></asp:Label>
                <asp:TextBox ID="spent_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Number of Days Visiting: "></asp:Label>
                <asp:TextBox ID="days_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Room Number: "></asp:Label>
                <asp:TextBox ID="room_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />

            </fieldset>
            
        </div>
    </form>
</body>
</html>
