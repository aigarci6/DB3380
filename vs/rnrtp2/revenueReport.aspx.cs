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

        }

        protected void generatePage(object sender, EventArgs e)
        {

        }

        public string generate()
        {
            if (month.Value.Length == 0 || year.Value.Length == 0)
            {
                return "<h1>Please enter date above </h1 >";
            }

            string munth = month.Value;
            string yeer = year.Value;
            string html = "";

            //estableshing connection and creating Queries
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand ticketRev = new MySqlCommand("SELECT IFNULL(SUM(ticketCost), 0) FROM visitor WHERE month = @munth AND year = @yeer;", dbcon);
            MySqlCommand hotelRev = new MySqlCommand("SELECT IFNULL(SUM(amountSpent), 0) FROM visit_hotel, visitor WHERE visit_hotel.tickID_h = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            MySqlCommand restRev = new MySqlCommand("SELECT IFNULL(SUM(amountSpent), 0) FROM visit_restaurant, visitor WHERE visit_restaurant.tickID_r = visitor.ticketID and visitor.month = @munth AND visitor.year = @yeer;", dbcon);
            ticketRev.Parameters.AddWithValue("@munth", munth);
            ticketRev.Parameters.AddWithValue("@yeer", yeer);
            restRev.Parameters.AddWithValue("@munth", munth);
            restRev.Parameters.AddWithValue("@yeer", yeer);
            hotelRev.Parameters.AddWithValue("@munth", munth);
            hotelRev.Parameters.AddWithValue("@yeer", yeer);

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
            dbcon.Close();

            //setting up revenue
            html += "<p><h2>" + munth + "/" + yeer + " Revenue </h2>" +
                "<table width=\"50%\" align=\"center\" cellpadding=\"2\" cellspacing=\"2\" border=\"0\" bgcolor=\"#EAEAEA\">" +
                "<tr align=\"center\" style=\"background-color: #004080; color: White;\">" +
                "<td> Ticket Revenue </td>" +
                "<td> Hotel Revenue </td>" +
                "<td> Restaurant Revenue </td>" +
                "</tr>" +
                "<tr align=\"center\" style=\"background-color: grey; color: White;\">" +
                "<td> " + ticketSum + " </td>" +
                "<td> " + hotelSum + " </td>" +
                "<td> " + restSum + " </td>" +
                "</tr>" +
                "</table>" +
                "</p>";
            //setting up deficit
            html += "<p><h2>" + munth + "/" + yeer + " Expenditures </h2>" +
                "<table width=\"50%\" align=\"center\" cellpadding=\"2\" cellspacing=\"2\" border=\"0\" bgcolor=\"#EAEAEA\">" +
                "<tr align=\"center\" style=\"background-color: #004080; color: White;\">" +
                "<td> Maintanance Costs </td>" +
                "<td> Salaries </td>" +
                "<td> Housekeeping </td>" +
                "</tr>" +
                "<tr align=\"center\" style=\"background-color: grey; color: White;\">" +
                "<td> " + ticketSum + " </td>" +
                "<td> " + hotelSum + " </td>" +
                "<td> " + restSum + " </td>" +
                "</tr>" +
                "</table>" +
                "</p>";
            /*<p>
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
                </p>*/



            return html;
        }
    }
}