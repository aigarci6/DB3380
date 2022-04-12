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
            
        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            int id;
            string first;
            string last;
            char gender;
            int salary;
            string category;
            int jobid = 0;
            string htmlStr = "";

            dbcon.Open();

            //auto (all)
            if (search.Value == "none")
            {
                MySqlCommand search = new MySqlCommand("SELECT employeeID, firstName, lastName, gender, weeklySalary, jobCategory, restID, hotID, rID FROM staff LEFT OUTER JOIN works_restaurant ON employeeID = works_restaurant.staID LEFT OUTER JOIN works_hotel ON employeeID = works_hotel.staID LEFT OUTER JOIN works_ride ON employeeID = works_ride.staID ORDER BY employeeID ASC;", dbcon);
                MySqlDataReader reader = search.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    first = reader.GetString(1);
                    last = reader.GetString(2);
                    gender = reader.GetChar(3);
                    salary = reader.GetInt32(4);
                    category = reader.GetString(5);

                    if (category == "restaurant")
                    {
                        jobid = reader.GetInt32(6);
                    }

                    if (category == "hotel")
                    {
                        jobid = reader.GetInt32(7);
                    }

                    if (category == "ride")
                    {
                        jobid = reader.GetInt32(8);
                    }

                    htmlStr += "<tr><td>" + id + "</td><td>" + first + "</td><td>" + last + "</td><td>" + gender + "</td><td>" + salary + "</td><td>" + category + "</td><td>" + jobid + "</td></tr>";
                }
                reader.Close();
            }

            //search by id
            if (search.Value == "id" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT employeeID, firstName, lastName, gender, weeklySalary, jobCategory, restID, hotID, rID FROM staff LEFT OUTER JOIN works_restaurant ON employeeID = works_restaurant.staID LEFT OUTER JOIN works_hotel ON employeeID = works_hotel.staID LEFT OUTER JOIN works_ride ON employeeID = works_ride.staID WHERE employeeID = @id ORDER BY firstName ASC;", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);
                MySqlDataReader reader = search.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    first = reader.GetString(1);
                    last = reader.GetString(2);
                    gender = reader.GetChar(3);
                    salary = reader.GetInt32(4);
                    category = reader.GetString(5);

                    if (category == "restaurant")
                    {
                        jobid = reader.GetInt32(6);
                    }

                    if (category == "hotel")
                    {
                        jobid = reader.GetInt32(7);
                    }

                    if (category == "ride")
                    {
                        jobid = reader.GetInt32(8);
                    }

                    htmlStr += "<tr><td>" + id + "</td><td>" + first + "</td><td>" + last + "</td><td>" + gender + "</td><td>" + salary + "</td><td>" + category + "</td><td>" + jobid + "</td></tr>";
                }
                reader.Close();
            }

            //first name
            if (search.Value == "first" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT employeeID, firstName, lastName, gender, weeklySalary, jobCategory, restID, hotID, rID FROM staff LEFT OUTER JOIN works_restaurant ON employeeID = works_restaurant.staID LEFT OUTER JOIN works_hotel ON employeeID = works_hotel.staID LEFT OUTER JOIN works_ride ON employeeID = works_ride.staID WHERE firstName = @first ORDER BY employeeID ASC;", dbcon);
                search.Parameters.AddWithValue("@first", field_textbox.Text);
                MySqlDataReader reader = search.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    first = reader.GetString(1);
                    last = reader.GetString(2);
                    gender = reader.GetChar(3);
                    salary = reader.GetInt32(4);
                    category = reader.GetString(5);

                    if (category == "restaurant")
                    {
                        jobid = reader.GetInt32(6);
                    }

                    if (category == "hotel")
                    {
                        jobid = reader.GetInt32(7);
                    }

                    if (category == "ride")
                    {
                        jobid = reader.GetInt32(8);
                    }

                    htmlStr += "<tr><td>" + id + "</td><td>" + first + "</td><td>" + last + "</td><td>" + gender + "</td><td>" + salary + "</td><td>" + category + "</td><td>" + jobid + "</td></tr>";
                }
                reader.Close();
            }

            //last name
            if (search.Value == "last" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT employeeID, firstName, lastName, gender, weeklySalary, jobCategory, restID, hotID, rID FROM staff LEFT OUTER JOIN works_restaurant ON employeeID = works_restaurant.staID LEFT OUTER JOIN works_hotel ON employeeID = works_hotel.staID LEFT OUTER JOIN works_ride ON employeeID = works_ride.staID WHERE lastName = @last ORDER BY employeeID ASC;", dbcon);
                search.Parameters.AddWithValue("@last", field_textbox.Text);
                MySqlDataReader reader = search.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    first = reader.GetString(1);
                    last = reader.GetString(2);
                    gender = reader.GetChar(3);
                    salary = reader.GetInt32(4);
                    category = reader.GetString(5);

                    if (category == "restaurant")
                    {
                        jobid = reader.GetInt32(6);
                    }

                    if (category == "hotel")
                    {
                        jobid = reader.GetInt32(7);
                    }

                    if (category == "ride")
                    {
                        jobid = reader.GetInt32(8);
                    }

                    htmlStr += "<tr><td>" + id + "</td><td>" + first + "</td><td>" + last + "</td><td>" + gender + "</td><td>" + salary + "</td><td>" + category + "</td><td>" + jobid + "</td></tr>";
                }
                reader.Close();
            }

            //gender
            if (search.Value == "gender" && field_textbox.Text.Length > 0)
            {
                if (field_textbox.Text.ToLower() == "m" || field_textbox.Text.ToLower() == "f" || field_textbox.Text.ToLower() == "u")
                {
                    MySqlCommand search = new MySqlCommand("SELECT employeeID, firstName, lastName, gender, weeklySalary, jobCategory, restID, hotID, rID FROM staff LEFT OUTER JOIN works_restaurant ON employeeID = works_restaurant.staID LEFT OUTER JOIN works_hotel ON employeeID = works_hotel.staID LEFT OUTER JOIN works_ride ON employeeID = works_ride.staID WHERE gender = @gender ORDER BY employeeID ASC;", dbcon);
                    search.Parameters.AddWithValue("@gender", field_textbox.Text);
                    MySqlDataReader reader = search.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                        first = reader.GetString(1);
                        last = reader.GetString(2);
                        gender = reader.GetChar(3);
                        salary = reader.GetInt32(4);
                        category = reader.GetString(5);

                        if (category == "restaurant")
                        {
                            jobid = reader.GetInt32(6);
                        }

                        if (category == "hotel")
                        {
                            jobid = reader.GetInt32(7);
                        }

                        if (category == "ride")
                        {
                            jobid = reader.GetInt32(8);
                        }

                        htmlStr += "<tr><td>" + id + "</td><td>" + first + "</td><td>" + last + "</td><td>" + gender + "</td><td>" + salary + "</td><td>" + category + "</td><td>" + jobid + "</td></tr>";
                    }

                    reader.Close();
                }

                else
                {
                    field_textbox.Text = "INVALID: m/f/u ONLY";
                }
            }

            //salary more than
            if (search.Value == "sal_more" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT employeeID, firstName, lastName, gender, weeklySalary, jobCategory, restID, hotID, rID FROM staff LEFT OUTER JOIN works_restaurant ON employeeID = works_restaurant.staID LEFT OUTER JOIN works_hotel ON employeeID = works_hotel.staID LEFT OUTER JOIN works_ride ON employeeID = works_ride.staID WHERE weeklySalary > @salary ORDER BY weeklySalary ASC;", dbcon);
                search.Parameters.AddWithValue("@salary", field_textbox.Text);
                MySqlDataReader reader = search.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    first = reader.GetString(1);
                    last = reader.GetString(2);
                    gender = reader.GetChar(3);
                    salary = reader.GetInt32(4);
                    category = reader.GetString(5);

                    if (category == "restaurant")
                    {
                        jobid = reader.GetInt32(6);
                    }

                    if (category == "hotel")
                    {
                        jobid = reader.GetInt32(7);
                    }

                    if (category == "ride")
                    {
                        jobid = reader.GetInt32(8);
                    }

                    htmlStr += "<tr><td>" + id + "</td><td>" + first + "</td><td>" + last + "</td><td>" + gender + "</td><td>" + salary + "</td><td>" + category + "</td><td>" + jobid + "</td></tr>";
                }
                reader.Close();
            }

            //salary less than
            if (search.Value == "sal_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT employeeID, firstName, lastName, gender, weeklySalary, jobCategory, restID, hotID, rID FROM staff LEFT OUTER JOIN works_restaurant ON employeeID = works_restaurant.staID LEFT OUTER JOIN works_hotel ON employeeID = works_hotel.staID LEFT OUTER JOIN works_ride ON employeeID = works_ride.staID WHERE weeklySalary < @salary ORDER BY weeklySalary ASC;", dbcon);
                search.Parameters.AddWithValue("@salary", field_textbox.Text);
                MySqlDataReader reader = search.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    first = reader.GetString(1);
                    last = reader.GetString(2);
                    gender = reader.GetChar(3);
                    salary = reader.GetInt32(4);
                    category = reader.GetString(5);

                    if (category == "restaurant")
                    {
                        jobid = reader.GetInt32(6);
                    }

                    if (category == "hotel")
                    {
                        jobid = reader.GetInt32(7);
                    }

                    if (category == "ride")
                    {
                        jobid = reader.GetInt32(8);
                    }

                    htmlStr += "<tr><td>" + id + "</td><td>" + first + "</td><td>" + last + "</td><td>" + gender + "</td><td>" + salary + "</td><td>" + category + "</td><td>" + jobid + "</td></tr>";
                }
                reader.Close();
            }

            //job category
            if (search.Value == "category" && field_textbox.Text.Length > 0)
            {
                if (field_textbox.Text.ToLower() == "hotel" || field_textbox.Text.ToLower() == "restaurant" || field_textbox.Text.ToLower() == "ride")
                {
                    MySqlCommand search = new MySqlCommand("SELECT employeeID, firstName, lastName, gender, weeklySalary, jobCategory, restID, hotID, rID FROM staff LEFT OUTER JOIN works_restaurant ON employeeID = works_restaurant.staID LEFT OUTER JOIN works_hotel ON employeeID = works_hotel.staID LEFT OUTER JOIN works_ride ON employeeID = works_ride.staID WHERE jobCategory = @category ORDER BY employeeID ASC;", dbcon);
                    search.Parameters.AddWithValue("@category", field_textbox.Text.ToLower());
                    MySqlDataReader reader = search.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                        first = reader.GetString(1);
                        last = reader.GetString(2);
                        gender = reader.GetChar(3);
                        salary = reader.GetInt32(4);
                        category = reader.GetString(5);

                        if (category == "restaurant")
                        {
                            jobid = reader.GetInt32(6);
                        }

                        if (category == "hotel")
                        {
                            jobid = reader.GetInt32(7);
                        }

                        if (category == "ride")
                        {
                            jobid = reader.GetInt32(8);
                        }

                        htmlStr += "<tr><td>" + id + "</td><td>" + first + "</td><td>" + last + "</td><td>" + gender + "</td><td>" + salary + "</td><td>" + category + "</td><td>" + jobid + "</td></tr>";
                    }
                    reader.Close();
                }

                else
                {
                    field_textbox.Text = "INVALID";
                }
            }

            dbcon.Close();
            return htmlStr;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (sid_textbox.Text.Length > 0 && sfirst_textbox.Text.Length > 0 && sjsite_textbox.Text.Length > 0)
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
                MySqlCommand updateSalary = new MySqlCommand("UPDATE staff SET weeklySalary = @salary WHERE employeeID = @id AND firstName = @sfirst;", dbcon); ;
                if (sjsite_textbox.Text.ToLower() == "hotel" && salary_textbox.Text.Length > 0)
                {
                    updateSalary.Parameters.AddWithValue("@id", sid_textbox.Text);
                    updateSalary.Parameters.AddWithValue("@first", sfirst_textbox.Text);
                    updateSalary.Parameters.AddWithValue("@salary", salary_textbox.Text);

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
                if (salary_textbox.Text.Length > 0)
                {
                    updateSalary.ExecuteNonQuery();
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

                if (IsPostBack == true)
                {
                    Button1.Text = "Updated!";
                }
            }
        }
    }
}