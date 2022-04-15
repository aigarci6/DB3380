<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorCountReport.aspx.cs" Inherits="rnrtp2.VisitorCountReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="color:black;">close a ride</h1>
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="Employee ID: "></asp:Label><br />
                <asp:TextBox ID="eid_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Ride ID: "></asp:Label><br />
                <asp:TextBox ID="rid_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Date: "></asp:Label><br />
                <input type="date" name="date" id="date" runat="server" value="" style="width:200px;" required="required"/> <br /><br />
                <asp:Label ID="Label4" runat="server" Text="Time: "></asp:Label><br />
                <asp:TextBox ID="time_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Type: "></asp:Label><br />
                <asp:TextBox ID="type_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
