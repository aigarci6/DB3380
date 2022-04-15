﻿using System;
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

        }

        public string getHotel()
        {

            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
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

            MySqlCommand Hotel = new MySqlCommand("SELECT dateVisited, name, hotelID, COUNT(*)visitID FROM hotel, visit_hotel WHERE hotelID = hotID AND hotel.archived = 0 AND dateVisited BETWEEN @date AND @date2 ORDER BY dateVisited ASC;", dbcon);
            Hotel.Parameters.AddWithValue("@date", date);
            Hotel.Parameters.AddWithValue("@date2", date3);

            string htmlStr = "";
            DateTime date4;
            string date5;
            string name;
            int numofvisitors;
            int id;

            dbcon.Open();

            //general
            MySqlDataReader genReader = Hotel.ExecuteReader();
            while (genReader.Read())
            {
                date4 = genReader.GetDateTime(0);
                date5 = date4.ToString("yyyy-MM-dd");
                name = genReader.GetString(1);
                id = genReader.GetInt32(2);
                numofvisitors = genReader.GetInt32(3);

                htmlStr += "<tr><td>" + date5 + "</td><td>" + name + "</td><td> " + id + "</td><td> " + numofvisitors + "</td></tr>";
            }
            
            genReader.Close();

            dbcon.Close();
            return htmlStr;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}