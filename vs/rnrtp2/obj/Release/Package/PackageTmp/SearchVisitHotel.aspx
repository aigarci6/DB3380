<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchVisitHotel.aspx.cs" Inherits="rnrtp2.SearchVisitHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title>manage hotel visitors</title>

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
<body id="SearchVisitHotel">
    <h1>manage hotel visits</h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:130px;" id="search" runat="server">
                <option value="none"> </option>
                <option value="vid">Ticket ID</option> 
                <option value="hid">Hotel ID</option>
                <option value="spent_greater">Amount Spent Greater Than</option>
                <option value="spent_less">Amount Spent Less Than</option>
                <option value="days_greater">Days Stayed Greater Than</option>
                <option value="days_less">Days Stayed Less Than</option>
                <option value="room">Room Number</option>
                <option value="all">*</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#000" class="table">
            <tr>
                <td> ticket id </td>
                <td> visitor email </td>
                <td> hotel id </td>
                <td> hotel name </td>
                <td> amount spent </td>
                <td> days stayed </td>
                <td> room number </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
                <br /><br /><br />
            <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: white;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
            </fieldset>

        </div>
    </form>
</body>
</html>
