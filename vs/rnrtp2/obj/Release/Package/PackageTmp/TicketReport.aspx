<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketReport.aspx.cs" Inherits="rnrtp2.TicketReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
            <asp:Label ID="Label5" runat="server" Text="DATE (yyyy-mm-dd): "></asp:Label>
            <asp:TextBox ID="date_textbox" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="TO DATE (yyyy-mm-dd): "></asp:Label>
            <asp:TextBox ID="date2_textbox" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            <p>
            <h1><% Response.Write(getDate()); %></h1>
            <h2>Cumulative Totals</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> ticket type </td>
                <td> number sold </td>
                <td> total spent </td>
                </tr>

                <% Response.Write(genTotals()); %>
            </table>
                </p>
            <p>
            <h2>Day's Ticket Sales</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> date </td>
                <td> ticket id </td>
                <td> ticket type </td>
                <td> ticket cost </td>
                <td> email </td>
                </tr>

                <% Response.Write(currTotals()); %>
            </table>
                </p>
                <br /><br /><br />
            <a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: black;">GO BACK TO HOME</a>
            </center>

        </div>
    </form>
</body>
</html>
