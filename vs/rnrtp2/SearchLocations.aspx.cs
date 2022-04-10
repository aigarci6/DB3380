using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchLocations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Location updated successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            //location name
            MySqlCommand updateName = new MySqlCommand("UPDATE location SET locationName = @locationName WHERE locationID = @locationID;", dbcon);
            if (name_textbox.Text.Length > 0)
            {
                updateName.Parameters.AddWithValue("@locationID", id_textbox.Text);
                updateName.Parameters.AddWithValue("@locationName", name_textbox.Text);
            }

            dbcon.Open();
            if (name_textbox.Text.Length > 0)
            {
                updateName.ExecuteNonQuery();
            }
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                name_textbox.Text = "";
            }
        }
    }
}