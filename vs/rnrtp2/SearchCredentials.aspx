<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCredentials.aspx.cs" Inherits="rnrtp2.SearchCredentials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>credential information</h1>
            <asp:Label ID="Label1" runat="server" Text="User ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />

            <h1>update information</h1>
            <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="user_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="pass_textbox" runat="server" required="required"></asp:TextBox><br /><br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
        </div>
    </form>
</body>
</html>
