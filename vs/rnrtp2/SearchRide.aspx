<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchRide.aspx.cs" Inherits="rnrtp2.SearchRide" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title></title>
</head>
<body id="SearchRide">
    <h1>update rides</h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
            <h2>ride information</h2>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
                <asp:TextBox ID="name_textbox" runat="server"></asp:TextBox><br /><br />

                <h2>update information</h2>
                <asp:Label ID="Label3" runat="server" Text="Location ID: "></asp:Label>
                <asp:TextBox ID="location_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Capacity: "></asp:Label>
                <asp:TextBox ID="capacity_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Maximum Weight: "></asp:Label>
                <asp:TextBox ID="maxweight_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label6" runat="server" Text="Minimum Height: "></asp:Label>
                <asp:TextBox ID="minheight_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label7" runat="server" Text="Minimum Age: "></asp:Label>
                <asp:TextBox ID="minage_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            </fieldset>
        </div>
    </form>
</body>
</html>
