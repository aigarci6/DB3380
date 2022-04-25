<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHotel.aspx.cs" Inherits="rnrtp2.AddHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title>add new hotel</title>
</head>
<body id="hotel">
    <h1 class="row" style="color: black;">new hotel form</h1>
    <form id="form1" runat="server">

        <fieldset>
            <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="name_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Capacity: "></asp:Label>
            <asp:TextBox ID="capacity_textbox" runat="server" required="required"></asp:TextBox><br /><br />

            <asp:Label ID="Label4" runat="server" Text="Location ID: "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList> <br /><br />

            <asp:Label ID="Label5" runat="server" Text="Rating: "></asp:Label>
            <asp:TextBox ID="rating_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label6" runat="server" Text="Weekly Expenditure: "></asp:Label>
            <asp:TextBox ID="exp_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" align="left" />
            <br /><br /><br />
            <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: black;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
        </fieldset>
        </form>
</body>
</html>
