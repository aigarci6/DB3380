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
            if (IsPostBack == true)
            {
                Button1.Text = "Submitted!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertStaff(@employeeID, @firstName, @lastName, @gender);", dbcon);
            insert.Parameters.AddWithValue("@employeeID", id_textbox.Text);
            insert.Parameters.AddWithValue("@firstName", first_textbox.Text);
            insert.Parameters.AddWithValue("@lastName", last_textbox.Text);
            insert.Parameters.AddWithValue("@gender", gender_textbox.Text);


            //works_hotel
            MySqlCommand insertWorkHotel = new MySqlCommand("INSERT INTO works_hotel (staID, hotID, staffPayroll) VALUES (@staID, @hotID, @staffPayroll);", dbcon);
            if (jsite_textbox.Text.ToLower() == "hotel")
            {
                insert.Parameters.AddWithValue("@staID", id_textbox.Text);
                insert.Parameters.AddWithValue("@hotID", jid_textbox.Text);
                insert.Parameters.AddWithValue("@staffPayroll", salary_textbox.Text);
            }

            //works_restaurant
            MySqlCommand insertWorkRestaurant = new MySqlCommand("INSERT INTO works_restaurant (staID, restID, staffPayroll) VALUES (@staID, @restID, @staffPayroll);", dbcon);
            if (jsite_textbox.Text.ToLower() == "restaurant")
            {
                insert.Parameters.AddWithValue("@staID", id_textbox.Text);
                insert.Parameters.AddWithValue("@restID", jid_textbox.Text);
                insert.Parameters.AddWithValue("@staffPayroll", salary_textbox.Text);
            }

            MySqlCommand insertWorkRide = new MySqlCommand("INSERT INTO works_ride (staID, rID, staffPayroll) VALUES (@staID, @rID, @staffPayroll);", dbcon);
            //works_ride
            if (jsite_textbox.Text.ToLower() == "ride")
            {
                insert.Parameters.AddWithValue("@staID", id_textbox.Text);
                insert.Parameters.AddWithValue("@rID", jid_textbox.Text);
                insert.Parameters.AddWithValue("@staffPayroll", salary_textbox.Text);
            }

            dbcon.Open();
            insert.ExecuteNonQuery();
            if (jsite_textbox.Text.ToLower() == "hotel")
            {
                insertWorkHotel.ExecuteNonQuery();
            }
            if (jsite_textbox.Text.ToLower() == "restaurant")
            {
                insertWorkRestaurant.ExecuteNonQuery();
            }
            if (jsite_textbox.Text.ToLower() == "ride")
            {
                insertWorkRide.ExecuteNonQuery();
            }
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                first_textbox.Text = "";
                last_textbox.Text = "";
                gender_textbox.Text = "";
                jsite_textbox.Text = "";
                jid_textbox.Text = "";
                salary_textbox.Text = "";
            }
        }
    }
}