using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddEmployee : System.Web.UI.Page
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

            if (jcategory != "HR")
            {
                Response.Redirect("BadAccessP.aspx");
            }
            

            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Employee added successfully!')</script>");
            }

            if (IsPostBack == true || IsPostBack == false)
            {
                errormessage.Visible = false;
            }

            //dropdownlist
            MySqlConnection dbconn = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred; Allow User Variables=True;");
            MySqlCommand jobid = new MySqlCommand("SELECT hotelID, name FROM hotel ORDER BY name ASC;", dbconn);
            MySqlCommand rideid = new MySqlCommand("SELECT rideID, name FROM rides ORDER BY name ASC;", dbconn);
            MySqlCommand restid = new MySqlCommand("SELECT restaurantID, name FROM restaurant ORDER BY name ASC;", dbconn);

            ListItem firstListItem = new ListItem("(HR) N/A", "000");
            DropDownList1.Items.Add(firstListItem);

            dbconn.Open();
            MySqlDataReader jobReader = jobid.ExecuteReader();
            if (!IsPostBack)
            {
                while (jobReader.Read())
                {
                    string name = "(Hotel) " + jobReader.GetString(1);
                    string id = jobReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList1.Items.Add(newListItem);
                }
            }
            jobReader.Close();

            MySqlDataReader rideReader = rideid.ExecuteReader();
            if (!IsPostBack)
            {
                while (rideReader.Read())
                {
                    string name = "(Ride) " + rideReader.GetString(1);
                    string id = rideReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList1.Items.Add(newListItem);
                }
            }
            rideReader.Close();

            MySqlDataReader restReader = restid.ExecuteReader();
            if (!IsPostBack)
            {
                while (restReader.Read())
                {
                    string name = "(Restaurant) " + restReader.GetString(1);
                    string id = restReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList1.Items.Add(newListItem);
                }
            }
            restReader.Close();
            dbconn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred; Allow User Variables=True;");
            MySqlCommand insert = new MySqlCommand("CALL InsertStaff(@employeeID, @firstName, @lastName, @gender, @salary, @category, @email);", dbcon);
            insert.Parameters.AddWithValue("@employeeID", id_textbox.Text);
            insert.Parameters.AddWithValue("@firstName", first_textbox.Text);
            insert.Parameters.AddWithValue("@lastName", last_textbox.Text);
            insert.Parameters.AddWithValue("@gender", gender.Value);
            insert.Parameters.AddWithValue("@salary", salary_textbox.Text);
            insert.Parameters.AddWithValue("@category", jsite.Value);
            insert.Parameters.AddWithValue("@email", email_textbox.Text);

            //works_hotel
            MySqlCommand insertWorkHotel = new MySqlCommand("INSERT INTO works_hotel (staID, hotID) VALUES (@staID, @hotID);", dbcon);
            if (jsite.Value.ToLower() == "hotel" && DropDownList1.SelectedItem.Text.Contains("Hotel"))
            {
                insertWorkHotel.Parameters.AddWithValue("@staID", id_textbox.Text);
                insertWorkHotel.Parameters.AddWithValue("@hotID", DropDownList1.SelectedValue);
            }

            else
            {
                errormessage.Visible = true;
            }

            //works_restaurant
            MySqlCommand insertWorkRestaurant = new MySqlCommand("INSERT INTO works_restaurant (staID, restID) VALUES (@staID, @restID);", dbcon);
            if (jsite.Value.ToLower() == "restaurant" && DropDownList1.SelectedItem.Text.Contains("Restaurant"))
            {
                insertWorkRestaurant.Parameters.AddWithValue("@staID", id_textbox.Text);
                insertWorkRestaurant.Parameters.AddWithValue("@restID", DropDownList1.SelectedValue);
            }

            else
            {
                errormessage.Visible = true;
            }

            MySqlCommand insertWorkRide = new MySqlCommand("INSERT INTO works_ride (staID, rID) VALUES (@staID, @rID);", dbcon);
            //works_ride
            if (jsite.Value.ToLower() == "ride" && DropDownList1.SelectedItem.Text.Contains("Ride"))
            {
                insertWorkRide.Parameters.AddWithValue("@staID", id_textbox.Text);
                insertWorkRide.Parameters.AddWithValue("@rID", DropDownList1.SelectedValue);
            }

            else
            {
                errormessage.Visible = true;
            }

            dbcon.Open();
            if (jsite.Value.ToLower() == "HR")
            {
                insert.ExecuteNonQuery();
            }
            if (jsite.Value.ToLower() == "hotel" && DropDownList1.SelectedItem.Text.Contains("Hotel"))
            {
                insert.ExecuteNonQuery();
                insertWorkHotel.ExecuteNonQuery();
            }
            if (jsite.Value.ToLower() == "restaurant" && DropDownList1.SelectedItem.Text.Contains("Restaurant"))
            {
                insert.ExecuteNonQuery();
                insertWorkRestaurant.ExecuteNonQuery();
            }
            if (jsite.Value.ToLower() == "ride" && DropDownList1.SelectedItem.Text.Contains("Ride"))
            {
                insert.ExecuteNonQuery();
                insertWorkRide.ExecuteNonQuery();
            }
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                first_textbox.Text = "";
                last_textbox.Text = "";
                gender.Value = "";
                jsite.Value = "";
                salary_textbox.Text = "";
                email_textbox.Text = "";
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