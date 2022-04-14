<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClose.aspx.cs" Inherits="rnrtp2.AddClose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id="AddClose">
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <h1>close a ride</h1>
                <asp:Label ID="Label1" runat="server" Text="Employee ID: "></asp:Label>
                <asp:TextBox ID="eid_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Ride ID: "></asp:Label>
                <asp:TextBox ID="rid_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Date: "></asp:Label>
                <input type="date" name="date" id="date" runat="server" value="" style="width:200px;" required="required"/> <br /><br />
                <asp:Label ID="Label4" runat="server" Text="Time: "></asp:Label>
                <asp:TextBox ID="time_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Type: "></asp:Label>
                <asp:TextBox ID="type_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />

                <br /><br />
                <center><a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: black;">GO BACK TO HOME</a></center>
            <fieldset>
        </div>
    </form>
</body>
</html>
