﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errormessage.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand insert = new MySqlCommand("SELECT COUNT(1) FROM credentials WHERE userName = @username AND password = @password", dbcon);

            dbcon.Open();
            insert.Parameters.AddWithValue("@username", username_textbox.Text.Trim());
            insert.Parameters.AddWithValue("@password", pass_textbox.Text.Trim());
            int count = Convert.ToInt32(insert.ExecuteScalar());
            if (count == 1)
            {
                Session["username"] = username_textbox.Text.Trim();
                Response.Redirect("Index.aspx");
            }
            
            else
            {
                errormessage.Visible = true;
            }
            dbcon.Close();
        }
    }
}