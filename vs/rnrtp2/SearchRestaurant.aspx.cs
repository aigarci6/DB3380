using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0 && name_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

                //location
                MySqlCommand updateLocation = new MySqlCommand("UPDATE restaurant SET rest_locID = @location WHERE restaurantID = @id AND name = @name;", dbcon);
                if (location_textbox.Text.Length > 0)
                {
                    updateLocation.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateLocation.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateLocation.Parameters.AddWithValue("@location", location_textbox.Text);
                }

                //capacity
                MySqlCommand updateCapacity = new MySqlCommand("UPDATE restaurant SET capacity = @capacity WHERE restaurantID = @id AND name = @name;", dbcon);
                if (capacity_textbox.Text.Length > 0)
                {
                    updateCapacity.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateCapacity.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateCapacity.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
                }

                dbcon.Open();
                if (location_textbox.Text.Length > 0)
                {
                    updateLocation.ExecuteNonQuery();
                }
                if (capacity_textbox.Text.Length > 0)
                {
                    updateCapacity.ExecuteNonQuery();
                }
                dbcon.Close();

                if (IsPostBack)
                {
                    id_textbox.Text = "";
                    name_textbox.Text = "";
                    location_textbox.Text = "";
                    capacity_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Button1.Text = "Updated!";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            int rid;
            string rname;
            int lid;
            string lname;
            int capacity;
            int exp;

            
            string htmlStr = "";

            dbcon.Open();

            //auto (all)
            if (search.Value == "none")
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");

                if (archived.Checked)
                {
                    search.Parameters.AddWithValue("@archived", "1");
                }

                else
                {
                    search.Parameters.AddWithValue("@archived", "0");
                }

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    rid = sReader.GetInt32(0);
                    rname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    lid = sReader.GetInt32(4);
                    lname = sReader.GetString(5);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }


            //id
            if (search.Value == "id" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE restaurantID = @id AND restaurant.archived <= @archived ORDER BY name ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                if (archived.Checked)
                {
                    search.Parameters.AddWithValue("@archived", "1");
                }

                else
                {
                    search.Parameters.AddWithValue("@archived", "0");
                }

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    rid = sReader.GetInt32(0);
                    rname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    lid = sReader.GetInt32(4);
                    lname = sReader.GetString(5);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //rest name
            if (search.Value == "name" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE name = @name AND restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@name", field_textbox.Text);

                if (archived.Checked)
                {
                    search.Parameters.AddWithValue("@archived", "1");
                }

                else
                {
                    search.Parameters.AddWithValue("@archived", "0");
                }

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    rid = sReader.GetInt32(0);
                    rname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    lid = sReader.GetInt32(4);
                    lname = sReader.GetString(5);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //location id
            if (search.Value == "location" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE rest_locID = @lid AND restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@lid", field_textbox.Text);

                if (archived.Checked)
                {
                    search.Parameters.AddWithValue("@archived", "1");
                }

                else
                {
                    search.Parameters.AddWithValue("@archived", "0");
                }

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    rid = sReader.GetInt32(0);
                    rname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    lid = sReader.GetInt32(4);
                    lname = sReader.GetString(5);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //capacity greater than
            if (search.Value == "capacity_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE capacity > @capacity AND restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@capacity", field_textbox.Text);

                if (archived.Checked)
                {
                    search.Parameters.AddWithValue("@archived", "1");
                }

                else
                {
                    search.Parameters.AddWithValue("@archived", "0");
                }

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    rid = sReader.GetInt32(0);
                    rname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    lid = sReader.GetInt32(4);
                    lname = sReader.GetString(5);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //capacity less than
            if (search.Value == "capacity_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE capacity < @capacity AND restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@capacity", field_textbox.Text);

                if (archived.Checked)
                {
                    search.Parameters.AddWithValue("@archived", "1");
                }

                else
                {
                    search.Parameters.AddWithValue("@archived", "0");
                }

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    rid = sReader.GetInt32(0);
                    rname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    lid = sReader.GetInt32(4);
                    lname = sReader.GetString(5);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            dbcon.Close();
            return htmlStr;
        }
    }
}