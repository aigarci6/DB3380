using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchCredentials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errormessage.Visible = false;
        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            
            int id;
            string user;
            string password;
            string htmlStr = "";

            dbcon.Open();

            //auto (all)
            if (sid_textbox.Text.Length == 0 && suser_textbox.Text.Length == 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT * FROM credentials SORT ORDER BY userName ASC;", dbcon);
                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    user = sReader.GetString(1);
                    password = sReader.GetString(2);
                    htmlStr += "<tr><td>" + id + "</td><td>" + user + "</td><td>" + password + "</td></tr>";
                }
                sReader.Close();
            }

            //search by id
            if (sid_textbox.Text.Length > 0 && suser_textbox.Text.Length == 0)
            {
                MySqlCommand searchByID = new MySqlCommand("SELECT * FROM credentials WHERE userID = @id ORDER BY userName ASC;", dbcon);
                searchByID.Parameters.AddWithValue("@id", sid_textbox.Text);
                MySqlDataReader idReader = searchByID.ExecuteReader();
                while (idReader.Read())
                {
                    id = idReader.GetInt32(0);
                    user = idReader.GetString(1);
                    password = idReader.GetString(2);
                    htmlStr += "<tr><td>" + id + "</td><td>" + user + "</td><td>" + password + "</td></tr>";
                }
                idReader.Close();
            }

            //search by user
            if (sid_textbox.Text.Length == 0 && suser_textbox.Text.Length > 0)
            {
                MySqlCommand searchByUser = new MySqlCommand("SELECT * FROM credentials WHERE userName = @userName ORDER BY userName ASC;", dbcon);
                searchByUser.Parameters.AddWithValue("@userName", suser_textbox.Text);
                MySqlDataReader userReader = searchByUser.ExecuteReader();
                while (userReader.Read())
                {
                    id = userReader.GetInt32(0);
                    user = userReader.GetString(1);
                    password = userReader.GetString(2);
                    htmlStr += "<tr><td>" + id + "</td><td>" + user + "</td><td>" + password + "</td></tr>";
                }
                userReader.Close();
            }

            //search by both
            if (sid_textbox.Text.Length > 0 && suser_textbox.Text.Length > 0)
            {
                MySqlCommand searchAll = new MySqlCommand("SELECT * FROM credentials WHERE userID = @id AND userName = @userName ORDER BY userName ASC;", dbcon);
                searchAll.Parameters.AddWithValue("@id", id_textbox.Text);
                searchAll.Parameters.AddWithValue("@userName", suser_textbox.Text);
                MySqlDataReader allReader = searchAll.ExecuteReader();
                while (allReader.Read())
                {
                    id = allReader.GetInt32(0);
                    user = allReader.GetString(1);
                    password = allReader.GetString(2);
                    htmlStr += "<tr><td>" + id + "</td><td>" + user + "</td><td>" + password + "</td></tr>";
                }
                allReader.Close();
            }
            
            dbcon.Close();
            return htmlStr;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

                if (id_textbox.Text.Length > 0)
                {
                    //username
                    MySqlCommand updateUser = new MySqlCommand("UPDATE credentials SET userName = @userName WHERE userID = @userID;", dbcon);
                    if (user_textbox.Text.Length > 0)
                    {
                        updateUser.Parameters.AddWithValue("@userID", id_textbox.Text);
                        updateUser.Parameters.AddWithValue("@userName", user_textbox.Text);
                    }

                    //password
                    MySqlCommand updatePass = new MySqlCommand("UPDATE credentials SET password = @password WHERE userID = @userID;", dbcon);
                    if (pass_textbox.Text.Length > 0)
                    {
                        updatePass.Parameters.AddWithValue("@userID", id_textbox.Text);
                        updatePass.Parameters.AddWithValue("@password", pass_textbox.Text);
                    }

                    dbcon.Open();
                    if (user_textbox.Text.Length > 0)
                    {
                        updateUser.ExecuteNonQuery();
                    }
                    if (pass_textbox.Text.Length > 0)
                    {
                        updatePass.ExecuteNonQuery();
                    }
                    dbcon.Close();

                    if (IsPostBack)
                    {
                        id_textbox.Text = "";
                        user_textbox.Text = "";
                        pass_textbox.Text = "";
                    }

                    if (IsPostBack == true)
                    {
                        Response.Write("<script>alert('Credentials updated successfully!')</script>");
                    }
                }
            }

            else { 
                errormessage.Visible = true; 
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        }
    }
}