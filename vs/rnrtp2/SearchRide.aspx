﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchRide.aspx.cs" Inherits="rnrtp2.SearchRide" %>

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
                <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:120px;" id="search" runat="server">
                <option value="none"> </option>
                <option value="id">ID</option> 
                <option value="name">Name</option>
                <option value="location">Location ID</option>
                <option value="weight_greater">Max Weight Greater Than</option>
                <option value="weight_less">Max Weight Less Than</option>
                <option value="height_greater">Min Height Greater Than</option>
                <option value="height_less">Min Height Less Than</option>
                <option value="age_greater">Min Age Greater Than</option>
                <option value="age_less">Min Age Less Than</option>
                <option value="capacity_greater">Capacity Greater Than</option>
                <option value="capacity_less">Capacity Less Than</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" /><br />
                <asp:CheckBox ID="archived" runat="server" Text ="include archived"/>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#000" class="table">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> ride id </td>
                <td> name </td>
                <td> capacity </td>
                <td> max weight </td>
                <td> min height </td>
                <td> min age </td>
                <td> location id </td>
                <td> location </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
            <br />

            <!-- UPDATE -->

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
