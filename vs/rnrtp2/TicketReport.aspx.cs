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
    public partial class TicketReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public string genTotals()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand genTotals = new MySqlCommand("SELECT COUNT(*) AS totalNum, SUM(ticketCost) FROM visitor WHERE ticketType = @ticketType;", dbcon);
            MySqlCommand seasTotals = new MySqlCommand("SELECT COUNT(*) AS totalNum, SUM(ticketCost) FROM visitor WHERE ticketType = @ticketType;", dbcon);
            genTotals.Parameters.AddWithValue("@ticketType", "general");
            seasTotals.Parameters.AddWithValue("@ticketType", "seasonal");

            string htmlStr = "";

            dbcon.Open();

            //general
            MySqlDataReader genReader = genTotals.ExecuteReader();
            genReader.Read();
            int gtotalNum = genReader.GetInt32(0);
            int gsum = genReader.GetInt32(1);
            htmlStr += "<tr><td>" + "general" + "</td><td>" + gtotalNum + "</td><td> $" + gsum + "</td></tr>";
            genReader.Close();

            //seasonal
            MySqlDataReader seasReader = seasTotals.ExecuteReader();
            seasReader.Read();
            int stotalNum = seasReader.GetInt32(0);
            int ssum = seasReader.GetInt32(1);
            htmlStr += "<tr><td>" + "general" + "</td><td>" + stotalNum + "</td><td> $" + ssum + "</td></tr>";
            seasReader.Close();

            int totalNum = gtotalNum + stotalNum;
            int totalSum = gsum + ssum;
            htmlStr += "<tr><td>" + "total" + "</td><td>" + totalNum + "</td><td> $" + totalSum + "</td></tr>";

            dbcon.Close();
            return htmlStr;
        }

        public string getDate()
        {
            //parse date
            DateTime thisDay = DateTime.Today;
            string fin = thisDay.ToString("dddd") + ", " + thisDay.ToString("MMMM") + " " + thisDay.ToString("dd") + ", " + thisDay.ToString("yyyy");
            return fin;
        }

        public string currTotals()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            
            //find date
            DateTime thisDay = DateTime.Today;
            string date = thisDay.ToString("yyyy") + "-" + thisDay.ToString("dd") + "-" + thisDay.ToString("MM");

            MySqlCommand genTickets = new MySqlCommand("SELECT ticketID, ticketType, ticketCost, email FROM visitor WHERE visitDate = @date AND ticketType = @ticketType;", dbcon);
            genTickets.Parameters.AddWithValue("@ticketType", "general");
            genTickets.Parameters.AddWithValue("@date", date);
            MySqlCommand seasTickets = new MySqlCommand("SELECT ticketID, ticketType, ticketCost, email FROM visitor WHERE visitDate = @date AND ticketType = @ticketType;", dbcon);
            seasTickets.Parameters.AddWithValue("@ticketType", "seasonal");
            seasTickets.Parameters.AddWithValue("@date", date);

            string htmlStr = "";

            dbcon.Open();

            //general
            MySqlDataReader genReader = genTickets.ExecuteReader();
            int genTotal = 0;
            int genCount = 0;
            while (genReader.Read())
            {
                int id = genReader.GetInt32(0);
                string type = genReader.GetString(1);
                int cost = genReader.GetInt32(2);
                string email = genReader.GetString(3);

                genTotal += cost;
                genCount += 1;

                htmlStr += "<tr><td>" + id + "</td><td>" + type + "</td><td>" + cost + "</td><td>" + email + "</td></tr>";
            }
            genReader.Close();

            //seasonal
            MySqlDataReader seasReader = seasTickets.ExecuteReader();
            int seasTotal = 0;
            int seasCount = 0;
            while (seasReader.Read())
            {
                int id = seasReader.GetInt32(0);
                string type = seasReader.GetString(1);
                int cost = seasReader.GetInt32(2);
                string email = seasReader.GetString(3);

                seasTotal += cost;
                seasCount += 1;

                htmlStr += "<tr><td>" + id + "</td><td>" + type + "</td><td>" + cost + "</td><td>" + email + "</td></tr>";
            }
            seasReader.Close();

            int total = genTotal + seasTotal;
            int totCount = genCount + seasCount;
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + genCount + " total general sales" + "</td><td> $" + genTotal + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + seasCount + " total seasonal sales" + "</td><td> $" + seasTotal + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + totCount + " total sales" + "</td><td> $" + total + "</td></tr>";

            dbcon.Close();
            return htmlStr;
        }
    }
}