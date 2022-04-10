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

            //first name
            MySqlCommand updateFirst = new MySqlCommand("UPDATE staff SET firstName = @first WHERE employeeID = @id AND firstName = @sfirst;", dbcon);
            if (last_textbox.Text.Length > 0)
            {
                updateFirst.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateFirst.Parameters.AddWithValue("@first", sfirst_textbox.Text);
                updateFirst.Parameters.AddWithValue("@first", first_textbox.Text);
            }

            //last name
            MySqlCommand updateLast = new MySqlCommand("UPDATE staff SET lastName = @last WHERE employeeID = @id AND firstName = @first;", dbcon);
            if (last_textbox.Text.Length > 0)
            {
                updateLast.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateLast.Parameters.AddWithValue("@first", sfirst_textbox.Text);
                updateLast.Parameters.AddWithValue("@last", last_textbox.Text);
            }

            //gender
            MySqlCommand updateGender = new MySqlCommand("UPDATE staff SET gender = @gender WHERE employeeID = @id AND firstName = @first;", dbcon);
            if (gender_textbox.Text.Length > 0)
            {
                updateGender.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateGender.Parameters.AddWithValue("@first", sfirst_textbox.Text);
                updateGender.Parameters.AddWithValue("@gender", gender_textbox.Text);
            }

            //salary
            //hotel
            MySqlCommand updateHSalary = new MySqlCommand("UPDATE works_hotel SET staffPayroll = @salary WHERE staID = @id;", dbcon); ;
            if (sjsite_textbox.Text.ToLower() == "hotel" && salary_textbox.Text.Length > 0)
            {
                updateHSalary.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateHSalary.Parameters.AddWithValue("@salary", salary_textbox.Text);

            }

            //restaurant
            MySqlCommand updateRestSalary = new MySqlCommand("UPDATE works_restaurant SET staffPayroll = @salary WHERE staID = @id;", dbcon);
            if (sjsite_textbox.Text.ToLower() == "restaurant" && salary_textbox.Text.Length > 0)
            {
                updateRestSalary.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateRestSalary.Parameters.AddWithValue("@salary", salary_textbox.Text);
            }

            //ride
            MySqlCommand updateRSalary = new MySqlCommand("UPDATE works_ride SET staffPayroll = @salary WHERE staID = @id;", dbcon);
            if (sjsite_textbox.Text.ToLower() == "ride" && salary_textbox.Text.Length > 0)
            {
                updateRSalary.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateRSalary.Parameters.AddWithValue("@salary", salary_textbox.Text);
            }

            //jid
            //hotel
            MySqlCommand updateHID = new MySqlCommand("UPDATE works_hotel SET hotID = @jid WHERE staID = @id;", dbcon);
            if (sjsite_textbox.Text.ToLower() == "hotel" && jid_textbox.Text.Length > 0)
            {
                updateHID.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateHID.Parameters.AddWithValue("@jid", jid_textbox.Text);
            }

            //restaurant
            MySqlCommand updateRestID = new MySqlCommand("UPDATE works_restaurant SET restID = @jid WHERE staID = @id;", dbcon);
            if (sjsite_textbox.Text.ToLower() == "restaurant" && jid_textbox.Text.Length > 0)
            {
                updateRestID.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateRestID.Parameters.AddWithValue("@jid", jid_textbox.Text);
            }

            //ride
            MySqlCommand updateRID = new MySqlCommand("UPDATE works_ride SET rID = @jid WHERE staID = @id;", dbcon);
            if (sjsite_textbox.Text.ToLower() == "ride" && jid_textbox.Text.Length > 0)
            {
                updateRID.Parameters.AddWithValue("@id", sid_textbox.Text);
                updateRID.Parameters.AddWithValue("@jid", jid_textbox.Text);
            }


            dbcon.Open();
            if (first_textbox.Text.Length > 0)
            {
                updateFirst.ExecuteNonQuery();
            }
            if (last_textbox.Text.Length > 0)
            {
                updateLast.ExecuteNonQuery();
            }
            if (gender_textbox.Text.Length > 0)
            {
                updateGender.ExecuteNonQuery();
            }

            //salary
            if (sjsite_textbox.Text.ToLower() == "hotel" && salary_textbox.Text.Length > 0)
            {
                updateHSalary.ExecuteNonQuery();
            }
            if (sjsite_textbox.Text.ToLower() == "restaurant" && salary_textbox.Text.Length > 0)
            {
                updateRestSalary.ExecuteNonQuery();
            }
            if (sjsite_textbox.Text.ToLower() == "ride" && salary_textbox.Text.Length > 0)
            {
                updateRSalary.ExecuteNonQuery();
            }

            //job id
            if (sjsite_textbox.Text.ToLower() == "hotel" && jid_textbox.Text.Length > 0)
            {
                updateHID.ExecuteNonQuery();
            }
            if (sjsite_textbox.Text.ToLower() == "restaurant" && jid_textbox.Text.Length > 0)
            {
                updateRestID.ExecuteNonQuery();
            }
            if (sjsite_textbox.Text.ToLower() == "ride" && jid_textbox.Text.Length > 0)
            {
                updateRID.ExecuteNonQuery();
            }

            dbcon.Close();

            if (IsPostBack)
            {
                sid_textbox.Text = "";
                sfirst_textbox.Text = "";
                sjsite_textbox.Text = "";
                first_textbox.Text = "";
                last_textbox.Text = "";
                gender_textbox.Text = "";
                salary_textbox.Text = "";
                jid_textbox.Text = "";
            }
        }
    }
}