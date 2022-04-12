<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHotel.aspx.cs" Inherits="rnrtp2.AddHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id="hotel">
    <h1 class="row">Add Hotel</h1>
    <form id="form1" runat="server">

        <fieldset>
            <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label><br />
            <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Name: " required="required"></asp:Label><br />
            <asp:TextBox ID="name_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Capacity: "></asp:Label><br />
            <asp:TextBox ID="capacity_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label4" runat="server" Text="Location ID: "></asp:Label><br />
            <asp:TextBox ID="location_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label5" runat="server" Text="Rating: "></asp:Label><br />
            <asp:TextBox ID="rating_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label6" runat="server" Text="Weekly Expenditure: "></asp:Label><br />
            <asp:TextBox ID="exp_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" align="left" />
        </fieldset>
        </form>
</body>
</html>
