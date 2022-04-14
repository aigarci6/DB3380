<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchVisitHotel.aspx.cs" Inherits="rnrtp2.SearchVisitHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id="SearchVisitHotel">
    <h1>manage hotel visits</h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:120px;" id="search" runat="server">
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
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#000" class="table">
            <tr align="left" style="background-color: #004080; color: White;">
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
            <br />

            <!-- UPDATE -->
                <h1>Update:</h1>
                <h3>visitor information</h3>
                <asp:Label ID="Label1" runat="server" Text="Ticket ID: "></asp:Label><br />
                <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Hotel ID: "></asp:Label><br />
                <asp:TextBox ID="hid_textbox" runat="server"></asp:TextBox><br />
                <asp:Label ID="errormessage" runat="server" Text="ERROR: Missing field(s)!" ForeColor="Red"></asp:Label>

                <h3>update</h3>
                <asp:Label ID="Label3" runat="server" Text="Amount Spent: "></asp:Label><br />
                <asp:TextBox ID="spent_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Days Stayed: "></asp:Label><br />
                <asp:TextBox ID="days_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Room Number: "></asp:Label><br />
                <asp:TextBox ID="room_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
            </fieldset>

        </div>
    </form>
</body>
</html>
