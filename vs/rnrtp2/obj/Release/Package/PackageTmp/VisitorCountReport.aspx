<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorCountReport.aspx.cs" Inherits="rnrtp2.VisitorCountReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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

            <h2>Number of Visitors per Hotel</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr>
                <td> Visit Date </td>
                <td> Hotel Name </td>
                <td> Hotel Id </td>
                <td> Number of Visitors </td>
                </tr>

                <% Response.Write(getHotel()); %>
            </table>

            <br /><br />
                <br /><br /><br />
            <a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: black;">GO BACK TO HOME</a>
            </center>
        </div>
    </form>
</body>
</html>
