<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVisitor.aspx.cs" Inherits="rnrtp2.AddVisitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>add new visitor form</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Visit Date: "></asp:Label>
            <asp:TextBox ID="date_textbox" runat="server"></asp:TextBox> <br /><br />
            <asp:Label ID="Label2" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox> <br /><br />
            <asp:Label ID="Label3" runat="server" Text="Ticket Type: "></asp:Label>
            <asp:TextBox ID="type_textbox" runat="server"></asp:TextBox> <br /><br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
