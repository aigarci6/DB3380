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
            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Credentials updated successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

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
        }
    }
}