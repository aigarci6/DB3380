<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRestaurant.aspx.cs" Inherits="rnrtp2.AddRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    
    <title>add a new restaurant</title>
</head>
<body id="restaurant">
    <div class="widget">
        <h1 class="row">new restaurant form</h1>
        <form id="form1" runat="server">
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label><br />
                <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label><br />
                <asp:TextBox ID="name_textbox" runat="server" required="required"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Location ID: "></asp:Label><br />
                <asp:TextBox ID="location_textbox" runat="server" required="required"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Capacity: "></asp:Label><br />
                <asp:TextBox ID="capacity_textbox" runat="server" required="required"></asp:TextBox><br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Weekly Expenditure: "></asp:Label><br />
                <asp:TextBox ID="exp_textbox" runat="server"></asp:TextBox><br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                <br /><br /><br />
            <a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: white;">GO BACK TO HOME</a>
            </fieldset>
        </form>
    </div>
</body>
</html>
