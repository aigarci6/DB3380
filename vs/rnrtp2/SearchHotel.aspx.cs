using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            updateerrormessage.Visible = false;
            deleteerrormessage.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0 && name_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

                //location
                MySqlCommand updateLocation = new MySqlCommand("UPDATE hotel SET h_locID = @location WHERE hotelID = @id AND name = @name;", dbcon);
                if (location_textbox.Text.Length > 0)
                {
                    updateLocation.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateLocation.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateLocation.Parameters.AddWithValue("@location", location_textbox.Text);
                }

                //capacity
                MySqlCommand updateCapacity = new MySqlCommand("UPDATE hotel SET capacity = @capacity WHERE hotelID = @id AND name = @name;", dbcon);
                if (capacity_textbox.Text.Length > 0)
                {
                    updateCapacity.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateCapacity.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateCapacity.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
                }

                //rating
                MySqlCommand updateRating = new MySqlCommand("UPDATE hotel SET rating = @rating WHERE hotelID = @id AND name = @name;", dbcon);
                if (rating_textbox.Text.Length > 0)
                {
                    updateRating.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateRating.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateRating.Parameters.AddWithValue("@rating", rating_textbox.Text);
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
                if (rating_textbox.Text.Length > 0)
                {
                    updateRating.ExecuteNonQuery();
                }
                dbcon.Close();

                if (IsPostBack)
                {
                    id_textbox.Text = "";
                    name_textbox.Text = "";
                    location_textbox.Text = "";
                    capacity_textbox.Text = "";
                    rating_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Button1.Text = "Updated!";
                }
            }

            else
            {
                updateerrormessage.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            int hid;
            string hname;
            int capacity;
            int exp;
            int rating;
            int lid;
            string lname;
            double revenue;
            string htmlStr = "";

            dbcon.Open();

            // none
            if (search.Value == "none")
            {

            }

            //* (all)
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT hotelID, name, capacity, h_expenditure, rating, h_locID, IFNULL(locationName, @auto) AS locationName, h_revenue FROM hotel LEFT OUTER JOIN location ON h_locID = locationID WHERE hotel.archived <= @archived ORDER BY hotelID ASC;", dbcon);
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
                    hid = sReader.GetInt32(0);
                    hname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    rating = sReader.GetInt32(4);
                    lid = sReader.GetInt32(5);
                    lname = sReader.GetString(6);
                    revenue = sReader.GetDouble(7);


                    htmlStr += "<tr><td>" + hid + "</td><td>" + hname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + rating + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //id
            if (search.Value == "id" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT hotelID, name, capacity, h_expenditure, rating, h_locID, IFNULL(locationName, @auto) AS locationName, h_revenue FROM hotel LEFT OUTER JOIN location ON h_locID = locationID WHERE hotelID = @id AND hotel.archived <= @archived ORDER BY name ASC;", dbcon);
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
                    hid = sReader.GetInt32(0);
                    hname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    rating = sReader.GetInt32(4);
                    lid = sReader.GetInt32(5);
                    lname = sReader.GetString(6);
                    revenue = sReader.GetDouble(7);


                    htmlStr += "<tr><td>" + hid + "</td><td>" + hname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + rating + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //hotel name
            if (search.Value == "name" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT hotelID, name, capacity, h_expenditure, rating, h_locID, IFNULL(locationName, @auto) AS locationName, h_revenue FROM hotel LEFT OUTER JOIN location ON h_locID = locationID WHERE name = @name AND hotel.archived <= @archived ORDER BY hotelID ASC;", dbcon);
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
                    hid = sReader.GetInt32(0);
                    hname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    rating = sReader.GetInt32(4);
                    lid = sReader.GetInt32(5);
                    lname = sReader.GetString(6);
                    revenue = sReader.GetDouble(7);


                    htmlStr += "<tr><td>" + hid + "</td><td>" + hname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + rating + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //location id
            if (search.Value == "location" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT hotelID, name, capacity, h_expenditure, rating, h_locID, IFNULL(locationName, @auto) AS locationName, h_revenue FROM hotel LEFT OUTER JOIN location ON h_locID = locationID WHERE h_locID = @id AND hotel.archived <= @archived ORDER BY hotelID ASC;", dbcon);
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
                    hid = sReader.GetInt32(0);
                    hname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    rating = sReader.GetInt32(4);
                    lid = sReader.GetInt32(5);
                    lname = sReader.GetString(6);
                    revenue = sReader.GetDouble(7);


                    htmlStr += "<tr><td>" + hid + "</td><td>" + hname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + rating + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //capacity greater than
            if (search.Value == "capacity_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT hotelID, name, capacity, h_expenditure, rating, h_locID, IFNULL(locationName, @auto) AS locationName, h_revenue FROM hotel LEFT OUTER JOIN location ON h_locID = locationID WHERE capacity > @capacity AND hotel.archived <= @archived ORDER BY hotelID ASC;", dbcon);
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
                    hid = sReader.GetInt32(0);
                    hname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    rating = sReader.GetInt32(4);
                    lid = sReader.GetInt32(5);
                    lname = sReader.GetString(6);
                    revenue = sReader.GetDouble(7);


                    htmlStr += "<tr><td>" + hid + "</td><td>" + hname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + rating + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //capacity less than
            if (search.Value == "capacity_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT hotelID, name, capacity, h_expenditure, rating, h_locID, IFNULL(locationName, @auto) AS locationName, h_revenue FROM hotel LEFT OUTER JOIN location ON h_locID = locationID WHERE capacity < @capacity AND hotel.archived <= @archived ORDER BY hotelID ASC;", dbcon);
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
                    hid = sReader.GetInt32(0);
                    hname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    rating = sReader.GetInt32(4);
                    lid = sReader.GetInt32(5);
                    lname = sReader.GetString(6);
                    revenue = sReader.GetDouble(7);


                    htmlStr += "<tr><td>" + hid + "</td><td>" + hname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + rating + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //rating greater than
            if (search.Value == "rating_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT hotelID, name, capacity, h_expenditure, rating, h_locID, IFNULL(locationName, @auto) AS locationName, h_revenue FROM hotel LEFT OUTER JOIN location ON h_locID = locationID WHERE rating > @rating AND hotel.archived <= @archived ORDER BY hotelID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@rating", field_textbox.Text);

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
                    hid = sReader.GetInt32(0);
                    hname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    rating = sReader.GetInt32(4);
                    lid = sReader.GetInt32(5);
                    lname = sReader.GetString(6);
                    revenue = sReader.GetDouble(7);


                    htmlStr += "<tr><td>" + hid + "</td><td>" + hname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + rating + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //rating less than
            if (search.Value == "rating_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT hotelID, name, capacity, h_expenditure, rating, h_locID, IFNULL(locationName, @auto) AS locationName, h_revenue FROM hotel LEFT OUTER JOIN location ON h_locID = locationID WHERE rating < @rating AND hotel.archived <= @archived ORDER BY hotelID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@rating", field_textbox.Text);

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
                    hid = sReader.GetInt32(0);
                    hname = sReader.GetString(1);
                    capacity = sReader.GetInt32(2);
                    exp = sReader.GetInt32(3);
                    rating = sReader.GetInt32(4);
                    lid = sReader.GetInt32(5);
                    lname = sReader.GetString(6);
                    revenue = sReader.GetDouble(7);

                    htmlStr += "<tr><td>" + hid + "</td><td>" + hname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + rating + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            dbcon.Close();
            return htmlStr;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (delete_id.Text.Length > 0 && delete_name.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
                MySqlCommand delete = new MySqlCommand("UPDATE hotel SET archived = 1 WHERE hotelID = @id AND name = @name", dbcon);
                delete.Parameters.AddWithValue("@id", delete_id.Text);
                delete.Parameters.AddWithValue("@name", delete_name.Text);

                dbcon.Open();
                delete.ExecuteNonQuery();
                dbcon.Close();

                if (IsPostBack)
                {
                    delete_id.Text = "";
                    delete_name.Text = "";
                }

                if (IsPostBack == true)
                {
                    Button3.Text = "Deleted!";
                }
            }

            else
            {
                deleteerrormessage.Visible = true;
            }
        }
    }
}