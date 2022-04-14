<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="rnrtp2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
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
                        <h3>Monday-Friday: 10 am - 8pm</h3>
                        <h3>Saturday-Sunday: 10 am - 10pm</h3>
                        <br />
                        <h1>RESTAURANT HOURS</h1>
                        <h3>Monday-Friday: 9 am - 10pm</h3>
                        <h3>Saturday-Sunday: 10 am - 12pm</h3>
                    </div>
                    </div>


                <div class="maincol">
                    <div class="boxes">
                        <h1>TICKET PRICING</h1>
                        <h3>General Admission: $50</h3>
                        - One-Day Admission
                        <br /><br />
                        <h3>Seasonal Admission: $300</h3>
                        - 6-month Admission from date of purchase
                </div>
            </div>
            </div>
                
            <br /><br />
            <div class ="mainnav2">
                <div class="maincol2">
                    <center><h1 style="color:#f2f2f2;">Ride Closures</h1></center>
                        <table width="80%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
                        <tr align="left" style="background-color: #004080; color: White;">
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
