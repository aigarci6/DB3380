<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketReport.aspx.cs" Inherits="rnrtp2.TicketReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center><h1>Daily Ticket Totals Report For <% Response.Write(getDate()); %></h1>
            <h2>Cumulative Totals</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> ticket type </td>
                <td> number sold </td>
                <td> total spent </td>
                </tr>

                <% Response.Write(genTotals()); %>
            </table>

            <h2>Today's Ticket Sales</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> ticket id </td>
                <td> ticket type </td>
                <td> ticket cost </td>
                <td> email </td>
                </tr>

                <% Response.Write(currTotals()); %>
            </table>
            </center>

        </div>
    </form>
</body>
</html>
