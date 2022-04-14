<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="rnrtp2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
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
<body id ="homepage">
    <form id="form1" runat="server">
        <div>

            <div class="mainnav">
            <a class="title" href="Home.aspx">ROCK N ROLL THEMEPARK</a>
            <a class="login" href ="Login.aspx">LOGIN</a>
            </div>
            <br /><br />
            
            <div class="mainnav2">
                <div class="maincol">
                    <div class="boxes">
                        <h1>PARK HOURS</h1>
                        <h3>Monday-Friday: 10am - 8pm</h3>
                        <h3>Saturday-Sunday: 10am - 10pm</h3>
                        <br />
                        <h1>RESTAURANT HOURS</h1>
                        <h3>Monday-Friday: 9am - 10pm</h3>
                        <h3>Saturday-Sunday:10 am - 12pm</h3>
                    </div>
                    </div>


                <div class="maincol">
                    <div class="boxes">
                        <h1>TICKET PRICING</h1>
                        <h3>General Admission: $50</h3>
                        - One-Day Admission
                        <br /><br />
                        <h3>Seasonal Admission: $300</h3>
                        - 6-month Admission From Date of Purchase
                </div>
            </div>
            </div>
                
            <br /><br />
            <div class ="mainnav2">
                <div class="maincol2">
                    <center><h1 style="color:#f2f2f2;">Ride Closures</h1></center>
                        <table width="80%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
                        <tr>
                            <td> DATE </td>
                            <td> RIDE NAME </td>
                            </tr>

                            <% Response.Write(getClosures()); %>
                        </table>
                    <br />
                    <center><asp:Label ID="errormessage" runat="server" Text="NO RIDE CLOSURES SCHEDULED." ForeColor="#f2f2f2"></asp:Label></center>
                </div>
            </div>
            <br /><br />
            <div></div>
            <div></div>
            <br /><br />
        </div>
    </form>
</body>
</html>
