﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCredentials.aspx.cs" Inherits="rnrtp2.SearchCredentials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- SEARCH -->
            <h1>Search By:</h1>
            <asp:Label ID="Label5" runat="server" Text="User ID: "></asp:Label>
            <asp:TextBox ID="sid_textbox" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="suser_textbox" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> user id </td>
                <td> username </td>
                <td> password </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>

            <br />

            <!-- UPDATE -->
            <h1>credential information</h1>
            <asp:Label ID="Label1" runat="server" Text="User ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />

            <h1>update information</h1>
            <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="user_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="pass_textbox" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
        </div>
    </form>
</body>
</html>
