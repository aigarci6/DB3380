using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            if ((string)Session["username"] != "HR" || (string)Session["username"] != "hotel" || (string)Session["username"] != "ride" || (string)Session["username"] != "restaurant")
            {
                Response.Redirect("BadAccess.html");
            }
            */

            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Visitor added successfully!')</script>");
            }

            DateTime now = DateTime.Now;

            date.Value = now.Date.ToString("yyyy-MM-dd");
        }

        protected void buttonClick(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertVisitor(@p_visitDate, @p_month, @p_day, @p_year, @p_ticketType, @p_ticketCost, @p_email);", dbcon);
            insert.Parameters.AddWithValue("@p_visitDate", date.Value);
            insert.Parameters.AddWithValue("@p_ticketType", ticket.Value);
            insert.Parameters.AddWithValue("@p_email", email.Value);//*/

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

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                date.Value = "";
                ticket.Value = "";
                email.Value = "";
            }
        }

        protected void HomeLink(object sender, EventArgs e)
        {
            if ((string)Session["username"] == "HR")
            {
                Response.Redirect("Index.aspx");
            }

            if ((string)Session["username"] == "hotel")
            {
                Response.Redirect("HotelIndex.aspx");
            }

            if ((string)Session["username"] == "restaurant")
            {
                Response.Redirect("RestIndex.aspx");
            }

            if ((string)Session["username"] == "ride")
            {
                Response.Redirect("RideIndex.aspx");
            }
        }
    }
}