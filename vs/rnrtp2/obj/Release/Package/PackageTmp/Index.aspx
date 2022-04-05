<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="rnrtp2.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <h3>add new</h3>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/AddEmployee.aspx">Add a new employee</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="/AddHotel.aspx">Add a new hotel</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="/AddRestaurant.aspx">Add a new restaurant</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="/AddRide.aspx">Add a new ride</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="/AddVisitor.aspx">Add a new visitor</asp:HyperLink><br /><br />

            <h3>update (will be search -> update & delete operations)</h3>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="/SearchHotel.aspx">Search hotel</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="/SearchRestaurant.aspx">Search restaurant</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="/SearchRide.aspx">Search rides</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="/SearchEmployee.aspx">Search employees</asp:HyperLink><br /><br />
        </div>
    </form>
</body>
</html>
