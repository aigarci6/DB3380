<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVisitRestaurant.aspx.cs" Inherits="rnrtp2.AddVisitRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title>add new restaurant visitor</title>
</head>
<body id="AddVisitRestaurant">
    <form id="form1" runat="server">
        <div>
            
            <h1>restaurant visitor form</h1>
            <fieldset>
                <asp:Label ID="Label5" runat="server" Text="Date: "></asp:Label>
                <input type="date" name="date" id="date" runat="server" value="" style="width:130px;" required="required"/> <br /><br />
                <asp:Label ID="Label1" runat="server" Text="Ticket ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />

                <asp:Label ID="Label2" runat="server" Text="Restaurant: "></asp:Label>
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList> <br /><br />

                <asp:Label ID="Label3" runat="server" Text="Amount Spent: "></asp:Label>
                <asp:TextBox ID="spent_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                <br /><br /><br />
            <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: white;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
            </fieldset>
        </div>
    </form>
</body>
</html>
