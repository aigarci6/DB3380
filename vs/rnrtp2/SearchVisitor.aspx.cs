using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchVisitor : System.Web.UI.Page
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

            //location
            MySqlCommand updateTicketType = new MySqlCommand("UPDATE visitor SET ticketType = @type, ticketCost = @cost WHERE ticketID = @id AND visitDate = @date;", dbcon);
            if (type_textbox.Text.Length > 0)
            {
                updateTicketType.Parameters.AddWithValue("@id", id_textbox.Text);
                updateTicketType.Parameters.AddWithValue("@date", date_textbox.Text);

                if (type_textbox.Text == "Seasonal" || type_textbox.Text == "seasonal")
                {
                    updateTicketType.Parameters.AddWithValue("@type", "seasonal");
                    updateTicketType.Parameters.AddWithValue("@cost", 350);
                }

                if (type_textbox.Text == "General" || type_textbox.Text == "general")
                {
                    updateTicketType.Parameters.AddWithValue("@type", "general");
                    updateTicketType.Parameters.AddWithValue("@cost", 150);
                }
            }

            //email
            MySqlCommand updateEmail = new MySqlCommand("UPDATE visitor SET email = @email WHERE ticketID = @id AND visitDate = @date;", dbcon);
            if (email_textbox.Text.Length > 0)
            {
                updateEmail.Parameters.AddWithValue("@id", id_textbox.Text);
                updateEmail.Parameters.AddWithValue("@date", date_textbox.Text);
                updateEmail.Parameters.AddWithValue("@email", email_textbox.Text);
            }

            dbcon.Open();
            if (type_textbox.Text.Length > 0)
            {
                updateTicketType.ExecuteNonQuery();
            }
            if (email_textbox.Text.Length > 0)
            {
                updateEmail.ExecuteNonQuery();
            }
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                date_textbox.Text = "";
                type_textbox.Text = "";
                email_textbox.Text = "";
            }
        }
    }
}