<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClose.aspx.cs" Inherits="rnrtp2.AddClose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title>close a ride</title>
</head>
<body id="AddClose">
    <form id="form1" runat="server">
        <div>
            <h1 style="color:black;">close a ride</h1>
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="Employee ID: "></asp:Label>
                <asp:TextBox ID="eid_textbox" runat="server" required="required"></asp:TextBox><br /><br />

                <asp:Label ID="Label2" runat="server" Text="Ride: "></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList> <br /><br />

                <asp:Label ID="Label3" runat="server" Text="Date: "></asp:Label>
                <input type="date" name="date" id="date" runat="server" value="" style="width:200px;" required="required"/> <br /><br />
                <asp:Label ID="Label4" runat="server" Text="Time: "></asp:Label>
                <asp:TextBox ID="time_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <label for="type">Reason:</label>
                <select id="type" name="type" required="required" runat="server">
                    <option value="maintenance">Maintenance</option>
                    <option value="weather">Weather</option>
                </select><br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Cost: "></asp:Label>
                <asp:TextBox ID="cost" runat="server" name="cost" type="number" required="required" value="0" min="0"></asp:TextBox><br /><br />
               
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />

                <br /><br />
                <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: black;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
            </fieldset>
        </div>
    </form>
</body>
</html>
