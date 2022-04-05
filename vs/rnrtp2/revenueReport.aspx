<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="revenueReport.aspx.cs" Inherits="rnrtp2.revenueReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Revenue Report</title>
    <link rel="stylesheet" href="index.css">
</head>
<body>
    <h1>Generate Revenue Report</h1>
    <form id="form1" runat="server">
        <div>
            <label for="startDate: ">Report Start Date</label>
            <input type="date" name="startDate" id="startDate" value="" runat="server" required="required" /> <br />
            <label for="endDate">Report End Date</label>
            <input type="date" name="endDate" id="endDate" value="" runat="server" required="required" /> <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
