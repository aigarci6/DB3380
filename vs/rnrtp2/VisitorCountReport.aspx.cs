using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class VisitorCountReport : System.Web.UI.Page
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
                Response.Redirect("BadAccess.html");
            }

        }

        public string getHotel()
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

            MySqlCommand Hotel = new MySqlCommand("SELECT IFNULL(dateVisited,@nulldate), IFNULL(name, @nullname), IFNULL(hotelID, @nullhotelID), COUNT(*)visitID FROM hotel, visit_hotel WHERE hotelID = hotID AND hotel.archived = 0 AND dateVisited BETWEEN @date AND @date2 ORDER BY dateVisited ASC;", dbcon);
            Hotel.Parameters.AddWithValue("@date", date);
            Hotel.Parameters.AddWithValue("@date2", date3);
            Hotel.Parameters.AddWithValue("@nulldate", "0000-00-00");
            Hotel.Parameters.AddWithValue("@nullname", "Krunal");
            Hotel.Parameters.AddWithValue("@nullhotelID", 123);



            string htmlStr = "";
            string date4;
            string name;
            int numofvisitors;
            int id;

            dbcon.Open();

            //general
            MySqlDataReader genReader = Hotel.ExecuteReader();
            while (genReader.Read())
            {
                date4 = genReader.GetString(0);
                name = genReader.GetString(1);
                id = genReader.GetInt32(2);
                numofvisitors = genReader.GetInt32(3);

                htmlStr += "<tr><td>" + date4 + "</td><td>" + name + "</td><td> " + id + "</td><td> " + numofvisitors + "</td></tr>";
            }
            
            genReader.Close();

            dbcon.Close();
            return htmlStr;
        }

        public string getRestaurant()
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

            MySqlCommand Restaurant = new MySqlCommand("SELECT IFNULL(dateVisited, @nulldate), IFNULL(name, @nullname), IFNULL(restaurantID, @nullrestID), COUNT(*)restaurantID FROM restaurant, visit_restaurant WHERE restaurantID = restaurantID AND restaurant.archived = 0 AND dateVisited BETWEEN @date AND @date2 ORDER BY dateVisited ASC;", dbcon);
            Restaurant.Parameters.AddWithValue("@date", date);
            Restaurant.Parameters.AddWithValue("@date2", date3);
            Restaurant.Parameters.AddWithValue("@nulldate", "0000-00-00");
            Restaurant.Parameters.AddWithValue("@nullname", "Krunal");
            Restaurant.Parameters.AddWithValue("@nullrestID", 123);

            string htmlStr = "";
            string date4;
            string name;
            int numofvisitors;
            int id;

            dbcon.Open();

            //general
            MySqlDataReader genReader = Restaurant.ExecuteReader();
            while (genReader.Read())
            {
                date4 = genReader.GetString(0);
                name = genReader.GetString(1);
                id = genReader.GetInt32(2);
                numofvisitors = genReader.GetInt32(3);

                htmlStr += "<tr><td>" + date4 + "</td><td>" + name + "</td><td> " + id + "</td><td> " + numofvisitors + "</td></tr>";
            }

            genReader.Close();

            dbcon.Close();
            return htmlStr;
        }

        public string getTotalVisitor()
        {

            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

            MySqlCommand TotalVisitor = new MySqlCommand("SELECT COUNT(*)hotelID FROM visit_hotel;", dbcon);
            MySqlCommand TotalVisitor1 = new MySqlCommand("SELECT COUNT(*)restaurantID FROM visit_restaurant;", dbcon);

            string htmlStr = "";
            int id;
            int id2;

            dbcon.Open();

            //general
            MySqlDataReader genReader = TotalVisitor.ExecuteReader();
            while (genReader.Read())
            {
                id = genReader.GetInt32(0);

                htmlStr += "<tr><td>" + id + "</td><td>";
            }

            genReader.Close();

            //general
            MySqlDataReader genReader1 = TotalVisitor1.ExecuteReader();
            while (genReader1.Read())
            {
                id2 = genReader1.GetInt32(0);

                htmlStr += id2 + "</td></tr>";
            }

            genReader1.Close();

            dbcon.Close();
            return htmlStr;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void HomeLink(object sender, EventArgs e)
        {
            if ((string)Session["username"] == "HR")
            {
                Response.Redirect("Index.aspx");
            }

            if ((string)Session["username"] == "hotel")
            {
                Response.Redirect("HotelIndex.aspx");
            }

            if ((string)Session["username"] == "restaurant")
            {
                Response.Redirect("RestIndex.aspx");
            }

            if ((string)Session["username"] == "ride")
            {
                Response.Redirect("RideIndex.aspx");
            }
        }
    }
}