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
            MySqlCommand insert = new MySqlCommand("CALL InsertStaff(@employeeID, @firstName, @lastName, @jobDescription, @gender, @weeklySalary, @jobCategory, @maintainsRide, @workAtRide, @workAtRestaurant, @workAtHotel);", dbcon);
            insert.Parameters.AddWithValue("@employeeID", id_textbox.Text);
            insert.Parameters.AddWithValue("@firstName", first_textbox.Text);
            insert.Parameters.AddWithValue("@lastName", last_textbox.Text);
            insert.Parameters.AddWithValue("@jobDescription", jdesc_textbox.Text);
            insert.Parameters.AddWithValue("@gender", gender_textbox.Text);
            insert.Parameters.AddWithValue("@weeklySalary", salary_textbox.Text);
            insert.Parameters.AddWithValue("@jobCategory", jcategory_textbox.Text);

            if (jcategory_textbox.Text == "maintenance")
            {
                insert.Parameters.AddWithValue("@maintainsRide", jid_textbox.Text);
            }

            else
            {
                insert.Parameters.AddWithValue("@maintainsRide", null);
            }

            if (jcategory_textbox.Text == "restaurant")
            {
                insert.Parameters.AddWithValue("@workAtRestaurant", jid_textbox.Text);
            }

            else
            {
                insert.Parameters.AddWithValue("@workAtRestaurant", null);
            }

            if (jcategory_textbox.Text == "ride")
            {
                insert.Parameters.AddWithValue("@workAtRide", jid_textbox.Text);
            }

            else
            {
                insert.Parameters.AddWithValue("@workAtRide", null);
            }

            if (jcategory_textbox.Text == "hotel")
            {
                insert.Parameters.AddWithValue("@workAtHotel", jid_textbox.Text);
            }

            else
            {
                insert.Parameters.AddWithValue("@workAtHotel", null);
            }

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                first_textbox.Text = "";
                last_textbox.Text = "";
                jdesc_textbox.Text = "";
                gender_textbox.Text = "";
                salary_textbox.Text = "";
                jcategory_textbox.Text = "";
                jid_textbox.Text = "";
            }
        }
    }
}