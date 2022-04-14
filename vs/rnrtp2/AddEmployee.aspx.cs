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

            if ((string)Session["username"] != "admin")
            {
                Response.Redirect("BadAccess.html");
            }


            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Employee added successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred; Allow User Variables=True;");
            MySqlCommand insert = new MySqlCommand("CALL InsertStaff(@employeeID, @firstName, @lastName, @gender, @salary, @category);", dbcon);
            insert.Parameters.AddWithValue("@employeeID", id_textbox.Text);
            insert.Parameters.AddWithValue("@firstName", first_textbox.Text);
            insert.Parameters.AddWithValue("@lastName", last_textbox.Text);
            insert.Parameters.AddWithValue("@gender", gender.Value);
            insert.Parameters.AddWithValue("@salary", salary_textbox.Text);
            insert.Parameters.AddWithValue("@category", jsite.Value);

            //works_hotel
            MySqlCommand insertWorkHotel = new MySqlCommand("INSERT INTO works_hotel (staID, hotID) VALUES (@staID, @hotID);", dbcon);
            if (jsite.Value.ToLower() == "hotel")
            {
                insertWorkHotel.Parameters.AddWithValue("@staID", id_textbox.Text);
                insertWorkHotel.Parameters.AddWithValue("@hotID", jid_textbox.Text);
            }

            //works_restaurant
            MySqlCommand insertWorkRestaurant = new MySqlCommand("INSERT INTO works_restaurant (staID, restID) VALUES (@staID, @restID);", dbcon);
            if (jsite.Value.ToLower() == "restaurant")
            {
                insertWorkRestaurant.Parameters.AddWithValue("@staID", id_textbox.Text);
                insertWorkRestaurant.Parameters.AddWithValue("@restID", jid_textbox.Text);
            }

            MySqlCommand insertWorkRide = new MySqlCommand("INSERT INTO works_ride (staID, rID) VALUES (@staID, @rID);", dbcon);
            //works_ride
            if (jsite.Value.ToLower() == "ride")
            {
                insertWorkRide.Parameters.AddWithValue("@staID", id_textbox.Text);
                insertWorkRide.Parameters.AddWithValue("@rID", jid_textbox.Text);
            }

            dbcon.Open();
            insert.ExecuteNonQuery();
            if (jsite.Value.ToLower() == "hotel")
            {
                insertWorkHotel.ExecuteNonQuery();
            }
            if (jsite.Value.ToLower() == "restaurant")
            {
                insertWorkRestaurant.ExecuteNonQuery();
            }
            if (jsite.Value.ToLower() == "ride")
            {
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
                jid_textbox.Text = "";
                salary_textbox.Text = "";
            }
        }
    }
}