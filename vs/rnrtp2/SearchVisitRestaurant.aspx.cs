﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchVisitRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0 && rid_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

                //amount spent
                MySqlCommand updateSpending = new MySqlCommand("UPDATE visit_restaurant SET amountSpent = @amountSpent WHERE tickID_r = @tickIDr AND restID = @restID;", dbcon);
                if (spent_textbox.Text.Length > 0)
                {
                    updateSpending.Parameters.AddWithValue("@tickIDr", id_textbox.Text);
                    updateSpending.Parameters.AddWithValue("@restID", rid_textbox.Text);
                    updateSpending.Parameters.AddWithValue("@amountSpent", spent_textbox.Text);
                }

                dbcon.Open();
                if (spent_textbox.Text.Length > 0)
                {
                    updateSpending.ExecuteNonQuery();
                }
                dbcon.Close();

                if (IsPostBack)
                {
                    id_textbox.Text = "";
                    rid_textbox.Text = "";
                    spent_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Response.Write("<script>alert('Visit updated successfully!')</script>");
                }
            }
        }
            

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            int vid;
            string vemail;
            int rid;
            string rname;
            double spent;
            string htmlStr = "";

            dbcon.Open();

            // none
            if (search.Value == "none")
            {
            }

            //* (all)
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID ORDER BY tickID_r ASC;", dbcon);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            //visitor id
            if (search.Value == "vid")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID WHERE tickID_r = @id ORDER BY tickID_r ASC;", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            //restaurant id
            if (search.Value == "rid")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID WHERE restID = @id ORDER BY tickID_r ASC;", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            //spent greater than
            if (search.Value == "spent_greater")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID WHERE amountSpent > @spent ORDER BY tickID_r ASC;", dbcon);
                search.Parameters.AddWithValue("@spent", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            //spent less than
            if (search.Value == "spent_less")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID WHERE amountSpent < @spent ORDER BY tickID_r ASC;", dbcon);
                search.Parameters.AddWithValue("@spent", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            dbcon.Close();
            return htmlStr;
        }
    }
}