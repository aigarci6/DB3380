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

            if (jcategory != "HR" && jcategory != "hotel")
            {
                Response.Redirect("BadAccessP.aspx");
            }
            

            updateerrormessage.Visible = false;
            deleteerrormessage.Visible = false;

            //dropdownlist
            MySqlConnection dbconn = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred; Allow User Variables=True;");
            MySqlCommand locid = new MySqlCommand("SELECT locationID, locationName FROM location ORDER BY locationName ASC;", dbconn);
            MySqlCommand hotid = new MySqlCommand("SELECT hotelID, name FROM hotel ORDER BY name ASC;", dbconn);

            ListItem firstListItem = new ListItem("SELECT", "000");
            DropDownList1.Items.Add(firstListItem);
            DropDownList2.Items.Add(firstListItem);

            dbconn.Open();
            MySqlDataReader locReader = locid.ExecuteReader();
            if (!IsPostBack)
            {
                while (locReader.Read())
                {
                    string name = locReader.GetString(1);
                    string id = locReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList1.Items.Add(newListItem);
                }
            }
            locReader.Close();

            MySqlDataReader hotReader = hotid.ExecuteReader();
            if (!IsPostBack)
            {
                while (hotReader.Read())
                {
                    string name = hotReader.GetString(1);
                    string id = hotReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList2.Items.Add(newListItem);
                }
            }
            hotReader.Close();
            dbconn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedItem.Text != "SELECT")
            {
                MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

                //location
                MySqlCommand updateLocation = new MySqlCommand("UPDATE hotel SET h_locID = @location WHERE hotelID = @id AND name = @name;", dbcon);
                if (DropDownList1.SelectedItem.Value != "SELECT")
                {
                    updateLocation.Parameters.AddWithValue("@id", DropDownList2.SelectedValue);
                    updateLocation.Parameters.AddWithValue("@name", DropDownList2.SelectedItem.Text);
                    updateLocation.Parameters.AddWithValue("@location", DropDownList1.SelectedValue);
                }

                //capacity
                MySqlCommand updateCapacity = new MySqlCommand("UPDATE hotel SET capacity = @capacity WHERE hotelID = @id AND name = @name;", dbcon);
                if (capacity_textbox.Text.Length > 0)
                {
                    updateCapacity.Parameters.AddWithValue("@id", DropDownList2.SelectedValue);
                    updateCapacity.Parameters.AddWithValue("@name", DropDownList2.SelectedItem.Text);
                    updateCapacity.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
                }

                //rating
                MySqlCommand updateRating = new MySqlCommand("UPDATE hotel SET rating = @rating WHERE hotelID = @id AND name = @name;", dbcon);
                if (rating_textbox.Text.Length > 0)
                {
                    updateRating.Parameters.AddWithValue("@id", DropDownList2.SelectedValue);
                    updateRating.Parameters.AddWithValue("@name", DropDownList2.SelectedItem.Text);
                    updateRating.Parameters.AddWithValue("@rating", rating_textbox.Text);
                }


                dbcon.Open();
                if (DropDownList1.SelectedItem.Value != "SELECT")
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
                    capacity_textbox.Text = "";
                    rating_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Response.Write("<script>alert('Hotel updated successfully!')</script>");
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
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

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
                MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
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
                    Response.Write("<script>alert('Hotel deleted successfully!')</script>");
                }
            }

            else
            {
                deleteerrormessage.Visible = true;
            }
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