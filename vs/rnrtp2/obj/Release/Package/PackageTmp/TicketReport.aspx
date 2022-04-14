<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketReport.aspx.cs" Inherits="rnrtp2.TicketReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ticket report</title>

    <style>
        tr {
            background-color: #efefef;
            text-align: left;
            color: #333;
            font-size:small;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        }

        tr:first-child {
            background-color: #333;
            text-transform: uppercase;
            color: #efefef;
        }

        tr:nth-child(even) {
            background-color: lightgray;
        }

        h2 {
            text-transform: uppercase;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        }

        .searchbar {
            width: 55%;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            text-transform: uppercase;
            font-weight: bold;
            font-size: small;
            text-align: center;
            padding-top: 4%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <div class ="searchbar">
            <asp:Label ID="Label5" runat="server" Text="DATE (yyyy-mm-dd): "></asp:Label>
            <input type="date" name="date1" id="date1" runat="server" value="" style="width:100px;"/>
            <asp:Label ID="Label1" runat="server" Text="TO DATE (yyyy-mm-dd): "></asp:Label>
            <input type="date" name="date2" id="date2" runat="server" value="" style="width:100px;"/>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                    </div>
            <br />
            <h1><% Response.Write(getDate()); %></h1><br />
            <h2>Cumulative Totals</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr>
                <td> TICKET TYPE </td>
                <td> NUMBER SOLD </td>
                <td> TOTAL SPENT </td>
                </tr>

                <% Response.Write(genTotals()); %>
            </table>
                
            <br /><br />
            <h2>Day's Ticket Sales</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr>
                <td> DATE </td>
                <td> TICKET ID </td>
                <td> TICKET TYPE </td>
                <td> TICKET COST </td>
                <td> VISITOR EMAIL </td>
                </tr>

                <% Response.Write(currTotals()); %>
            </table>
                
                <br /><br /><br />
            <a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: black;">GO BACK TO HOME</a>
            </center>

        </div>
    </form>
</body>
</html>
