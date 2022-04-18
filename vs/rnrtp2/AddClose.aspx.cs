using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddClose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if ((string)Session["username"] != "admin" || (string)Session["username"] != "ridestaff")
            {
                Response.Redirect("BadAccess.html");
            }
            */


            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Ride closed successfully!')</script>");
            }

            DateTime now = DateTime.Now;

            string hour = now.Hour.ToString();
            string minute = now.Minute.ToString();
            string second = now.Second.ToString();

            date.Value = now.Date.ToString("yyyy-MM-dd");
            time_textbox.Text = hour + ":" + minute + ":" + second;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand insert = new MySqlCommand("INSERT INTO closes (rideID, employeeID, date, time, type, cost, month, year) VALUES (@rideid, @empID, @dte, @tme, @tpe, @cst, @munth, @yeer);", dbcon);
            MySqlCommand count = new MySqlCommand("SELECT COUNT(DISTINCT email) FROM staff;", dbcon);
            MySqlCommand emails = new MySqlCommand("SELECT DISTINCT IFNULL(email, 0) FROM staff;", dbcon);
            MySqlCommand delEmail = new MySqlCommand("DELETE FROM emailq WHERE idEmail=@emailID;", dbcon);
            MySqlCommand emailQ = new MySqlCommand("SELECT IFNULL(idEmail, 0) FROM emailq, closes WHERE emailq.relatedID=closes.closeID AND closes.rideID=@ridID AND closes.employeeID=@stafID", dbcon);

            //parse date
            string str = date.Value;
            string[] dates = str.Split('-');

            insert.Parameters.AddWithValue("@rideid", rid_textbox.Text);
            insert.Parameters.AddWithValue("@empID", eid_textbox.Text);
            insert.Parameters.AddWithValue("@dte", date.Value);
            insert.Parameters.AddWithValue("@tme", time_textbox.Text);
            insert.Parameters.AddWithValue("@tpe", type.Value);
            insert.Parameters.AddWithValue("@cst", cost.Text);
            insert.Parameters.AddWithValue("@yeer", dates[0]);
            insert.Parameters.AddWithValue("@munth", dates[1]);
            emailQ.Parameters.AddWithValue("@ridID", rid_textbox.Text);
            emailQ.Parameters.AddWithValue("@stafID", eid_textbox.Text);

            dbcon.Open();
            insert.ExecuteNonQuery();

            //retriving emailq info
            MySqlDataReader emailQReader = emailQ.ExecuteReader();
            emailQReader.Read();
            int emailID = emailQReader.GetInt32(0);            
            emailQReader.Close();

            //retrieving number of emails           
            MySqlDataReader emailCounter = count.ExecuteReader();
            emailCounter.Read();
            int eCount = emailCounter.GetInt32(0);
            emailCounter.Close();


            //deleting email row cuz info retrieved already
            delEmail.Parameters.AddWithValue("@emailID", emailID);
            delEmail.ExecuteNonQuery();

            //retriving emails
            MySqlDataReader emailsReader = emails.ExecuteReader();
            emailsReader.Read();
            string body = "";
            for (int i = 0; i < eCount; i++)
            {
                body += emailsReader.GetString(i);//need to find a way to iterate through rows; right now its doing through columns
            }

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
            MailAddress toEmail = new MailAddress("medinaitsai@gmail.com", "The Hippest");
            MailMessage message = new MailMessage()
            {
                From = fromEmail,
                Subject = "Ride Closed",
                Body = body,
            };
            message.To.Add(toEmail);


            try
            {
                client.Send(message);
                /*MessageBox.Show("Sent Successfully", "Done");*/
            }
            catch (Exception ex)
            { /*MessageBox.Show(ex.Message, "error");*/
                //errormessage.Visible = true;
            }

            emailsReader.Close();
            dbcon.Close();


            if (IsPostBack)
            {
                rid_textbox.Text = "";
                eid_textbox.Text = "";
                date.Value = "";
                time_textbox.Text = "";
                type.Value = "";
                cost.Text = "0";
            }
        }
    }
}