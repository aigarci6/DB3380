﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCredentials.aspx.cs" Inherits="rnrtp2.SearchCredentials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>

    <style>
        table {
            border-collapse: collapse;
        }

        tr {
            background-color: lightgray;
            text-align: left;
            color: #333;
            font-size:small;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        }

        td {
            padding: 5px;
        }

        tr:first-child {
            background-color: lightblue;
            font-weight: bold;
            text-transform: uppercase;
            color: #333;
        }

        tr:nth-child(even) {
            background-color: #efefef;
        }
    </style>
</head>
<body id="searchCred">
    <form id="form1" runat="server">
        <div>
            <!-- SEARCH -->
            <h1>Search By:</h1>
            <asp:Label ID="Label5" runat="server" Text="User ID: "></asp:Label>
            <asp:TextBox ID="sid_textbox" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="suser_textbox" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr>
                <td> user id </td>
                <td> username </td>
                <td> password </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>

            <br />

            <!-- UPDATE -->
            <h1>Update:</h1>
            <h3>credential information</h3>
            <asp:Label ID="Label1" runat="server" Text="User ID: "></asp:Label><br />
            <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="errormessage" font-size="small" runat="server" Text="ERROR: Missing field(s)!" ForeColor="Red"></asp:Label>

            <h3>update</h3>
            <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label><br />
            <asp:TextBox ID="user_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label><br />
            <asp:TextBox ID="pass_textbox" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
            <br /><br /><br />
            <a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: white;">GO BACK TO HOME</a>
        </div>
    </form>
</body>
</html>
