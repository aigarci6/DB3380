<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RideIndex.aspx.cs" Inherits="rnrtp2.RideIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ride staff portal</title>

    <style>
        #newindex {
            background-image: url("newindex.jpg");
            background-size: cover;
            background-position-y:top;
            background-position-x:center;
            background-attachment:fixed;
        }

        body {
            padding-left:2%;
            padding-top:1%;
            padding-bottom:2%;
        }

        .navigationbar {
            height:100%;
            width: 450px;
            background-color: rgb(0,0,0,0.7);
            color: lightblue;
            padding-left:40px;
            padding-top:20px;
            padding-bottom:20px;
        }

        .list {
            color: #f2f2f2;
            width:300px;
            padding-left:5%;
            font-family:font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            text-transform:uppercase;
            font-size:15px;
            line-height:30px;
        }

        .title {
            font-size:50px;
            color: #f2f2f2;
            font-weight: bold;
            margin-bottom:5px;
        }

        a {
            text-decoration: none;
            color:#f2f2f2;
            transition: 0.5s;
        }

        a:hover {
            color:lightblue;
        }

        .logout {
            background-color:#f2f2f2;
            height:25px;
            width:150px;
            text-align:center;
            padding:2%;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            font-weight:bold;
            border-style:solid;
            border-color:#333;
            padding-top:3%;
            transition: 0.6s;
        }

        .logout:hover {
            background-color:lightblue;
        }
    </style>
</head>
<body id ="newindex">
    <div class="title">
        navigate
    </div>
    <div class="navigationbar">

        <h1>rides.</h1>
        <div class="list">
            <a href="SearchRide.aspx">manage rides</a><br />
            <a href="AddClose.aspx">close a ride</a>
        </div>

        <h1>visitor.</h1>
        <div class="list">
            <a href="AddVisitor.aspx">add a new visitor</a><br />
            <a href="SearchVisitor.aspx">manage visitor profiles</a>
        </div>

        <h1>park.</h1>
        <div class="list">
            <a href="SearchLocations.aspx">manage locations</a><br />
        </div>

        

        <h1>reports.</h1>
        <div class="list">
            <a href="TicketReport.aspx">daily ticket report</a>
        </div>
        <br /><br />
        <div class="logout">
            <a href="Login.aspx" style="color:#333;">LOGOUT</a>
        </div>
        <br /><br /><br />
    </div>
        
</body>
</html>
