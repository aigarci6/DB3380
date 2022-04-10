<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketReport.aspx.cs" Inherits="rnrtp2.TicketReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Ticket Type: "></asp:Label>
            <asp:TextBox ID="type_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> ID </td>
                <td> Visit Date </td>
                <td> ticketType </td>
                <td> ticketCost </td>
                <td> Email </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>

        </div>
    </form>
</body>
</html>
