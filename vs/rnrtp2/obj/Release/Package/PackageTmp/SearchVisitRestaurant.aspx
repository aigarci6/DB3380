﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchVisitRestaurant.aspx.cs" Inherits="rnrtp2.SearchVisitRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id="SearchVisitRestaurant">
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:120px;" id="search" runat="server">
                <option value="none"> </option>
                <option value="vid">Ticket ID</option> 
                <option value="rid">Restaurant ID</option>
                <option value="spent_greater">Amount Spent Greater Than</option>
                <option value="spent_less">Amount Spent Less Than</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#000" class="table">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> ticket id </td>
                <td> visitor email </td>
                <td> restaurant id </td>
                <td> restaurant name </td>
                <td> amount spent </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
            <br />

            <!-- UPDATE -->
                <h1>visitor information</h1>
                <asp:Label ID="Label1" runat="server" Text="Ticket ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Restaurant ID: "></asp:Label>
                <asp:TextBox ID="rid_textbox" runat="server"></asp:TextBox><br /><br />

                <h1>update information</h1>
                <asp:Label ID="Label3" runat="server" Text="Amount Spent: "></asp:Label>
                <asp:TextBox ID="spent_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
            </fieldset>
        </div>
    </form>
</body>
</html>
