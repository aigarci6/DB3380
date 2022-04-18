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
            MySqlCommand hotelRev = new MySqlCommand("SELECT IFNULL(SUM(amountSpent), 0) FROM visit_hotel, visitor WHERE visit_hotel.tickID_h = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            MySqlCommand restRev = new MySqlCommand("SELECT IFNULL(SUM(amountSpent), 0) FROM visit_restaurant, visitor WHERE visit_restaurant.tickID_r = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            MySqlCommand maintCost = new MySqlCommand("SELECT IFNULL(SUM(cost), 0) FROM closes WHERE closes.month=@munth AND closes.year=@yeer;", dbcon);
            MySqlCommand salCost = new MySqlCommand("SELECT IFNULL(SUM(weeklySalary), 0) FROM staff WHERE archived=0;", dbcon);
            MySqlCommand restCost = new MySqlCommand("SELECT IFNULL(SUM(r_expenditure), 0) FROM restaurant WHERE archived=0;", dbcon);
            MySqlCommand hotelCost = new MySqlCommand("SELECT IFNULL(SUM(h_expenditure), 0) FROM hotel WHERE archived=0;", dbcon);
            ticketRev.Parameters.AddWithValue("@munth", munth);
            ticketRev.Parameters.AddWithValue("@yeer", yeer);
            restRev.Parameters.AddWithValue("@munth", munth);
            restRev.Parameters.AddWithValue("@yeer", yeer);
            hotelRev.Parameters.AddWithValue("@munth", munth);
            hotelRev.Parameters.AddWithValue("@yeer", yeer);
            maintCost.Parameters.AddWithValue("@munth", munth);
            maintCost.Parameters.AddWithValue("@yeer", yeer);

            //opening connection and running queries
            dbcon.Open();
            MySqlDataReader ticketReader = ticketRev.ExecuteReader();
            ticketReader.Read();
            int ticketSum = ticketReader.GetInt32(0);
            ticketReader.Close();

            MySqlDataReader hotelReader = hotelRev.ExecuteReader();
            hotelReader.Read();
            int hotelSum = hotelReader.GetInt32(0);
            hotelReader.Close();

            MySqlDataReader restReader = restRev.ExecuteReader();
            restReader.Read();
            int restSum = restReader.GetInt32(0);
            restReader.Close();

            MySqlDataReader maintReader = maintCost.ExecuteReader();
            maintReader.Read();
            int maintSum = maintReader.GetInt32(0);
            maintReader.Close();

            MySqlDataReader salReader = salCost.ExecuteReader();
            salReader.Read();
            int salSum = salReader.GetInt32(0);
            salSum = salSum * 4; //times 4 cuz 4 weeks in a month
            salReader.Close();

            MySqlDataReader hotelReaderCost = hotelCost.ExecuteReader();
            hotelReaderCost.Read();
            int hotelSumCost = hotelReaderCost.GetInt32(0);
            
            hotelReaderCost.Close();

            MySqlDataReader restReaderCost = restCost.ExecuteReader();
            restReaderCost.Read();
            int restSumCost = restReaderCost.GetInt32(0);
            
            restReaderCost.Close();
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
                "<td> " + salSum + " </td>" +
                "<td> " + housekeeping + " </td>" +
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
