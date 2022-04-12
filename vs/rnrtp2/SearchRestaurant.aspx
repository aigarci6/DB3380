<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchRestaurant.aspx.cs" Inherits="rnrtp2.SearchRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title></title>
</head>
<body id="searchRestaurant">
    <form id="form1" runat="server">
        <div>
            <h1><font color="black">Update restaurant</font></h1>
            <fieldset>
                <h2>Restaurant information</h2>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
                <asp:TextBox ID="name_textbox" runat="server"></asp:TextBox><br /><br />

                <h2>Update information</h2>
                <asp:Label ID="Label3" runat="server" Text="Location ID: "></asp:Label>
                <asp:TextBox ID="location_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Capacity: "></asp:Label>
                <asp:TextBox ID="capacity_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            </fieldset>
        </div>
    </form>
</body>
</html>
