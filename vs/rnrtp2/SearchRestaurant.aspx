﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchRestaurant.aspx.cs" Inherits="rnrtp2.SearchRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
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
            background-color: lightyellow;
            font-weight: bold;
            text-transform: uppercase;
            color: #333;
        }

        tr:nth-child(even) {
            background-color: #efefef;
        }
    </style>
</head>
<body id="searchRestaurant">
    <form id="form1" runat="server">
        <div>
            <h1><font color="white">manage restaurants</font></h1>
            <fieldset>
                <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:120px;" id="search" runat="server">
                <option value="none"> </option>
                <option value="id">ID</option>
                <option value="name">Name</option>
                <option value="location">Location ID</option>
                <option value="capacity_greater">Capacity Greater Than</option>
                <option value="capacity_less">Capacity Less Than</option>
                <option value="all">*</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" /><br />
                <asp:CheckBox ID="archived" runat="server" Text ="include archived"/>
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#000" class="table">
            <tr>
                <td> restaurant id </td>
                <td> name </td>
                <td> capacity </td>
                <td> expenditure </td>
                <td> revenue </td>
                <td> location id </td>
                <td> location </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
            <br />

            <!-- UPDATE -->
                <h1>Update:</h1>
                <h3>restaurant information</h3>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label><br />
                <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label><br />
                <asp:TextBox ID="name_textbox" runat="server"></asp:TextBox><br />
                <asp:Label ID="updateerrormessage" font-size="small" runat="server" Text="ERROR: Missing field(s)!" ForeColor="Red"></asp:Label>

                <h3>update</h3>
                <asp:Label ID="Label3" runat="server" Text="Location ID: "></asp:Label><br />
                <asp:TextBox ID="location_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Capacity: "></asp:Label><br />
                <asp:TextBox ID="capacity_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" /><br />

                <!-- DELETE -->
            <h1>Delete:</h1>
                <asp:Label ID="Label8" runat="server" Text="Restaurant ID: "></asp:Label><br />
                <asp:TextBox ID="delete_id" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label9" runat="server" Text="Restaurant Name: "></asp:Label><br />
                <asp:TextBox ID="delete_name" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button3" runat="server" Text="Delete Ride" OnClick="Button3_Click"/><br />
                <asp:Label ID="deleteerrormessage" font-size="small" runat="server" Text="ERROR: Missing field(s)!" ForeColor="Red"></asp:Label>
                <br /><br /><br />
            <a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: white;">GO BACK TO HOME</a>
            </fieldset>
        </div>
    </form>
</body>
</html>
