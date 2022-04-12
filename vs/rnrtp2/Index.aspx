<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="rnrtp2.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title></title>
</head>
<body id="index">
     <form id="form1" runat="server">

         <nav id="mainNav">
    <div class="container">
        <ul>
            <li><a href="AddVisitor.aspx" class="indexLink">Add Visitor</a></li>
            <li><a href="AddRide.aspx" class="indexLink">Add Ride</a></li>
            <li><a href="AddRestaurant.aspx" class="indexLink">Add Restaurant</a></li>
            <li><a href="AddEmployee.aspx" class="indexLink">Add Staff</a></li>
            <li><a href="AddHotel.aspx" class="indexLink">Add Hotel</a></li>
            <li> <a href="" class="indexLink">Hotel Visit</a></li>
            <li><a href="" class="indexLink">Restaurant Visit</a></li>
            <li><a href="" class="indexLink">Closing a Ride</a></li>
        </ul>
    </div>
</nav>










     <nav id="mainNav1">
       <div class="container1">
            <h3>add new</h3>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/AddEmployee.aspx">Add a new employee</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="/AddHotel.aspx">Add a new hotel</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="/AddRestaurant.aspx">Add a new restaurant</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="/AddRide.aspx">Add a new ride</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="/AddVisitor.aspx">Add a new visitor</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="/AddVisitHotel.aspx">Add a new hotel visitor</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="/AddVisitRestauraunt.aspx">Add a new restaurant visitor</asp:HyperLink><br /><br />

            <h3>update (will be search -> update & delete operations)</h3>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="/SearchHotel.aspx">Search hotel</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="/SearchRestaurant.aspx">Search restaurant</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="/SearchRide.aspx">Search rides</asp:HyperLink><br /><br />
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="/SearchEmployee.aspx">Search employees</asp:HyperLink><br /><br />
         </div>
     </nav>

    </form>
</body>
</html>
