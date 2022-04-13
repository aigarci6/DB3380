<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchVisitor.aspx.cs" Inherits="rnrtp2.SearchVisitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id ="SearchVisitor">
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <h2>visitor information</h2>
                <asp:Label ID="Label1" runat="server" Text="Ticket ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Visit Date: "></asp:Label>
                <asp:TextBox ID="date_textbox" runat="server"></asp:TextBox><br /><br />

                <h2>update information</h2>
                <asp:Label ID="Label3" runat="server" Text="Ticket Type: "></asp:Label>
                <asp:TextBox ID="type_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="email_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            </fieldset>
        </div>
    </form>
</body>
</html>
