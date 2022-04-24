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

            if (jcategory != "HR" && jcategory != "restaurant")
            {
                Response.Redirect("BadAccessP.aspx");
            }
            

            updateerrormessage.Visible = false;
            deleteerrormessage.Visible = false;

            //dropdownlist restaurant update info
            MySqlConnection dbconn = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred; Allow User Variables=True;");
            MySqlCommand restid = new MySqlCommand("SELECT restaurantID, name FROM restaurant ORDER BY name ASC;", dbconn);
            MySqlCommand locid = new MySqlCommand("SELECT locationID, locationName FROM location ORDER BY locationName ASC;", dbconn);

            ListItem firstListItem = new ListItem("SELECT", "000");
            DropDownList3.Items.Add(firstListItem);
            DropDownList1.Items.Add(firstListItem);

            dbconn.Open();
            MySqlDataReader restReader = restid.ExecuteReader();
            if (!IsPostBack)
            {
                while (restReader.Read())
                {
                    string name = restReader.GetString(1);
                    string id = restReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList3.Items.Add(newListItem);
                }
            }
            restReader.Close();

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

            dbconn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedItem.Text != "SELECT")
            {
                MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

                //location
                MySqlCommand updateLocation = new MySqlCommand("UPDATE restaurant SET rest_locID = @location WHERE restaurantID = @id AND name = @name;", dbcon);
                if (DropDownList1.SelectedItem.Text != "SELECT")
                {
                    updateLocation.Parameters.AddWithValue("@id", DropDownList3.SelectedValue);
                    updateLocation.Parameters.AddWithValue("@name", DropDownList3.SelectedItem.Text);
                    updateLocation.Parameters.AddWithValue("@location", DropDownList1.SelectedValue);
                }

                //capacity
                MySqlCommand updateCapacity = new MySqlCommand("UPDATE restaurant SET capacity = @capacity WHERE restaurantID = @id AND name = @name;", dbcon);
                if (capacity_textbox.Text.Length > 0)
                {
                    updateCapacity.Parameters.AddWithValue("@id", DropDownList3.SelectedValue);
                    updateCapacity.Parameters.AddWithValue("@name", DropDownList3.SelectedItem.Text);
                    updateCapacity.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
                }

                dbcon.Open();
                if (DropDownList1.SelectedItem.Text != "SELECT")
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
                    capacity_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Response.Write("<script>alert('Restaurant updated successfully!')</script>");
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

            int rid;
            string rname;
            int lid;
            string lname;
            int capacity;
            int exp;
            double revenue;

            
            string htmlStr = "";

            dbcon.Open();

            //auto (none)
            if (search.Value == "none")
            {
            }

            //* (all)
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName, r_revenue FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
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
                    revenue = sReader.GetDouble(6);


                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }


            //id
            if (search.Value == "id" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName, r_revenue FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE restaurantID = @id AND restaurant.archived <= @archived ORDER BY name ASC;", dbcon);
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
                    revenue = sReader.GetDouble(6);

                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //rest name
            if (search.Value == "name" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName, r_revenue FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE name = @name AND restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
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
                    revenue = sReader.GetDouble(6);

                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //location id
            if (search.Value == "location" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName, r_revenue FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE rest_locID = @lid AND restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
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
                    revenue = sReader.GetDouble(6);

                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //capacity greater than
            if (search.Value == "capacity_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName, r_revenue FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE capacity > @capacity AND restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
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
                    revenue = sReader.GetDouble(6);

                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
                }
                sReader.Close();
            }

            //capacity less than
            if (search.Value == "capacity_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT restaurantID, name, capacity, r_expenditure, rest_locID, IFNULL(locationName, @auto) AS locationName, r_revenue FROM restaurant LEFT OUTER JOIN location ON rest_locID = locationID WHERE capacity < @capacity AND restaurant.archived <= @archived ORDER BY restaurantID ASC;", dbcon);
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
                    revenue = sReader.GetDouble(6);

                    htmlStr += "<tr><td>" + rid + "</td><td>" + rname + "</td><td>" + capacity + "</td><td>" + exp + "</td><td>" + revenue + "</td><td>" + lid + "</td><td>" + lname + "</td></tr>";
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
                MySqlCommand delete = new MySqlCommand("UPDATE restaurant SET archived = 1 WHERE restaurantID = @id AND name = @name", dbcon);
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
                    Response.Write("<script>alert('Restaurant deleted successfully!')</script>");
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