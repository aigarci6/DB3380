using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Web.SessionState;

namespace rnrtp2
{
    public partial class TicketReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //auth
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


        public string genTotals()
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
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
            htmlStr += "<tr><td>" + "seasonal" + "</td><td>" + stotalNum + "</td><td> $" + ssum + "</td></tr>";
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
            string fin;
            
            if (date1.Value.Length > 0 && date2.Value.Length == 0) {
                fin = "Daily Ticket Totals Report For " + date1.Value;
            }

            else if (date1.Value.Length > 0 && date2.Value.Length > 0)
            {
                fin = "Daily Ticket Totals Report For " + date1.Value + " - " + date2.Value;
            }

            else
            {
                fin = "Daily Ticket Totals Report For " + thisDay.ToString("dddd") + ", " + thisDay.ToString("MMMM") + " " + thisDay.ToString("dd") + ", " + thisDay.ToString("yyyy");
            }
            
            return fin;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        public string currTotals()
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

            //find date
            DateTime thisDay = DateTime.Today;
            string date;
            string date3;
            
            if (date1.Value.Length > 0 && date2.Value.Length == 0)
            {
                date = date1.Value;
                date3 = date;
            }

            else if (date1.Value.Length > 0 && date2.Value.Length > 0)
            {
                date = date1.Value;
                date3 = date2.Value;
            }

            else
            {
                date = thisDay.ToString("yyyy") + "-" + thisDay.ToString("dd") + "-" + thisDay.ToString("MM");
                date3 = date;
            }

            MySqlCommand genTickets = new MySqlCommand("SELECT ticketID, ticketType, ticketCost, email, visitDate FROM visitor WHERE ticketType = @ticketType AND visitDate BETWEEN @date AND @date2 ORDER BY visitDate ASC;", dbcon);
            genTickets.Parameters.AddWithValue("@ticketType", "general");
            genTickets.Parameters.AddWithValue("@date", date);
            genTickets.Parameters.AddWithValue("@date2", date3);
            MySqlCommand seasTickets = new MySqlCommand("SELECT ticketID, ticketType, ticketCost, email, visitDate FROM visitor WHERE ticketType = @ticketType AND visitDate BETWEEN @date AND @date2 ORDER BY visitDate ASC;", dbcon);
            seasTickets.Parameters.AddWithValue("@ticketType", "seasonal");
            seasTickets.Parameters.AddWithValue("@date", date);
            seasTickets.Parameters.AddWithValue("@date2", date3);

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
                string datestr = genReader.GetString(4);

                string[] datesplit = datestr.Split(' ');
                datestr = datesplit[0];

                genTotal += cost;
                genCount += 1;

                htmlStr += "<tr><td>" + datestr + "</td><td>" + id + "</td><td>" + type + "</td><td> $" + cost + "</td><td>" + email + "</td></tr>";
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
                string datestr = seasReader.GetString(4);

                string[] datesplit = datestr.Split(' ');
                datestr = datesplit[0];

                seasTotal += cost;
                seasCount += 1;

                htmlStr += "<tr><td>" + datestr + "</td><td>" + id + "</td><td>" + type + "</td><td> $" + cost + "</td><td>" + email + "</td></tr>";
            }
            seasReader.Close();

            int total = genTotal + seasTotal;
            int totCount = genCount + seasCount;
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + genCount + " total general sales" + "</td><td> $" + genTotal + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + seasCount + " total seasonal sales" + "</td><td> $" + seasTotal + "</td></tr>";
            htmlStr += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>" + "" + "</td><td>" + totCount + " total sales" + "</td><td> $" + total + "</td></tr>";

            dbcon.Close();
            return htmlStr;
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