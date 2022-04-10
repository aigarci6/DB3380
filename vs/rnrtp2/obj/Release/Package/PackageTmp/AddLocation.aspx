<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLocation.aspx.cs" Inherits="rnrtp2.AddLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>add new location</h1>
            <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Location Name: "></asp:Label>
            <asp:TextBox ID="name_textbox" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
