using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace rnrtp2
{
    public partial class revenueReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string jcategory = "";
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            dbcon.Open();
            MySqlCommand search = new MySqlCommand("SELECT jobCategory FROM credentials WHERE userName = @username", dbcon);
            search.Parameters.AddWithValue("@username", (string)Session["username"]);
            MySqlDataReader sReader = search.ExecuteReader();
            while (sReader.Read())
            {
                jcategory = sReader.GetString(0);
            }
            sReader.Close();

            if (jcategory != "HR" && jcategory != "hotel" && jcategory != "ride" && jcategory != "restaurant")
            {
                Response.Redirect("BadAccessP.aspx");
            }
        }

        protected void generatePage(object sender, EventArgs e)
        {

        }

        public string generate()
        {
            if (month.Value.Length == 0 || year.Value.Length == 0)
            {
                return "<h3>Please enter date above. </h3 >";
            }

            string munth = month.Value;
            string yeer = year.Value;
            string html = "";

            //estableshing connection and creating Queries
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand ticketRev = new MySqlCommand("SELECT IFNULL(SUM(ticketCost), 0) FROM visitor WHERE month = @munth AND year = @yeer;", dbcon);
            MySqlCommand generalCount = new MySqlCommand("SELECT COUNT(ticketType) FROM visitor WHERE month = @munth AND year = @yeer AND ticketType='general';", dbcon);
            MySqlCommand seasonalCount = new MySqlCommand("SELECT COUNT(ticketType) FROM visitor WHERE month = @munth AND year = @yeer AND ticketType='seasonal';", dbcon);
            MySqlCommand hotelRev = new MySqlCommand("SELECT IFNULL(SUM(amountSpent), 0) FROM visit_hotel, visitor WHERE visit_hotel.tickID_h = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            MySqlCommand hotelCount = new MySqlCommand("SELECT COUNT(visitID) FROM visit_hotel, visitor WHERE visit_hotel.tickID_h = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            MySqlCommand hotelNightsCount = new MySqlCommand("SELECT IFNULL(SUM(daysStayed), 0) FROM visit_hotel, visitor WHERE visit_hotel.tickID_h = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            MySqlCommand restRev = new MySqlCommand("SELECT IFNULL(SUM(amountSpent), 0) FROM visit_restaurant, visitor WHERE visit_restaurant.tickID_r = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            MySqlCommand restCount = new MySqlCommand("SELECT COUNT(visitID) FROM visit_restaurant, visitor WHERE visit_restaurant.tickID_r = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            MySqlCommand maintCost = new MySqlCommand("SELECT IFNULL(SUM(cost), 0) FROM closes WHERE closes.month=@munth AND closes.year=@yeer;", dbcon);
            MySqlCommand maintCount = new MySqlCommand("SELECT COUNT(closeID) FROM closes WHERE closes.month=@munth AND closes.year=@yeer;", dbcon);
            MySqlCommand salCost = new MySqlCommand("SELECT IFNULL(SUM(weeklySalary), 0) FROM staff WHERE archived=0;", dbcon);
            MySqlCommand salCount = new MySqlCommand("SELECT COUNT(employeeID) FROM staff WHERE archived=0;", dbcon);
            MySqlCommand restCost = new MySqlCommand("SELECT IFNULL(SUM(r_expenditure), 0) FROM restaurant WHERE archived=0;", dbcon);
            MySqlCommand restNumbers = new MySqlCommand("SELECT COUNT(restaurantID) FROM restaurant WHERE archived=0;", dbcon);
            MySqlCommand hotelCost = new MySqlCommand("SELECT IFNULL(SUM(h_expenditure), 0) FROM hotel WHERE archived=0;", dbcon);
            MySqlCommand hotelNumbers = new MySqlCommand("SELECT COUNT(hotelID) FROM hotel WHERE archived=0;", dbcon);
            ticketRev.Parameters.AddWithValue("@munth", munth);
            ticketRev.Parameters.AddWithValue("@yeer", yeer);
            generalCount.Parameters.AddWithValue("@munth", munth);
            generalCount.Parameters.AddWithValue("@yeer", yeer);
            seasonalCount.Parameters.AddWithValue("@munth", munth);
            seasonalCount.Parameters.AddWithValue("@yeer", yeer);
            restRev.Parameters.AddWithValue("@munth", munth);
            restRev.Parameters.AddWithValue("@yeer", yeer);
            restCount.Parameters.AddWithValue("@munth", munth);
            restCount.Parameters.AddWithValue("@yeer", yeer);
            hotelRev.Parameters.AddWithValue("@munth", munth);
            hotelRev.Parameters.AddWithValue("@yeer", yeer);
            hotelCount.Parameters.AddWithValue("@munth", munth);
            hotelCount.Parameters.AddWithValue("@yeer", yeer);
            hotelNightsCount.Parameters.AddWithValue("@munth", munth);
            hotelNightsCount.Parameters.AddWithValue("@yeer", yeer);
            maintCost.Parameters.AddWithValue("@munth", munth);
            maintCost.Parameters.AddWithValue("@yeer", yeer);
            maintCount.Parameters.AddWithValue("@munth", munth);
            maintCount.Parameters.AddWithValue("@yeer", yeer);

            //opening connection and running queries
            dbcon.Open();
            MySqlDataReader ticketReader = ticketRev.ExecuteReader();
            ticketReader.Read();
            int ticketSum = ticketReader.GetInt32(0);
            ticketReader.Close();

            MySqlDataReader generalReader = generalCount.ExecuteReader();
            generalReader.Read();
            int generalSum = generalReader.GetInt32(0);
            generalReader.Close();

            MySqlDataReader seasonalReader = seasonalCount.ExecuteReader();
            seasonalReader.Read();
            int seasonalSum = seasonalReader.GetInt32(0);
            seasonalReader.Close();

            MySqlDataReader hotelReader = hotelRev.ExecuteReader();
            hotelReader.Read();
            int hotelSum = hotelReader.GetInt32(0);
            hotelReader.Close();

            MySqlDataReader hotelCountReader = hotelCount.ExecuteReader();
            hotelCountReader.Read();
            int hotelCountSum = hotelCountReader.GetInt32(0);
            hotelCountReader.Close();

            MySqlDataReader hotelNightsCountReader = hotelNightsCount.ExecuteReader();
            hotelNightsCountReader.Read();
            int hotelNightsCountSum = hotelNightsCountReader.GetInt32(0);
            hotelNightsCountReader.Close();

            MySqlDataReader restReader = restRev.ExecuteReader();
            restReader.Read();
            int restSum = restReader.GetInt32(0);
            restReader.Close();

            MySqlDataReader restCountReader = restCount.ExecuteReader();
            restCountReader.Read();
            int restCountSum = restCountReader.GetInt32(0);
            restCountReader.Close();

            MySqlDataReader maintReader = maintCost.ExecuteReader();
            maintReader.Read();
            int maintSum = maintReader.GetInt32(0);
            maintReader.Close();

            MySqlDataReader maintCountReader = maintCount.ExecuteReader();
            maintCountReader.Read();
            int maintCountSum = maintCountReader.GetInt32(0);
            maintCountReader.Close();

            MySqlDataReader salReader = salCost.ExecuteReader();
            salReader.Read();
            int salSum = salReader.GetInt32(0);            
            salReader.Close();

            MySqlDataReader salCountReader = salCount.ExecuteReader();
            salCountReader.Read();
            int salCountSum = salCountReader.GetInt32(0);            
            salCountReader.Close();

            MySqlDataReader hotelReaderCost = hotelCost.ExecuteReader();
            hotelReaderCost.Read();
            int hotelSumCost = hotelReaderCost.GetInt32(0);           
            hotelReaderCost.Close();

            MySqlDataReader hotelNumbersReader = hotelNumbers.ExecuteReader();
            hotelNumbersReader.Read();
            int hotelNumberSum = hotelNumbersReader.GetInt32(0);
            hotelNumbersReader.Close();

            MySqlDataReader restReaderCost = restCost.ExecuteReader();
            restReaderCost.Read();
            int restSumCost = restReaderCost.GetInt32(0);            
            restReaderCost.Close();

            MySqlDataReader restNumbersReader = restNumbers.ExecuteReader();
            restNumbersReader.Read();
            int restNumbersSum = restNumbersReader.GetInt32(0);
            restNumbersReader.Close();

            dbcon.Close();
            int housekeeping = hotelSumCost + restSumCost; //total housekeeping including restaurants and hotels; ride costs covered in maintenance

            //setting up revenue
            html += "<p><h2>" + munth + "/" + yeer + " Revenue </h2>" +
                "<table width=\"50%\" align=\"center\" cellpadding=\"2\" cellspacing=\"2\" border=\"0\" bgcolor=\"#EAEAEA\">" +
                "<tr>" +
                "<td> Ticket Revenue </td>" +
                "<td> Hotel Revenue </td>" +
                "<td> Restaurant Revenue </td>" +
                "</tr>" +
                "<tr>" +
                "<td> " + ticketSum + " </td>" +
                "<td> " + hotelSum + " </td>" +
                "<td> " + restSum + " </td>" +
                "</tr>" +
                "</tr>" +
                "<tr>" +
                "<td> " + generalSum + " general & " + seasonalSum + " seasonal" + " </td>" +
                "<td> " + hotelCountSum + " visitor stayed " + hotelNightsCountSum + " nights" + " </td>" +
                "<td> " + restCountSum + " visitors spent an avg. " + restSum/restCountSum + "$" + " </td>" +
                "</tr>" +
                "</table>" +
                "</p>" + "<br /><br />";
            //setting up deficit
            html += "<p><h2>" + munth + "/" + yeer + " Expenditures </h2>" +
                "<table width=\"50%\" align=\"center\" cellpadding=\"2\" cellspacing=\"2\" border=\"0\" bgcolor=\"#EAEAEA\">" +
                "<tr>" +
                "<td> Maintanance Costs </td>" +
                "<td> Salaries </td>" +
                "<td> Housekeeping </td>" +
                "</tr>" +
                "<tr>" +
                "<td> " + maintSum + " </td>" +
                "<td> " + salSum * 4 + " </td>" + //times 4 cuz 4 weeks in a month and its weekly salary
                "<td> " + housekeeping + " </td>" +
                "</tr>" +
                "<tr>" +
                "<td> " + maintCountSum + " ride closures with avg. cost " + maintSum/maintCountSum + "$" + " </td>" +
                "<td> " + salCountSum + " employees with avg weekly salary " + salSum/salCountSum + "$" + " </td>" +
                "<td> " + hotelNumberSum + " hotels & " + restNumbersSum + " restaurants" + " </td>" +
                "</tr>" +
                "</table>" +
                "</p>" + "<br /><br />";
            //showing total balance for month
            int balance = ticketSum+hotelSum+restSum-maintSum-salSum-housekeeping;
            html += "<p><h2>" + munth + "/" + yeer + " Balance </h2>" +
                "<table width=\"25%\" align=\"center\" cellpadding=\"2\" cellspacing=\"2\" border=\"0\" bgcolor=\"#EAEAEA\">" +
                "<tr>" +
                "<td> Balance </td>" +                
                "</tr>" +
                "<tr>" +
                "<td> " + balance + " </td>" +             
                "</tr>" +
                "</table>" +
                "</p>" + "<br /><br />";
            



            return html;
        }

        protected void HomeLink(object sender, EventArgs e)
        {
            string jcategory = "";
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            dbcon.Open();
            MySqlCommand search = new MySqlCommand("SELECT jobCategory FROM credentials WHERE userName = @username", dbcon);
            search.Parameters.AddWithValue("@username", (string)Session["username"]);
            MySqlDataReader sReader = search.ExecuteReader();
            while (sReader.Read())
            {
                jcategory = sReader.GetString(0);
            }
            sReader.Close();

            if (jcategory == "HR")
            {
                Response.Redirect("Index.aspx");
            }

            if (jcategory == "hotel")
            {
                Response.Redirect("HotelIndex.aspx");
            }

            if (jcategory == "restaurant")
            {
                Response.Redirect("RestIndex.aspx");
            }

            if (jcategory == "ride")
            {
                Response.Redirect("RideIndex.aspx");
            }
        }
    }
}
