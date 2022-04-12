<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchLocations.aspx.cs" Inherits="rnrtp2.SearchLocations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title></title>
</head>
<body id="SearchLocations">
    <form id="form1" runat="server">
        <div>
            
            <fieldset>
                <h1>Location information</h1>
                <asp:Label ID="Label1" runat="server" Text="Location ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />

                <h1>Update information</h1>
                <asp:Label ID="Label2" runat="server" Text="Location Name: "></asp:Label>
                <asp:TextBox ID="name_textbox" runat="server" required="required"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
            </fieldset>
        </div>
    </form>
</body>
</html>
