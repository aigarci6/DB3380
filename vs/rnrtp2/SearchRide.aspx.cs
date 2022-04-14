using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchRide : System.Web.UI.Page
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
                MySqlCommand updateLocation = new MySqlCommand("UPDATE rides SET r_locID = @location WHERE rideID = @id AND name = @name;", dbcon);
                if (location_textbox.Text.Length > 0)
                {
                    updateLocation.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateLocation.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateLocation.Parameters.AddWithValue("@location", location_textbox.Text);
                }

                //capacity
                MySqlCommand updateCapacity = new MySqlCommand("UPDATE rides SET capacity = @capacity WHERE rideID = @id AND name = @name;", dbcon);
                if (capacity_textbox.Text.Length > 0)
                {
                    updateCapacity.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateCapacity.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateCapacity.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
                }

                //maxweight
                MySqlCommand updateWeight = new MySqlCommand("UPDATE rides SET maxWeight = @weight WHERE rideID = @id AND name = @name;", dbcon);
                if (maxweight_textbox.Text.Length > 0)
                {
                    updateWeight.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateWeight.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateWeight.Parameters.AddWithValue("@weight", maxweight_textbox.Text);
                }

                //minheight
                MySqlCommand updateHeight = new MySqlCommand("UPDATE rides SET minHeight = @height WHERE rideID = @id AND name = @name;", dbcon);
                if (minheight_textbox.Text.Length > 0)
                {
                    updateHeight.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateHeight.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateHeight.Parameters.AddWithValue("@height", minheight_textbox.Text);
                }

                //minage
                MySqlCommand updateAge = new MySqlCommand("UPDATE rides SET minAge = @age WHERE rideID = @id AND name = @name;", dbcon);
                if (minage_textbox.Text.Length > 0)
                {
                    updateAge.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateAge.Parameters.AddWithValue("@name", name_textbox.Text);
                    updateAge.Parameters.AddWithValue("@age", minage_textbox.Text);
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
                if (maxweight_textbox.Text.Length > 0)
                {
                    updateWeight.ExecuteNonQuery();
                }
                if (minheight_textbox.Text.Length > 0)
                {
                    updateHeight.ExecuteNonQuery();
                }
                if (minage_textbox.Text.Length > 0)
                {
                    updateAge.ExecuteNonQuery();
                }
                dbcon.Close();

                if (IsPostBack)
                {
                    id_textbox.Text = "";
                    name_textbox.Text = "";
                    location_textbox.Text = "";
                    capacity_textbox.Text = "";
                    maxweight_textbox.Text = "";
                    minheight_textbox.Text = "";
                    minage_textbox.Text = "";
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

            int rid;
            string rname;
            int capacity;
            int weight;
            int height;
            int age;
            int lid;
            string lname;
            string htmlStr = "";

            dbcon.Open();

            if (search.Value == "none")
            {

            }

            //* (all)
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>"+ age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //id
            if (search.Value == "id" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE rideID = @id AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //ride name
            if (search.Value == "name" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE name = @name AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //location id
            if (search.Value == "location" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE r_locID = @lid AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //max weight greater than
            if (search.Value == "weight_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE maxWeight > @weight AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@weight", field_textbox.Text);

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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //max weight less than
            if (search.Value == "weight_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE maxWeight < @weight AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@weight", field_textbox.Text);

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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //min height greater than
            if (search.Value == "height_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE minHeight > @height AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@height", field_textbox.Text);

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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //min height less than
            if (search.Value == "height_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE minHeight < @height AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@height", field_textbox.Text);

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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //min age greater than
            if (search.Value == "age_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE minAge > @age AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@age", field_textbox.Text);

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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //min age less than
            if (search.Value == "age_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE minAge < @age AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
                search.Parameters.AddWithValue("@auto", "N/A");
                search.Parameters.AddWithValue("@age", field_textbox.Text);

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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //capacity greater than
            if (search.Value == "capacity_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE capacity > @capacity AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //capacity less than
            if (search.Value == "capacity_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT rideID, name, capacity, maxWeight, minHeight, minAge, r_locID, IFNULL(locationName, @auto) AS locationName FROM rides LEFT OUTER JOIN location ON r_locID = locationID WHERE capacity < @capacity AND rides.archived <= @archived ORDER BY rideID ASC;", dbcon);
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
                    weight = sReader.GetInt32(3);
                    height = sReader.GetInt32(4);
                    age = sReader.GetInt32(5);
                    lid = sReader.GetInt32(6);
                    lname = sReader.GetString(7);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + weight + "</td><td>" + height + "</td><td>" + age + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
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
                MySqlCommand delete = new MySqlCommand("UPDATE rides SET archived = 1 WHERE rideID = @id AND name = @name", dbcon);
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