<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="rocknrollthemepark.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/AddEmployee.aspx">Add a new employee</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="/AddHotel.aspx">Add a new hotel</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="/AddRestaurant.aspx">Add a new restaurant</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="/AddRide.aspx">Add a new ride</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="/AddVisitor.aspx">Add a new visitor</asp:HyperLink><br /><br />
        </div>
    </form>
</body>
</html>
