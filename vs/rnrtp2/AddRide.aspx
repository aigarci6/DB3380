<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRide.aspx.cs" Inherits="rnrtp2.AddRide" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title>add a new ride</title>
</head>
<body id="AddRide">
    <h1><font color="black">new ride form </font></h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
                <asp:TextBox ID="name_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Capacity: "></asp:Label>
                <asp:TextBox ID="capacity_textbox" runat="server" required="required"></asp:TextBox><br /><br />

                <asp:Label ID="Label4" runat="server" Text="Location ID: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList> <br /><br />

                <asp:Label ID="Label5" runat="server" Text="Maximum Weight: " ></asp:Label>
                <asp:TextBox ID="maxweight_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label6" runat="server" Text="Minimum Height: "></asp:Label>
                <asp:TextBox ID="minheight_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label7" runat="server" Text="Minimum Age: "></asp:Label>
                <asp:TextBox ID="minage_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                <br /><br /><br />
            <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: black;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
            </fieldset>
        </div>
    </form>
</body>
</html>

