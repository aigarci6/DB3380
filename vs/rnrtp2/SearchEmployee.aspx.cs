using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Button1.Text = "Updated!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            //last name
            MySqlCommand updateLast = new MySqlCommand("UPDATE staff SET lastName = @last WHERE employeeID = @id AND firstName = @first;", dbcon);
            if (last_textbox.Text.Length > 0)
            {
                updateLast.Parameters.AddWithValue("@id", id_textbox.Text);
                updateLast.Parameters.AddWithValue("@first", first_textbox.Text);
                updateLast.Parameters.AddWithValue("@last", last_textbox.Text);
            }

            //job description
            MySqlCommand updateDesc = new MySqlCommand("UPDATE staff SET jobDescription = @desc WHERE employeeID = @id AND firstName = @first;", dbcon);
            if (description_textbox.Text.Length > 0)
            {
                updateDesc.Parameters.AddWithValue("@id", id_textbox.Text);
                updateDesc.Parameters.AddWithValue("@first", first_textbox.Text);
                updateDesc.Parameters.AddWithValue("@desc", description_textbox.Text);
            }

            //gender
            MySqlCommand updateGender = new MySqlCommand("UPDATE staff SET gender = @gender WHERE employeeID = @id AND firstName = @first;", dbcon);
            if (gender_textbox.Text.Length > 0)
            {
                updateGender.Parameters.AddWithValue("@id", id_textbox.Text);
                updateGender.Parameters.AddWithValue("@first", first_textbox.Text);
                updateGender.Parameters.AddWithValue("@gender", gender_textbox.Text);
            }

            //weekly salary
            MySqlCommand updateSalary = new MySqlCommand("UPDATE staff SET weeklySalary = @salary WHERE employeeID = @id AND firstName = @first;", dbcon);
            if (salary_textbox.Text.Length > 0)
            {
                updateSalary.Parameters.AddWithValue("@id", id_textbox.Text);
                updateSalary.Parameters.AddWithValue("@first", first_textbox.Text);
                updateSalary.Parameters.AddWithValue("@salary", salary_textbox.Text);
            }

            //job category
            MySqlCommand updateJob = new MySqlCommand("UPDATE staff SET jobCategory = @category, maintainsRide = @maintain, workAtRide = @ride, workAtRestaurant = @restaurant, workAtHotel = @hotel WHERE employeeID = @id AND firstName = @first;", dbcon);
            if (category_textbox.Text.Length > 0)
            {
                updateJob.Parameters.AddWithValue("@id", id_textbox.Text);
                updateJob.Parameters.AddWithValue("@first", first_textbox.Text);
                updateJob.Parameters.AddWithValue("@category", category_textbox.Text);
            }

            //job id
            if (category_textbox.Text == "maintenance")
            {
                updateJob.Parameters.AddWithValue("@maintain", jid_textbox.Text);
            }

            else
            {
                updateJob.Parameters.AddWithValue("@maintain", null);
            }

            if (category_textbox.Text == "ride")
            {
                updateJob.Parameters.AddWithValue("@ride", jid_textbox.Text);
            }

            else
            {
                updateJob.Parameters.AddWithValue("@ride", null);
            }

            if (category_textbox.Text == "restaurant")
            {
                updateJob.Parameters.AddWithValue("@restaurant", jid_textbox.Text);
            }

            else
            {
                updateJob.Parameters.AddWithValue("@restaurant", null);
            }

            if (category_textbox.Text == "hotel")
            {
                updateJob.Parameters.AddWithValue("@hotel", jid_textbox.Text);
            }

            else
            {
                updateJob.Parameters.AddWithValue("@hotel", null);
            }

            dbcon.Open();
            if (last_textbox.Text.Length > 0)
            {
                updateLast.ExecuteNonQuery();
            }
            if (description_textbox.Text.Length > 0)
            {
                updateDesc.ExecuteNonQuery();
            }
            if (gender_textbox.Text.Length > 0)
            {
                updateGender.ExecuteNonQuery();
            }
            if (salary_textbox.Text.Length > 0)
            {
                updateSalary.ExecuteNonQuery();
            }
            if (category_textbox.Text.Length > 0)
            {
                updateJob.ExecuteNonQuery();
            }

            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                first_textbox.Text = "";
                last_textbox.Text = "";
                description_textbox.Text = "";
                gender_textbox.Text = "";
                salary_textbox.Text = "";
                category_textbox.Text = "";
                jid_textbox.Text = "";
            }
        }
    }
}