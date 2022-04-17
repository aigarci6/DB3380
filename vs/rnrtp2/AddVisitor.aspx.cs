﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddVisitor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {/*
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if ((string)Session["username"] != "admin" || (string)Session["username"] != "hotelstaff" || (string)Session["username"] != "ridestaff" || (string)Session["username"] != "reststaff")
            {
                Response.Redirect("BadAccess.html");
            }
            */

            //to send email 
            /*SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "rocknrollthemepark.mysql@gmail.com",
                    Password = "cosc3380!"
                }
            };
            MailAddress fromEmail = new MailAddress("rocknrollthemepark.mysql@gmail.com", "DB 3380");
            MailAddress toEmail = new MailAddress("medinaitsai@gmail.com", "The Hippest");
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = "Email Test",
                Body = "Check check 123",
            };
            message.To.Add(toEmail);

            try
            {
                client.Send(message);
                MessageBox.Show("Sent Successfully", "Done");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "error"); } //email ends here*/
            

            /* if (IsPostBack == true)
            {
                Response.Write("<script>alert('Visitor added successfully!')</script>");
            }*/

            DateTime now = DateTime.Now;

            date.Value = now.Date.ToString("yyyy-MM-dd");
        }

        protected void buttonClick(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertVisitor(@p_visitDate, @p_month, @p_day, @p_year, @p_ticketType, @p_ticketCost, @p_email);", dbcon);
            MySqlCommand emailQ = new MySqlCommand("SELECT * FROM emailq WHERE type='visitor' AND email=@emayl;", dbcon);
            MySqlCommand delEmail = new MySqlCommand("DELETE FROM emailq WHERE idEmail=@emailID;", dbcon); //to delete email row once email has been sent
            insert.Parameters.AddWithValue("@p_visitDate", date.Value);
            insert.Parameters.AddWithValue("@p_ticketType", ticket.Value);
            insert.Parameters.AddWithValue("@p_email", email.Value);
            emailQ.Parameters.AddWithValue("@emayl", email.Value);

            //get ticket cost
            if (ticket.Value == "general")
            {
                insert.Parameters.AddWithValue("@p_ticketCost", 50);
            }
            else if (ticket.Value == "seasonal")
            {
                insert.Parameters.AddWithValue("@p_ticketCost", 200);
            }

            //parse date
            string str = date.Value;
            string[] dates = str.Split('-');

            insert.Parameters.AddWithValue("@p_year", dates[0]);
            insert.Parameters.AddWithValue("@p_month", dates[1]);
            insert.Parameters.AddWithValue("@p_day", dates[2]);
            //inserting data
            dbcon.Open();
            insert.ExecuteNonQuery();

            //retriving email info
            MySqlDataReader emailReader = emailQ.ExecuteReader();
            emailReader.Read();
            int emailID = emailReader.GetInt32(0);
            string subject = emailReader.GetString(2);
            int visitorID = emailReader.GetInt32(4);
            emailReader.Close();

            //deleting email row cuz info retrieved already
            delEmail.Parameters.AddWithValue("@emailID", emailID);
            delEmail.ExecuteNonQuery();

            dbcon.Close();

            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "rocknrollthemepark.mysql@gmail.com",
                    Password = "cosc3380!"
                }
            };
            MailAddress fromEmail = new MailAddress("rocknrollthemepark.mysql@gmail.com", "DB 3380");
            MailAddress toEmail = new MailAddress(email.Value, "The Hippest");
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = subject,
                Body = "Congratulations on your order! \nYour ticket ID is #" + visitorID + " with a ticket type of "+ ticket.Value + ".\nEnjoy your visit!\n- Rock-n-Roll Theme Park",
            };
            message.To.Add(toEmail);

            try
            {
                client.Send(message);
                MessageBox.Show("Sent Successfully", "Done");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "error"); } //*/

            if (IsPostBack)
            {
                date.Value = "";
                ticket.Value = "";
                email.Value = "";
            }
        }
    }
}