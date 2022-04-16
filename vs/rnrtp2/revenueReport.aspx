﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="revenueReport.aspx.cs" Inherits="rnrtp2.revenueReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h1>Monthly Revenue Report</h1>
                <label for="month">Month:</label>
                <select name="month" id="month" runat="server" required="required">
                    <option value="">Select</option>
                    <option value="01">1</option>
                    <option value="02">2</option>
                    <option value="03">3</option>
                    <option value="04">4</option>
                    <option value="05">5</option>
                    <option value="06">6</option>
                    <option value="07">7</option>
                    <option value="08">8</option>
                    <option value="09">9</option>
                    <option value="10">10</option>
                    <option value="11">11</option>
                    <option value="12">12</option>
                </select>
                <label for="year">Year:</label>
                <select name="year" id="year" runat="server" required="required">
                    <option value="">Select</option>
                    <option value="2022">2022</option>
                </select> <br />           
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="generatePage"  /> 
            <% Response.Write(generate()); %>
                <!--<p>               
            <h2>XX/YYYY Revenue</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="center" style="background-color: #004080; color: White;">
                <td> Ticket Revenue </td>
                <td> Hotel Revenue </td>
                <td> Restaurant Revenue </td>
                </tr>
            </table>
                </p>
                <p>
            <h2>XX/YYYY Expenditures</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="center" style="background-color: #004080; color: White;">
                <td> Maintanance Costs </td>
                <td> Salary </td>
                <td> Housekeeping </td>
                </tr>
            </table>
                </p>
                <p>
            <h2>XX/YYYY Balance</h2>
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="center" style="background-color: #004080; color: White;">
                <td> Total </td>
                </tr>
            </table>
                </p> -->
            </center>

        </div>
    </form>
</body>
</html>
