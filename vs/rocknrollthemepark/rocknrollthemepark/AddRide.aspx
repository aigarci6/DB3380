﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRide.aspx.cs" Inherits="rocknrollthemepark.AddRide" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <h1>add new ride form</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="name_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Capacity: "></asp:Label>
            <asp:TextBox ID="capacity_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label4" runat="server" Text="Location: "></asp:Label>
            <asp:TextBox ID="location_textbox" runat="server"></asp:TextBox><br /><br />

            <h2>requirements</h2>
            <asp:Label ID="Label5" runat="server" Text="Maximum Weight: "></asp:Label>
            <asp:TextBox ID="maxweight_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label6" runat="server" Text="Minimum Height: "></asp:Label>
            <asp:TextBox ID="minheight_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label7" runat="server" Text="Minimum Age: "></asp:Label>
            <asp:TextBox ID="minage_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />

        </div>
    </form>
</body>
</html>