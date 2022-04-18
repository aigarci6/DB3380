using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddCredentials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if ((string)Session["username"] != "HR")
            {
                Response.Redirect("BadAccess.html");
            }
            

            if (IsPostBack == true)
            {
                Response.Write("<script>alert('New login added successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand insert = new MySqlCommand("INSERT INTO credentials(userID, userName, password, jobCategory) VALUES (@userID, @userName, @password, @jobCategory);", dbcon);
            insert.Parameters.AddWithValue("@userID", id_textbox.Text);
            insert.Parameters.AddWithValue("@userName", user_textbox.Text);
            insert.Parameters.AddWithValue("@password", pass_textbox.Text);


            //find job type
            string jcategory;
            MySqlCommand search = new MySqlCommand("SELECT IFNULL(jobCategory, @auto) FROM staff WHERE employeeID = @userID;", dbcon);
            search.Parameters.AddWithValue("@userID", id_textbox.Text);
            search.Parameters.AddWithValue("@auto", "n/a");
            dbcon.Open();
            MySqlDataReader sReader = search.ExecuteReader();
            sReader.Read();
            jcategory = sReader.GetString(0);
            sReader.Close();

            insert.Parameters.AddWithValue("@jobCategory", jcategory);

            
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                user_textbox.Text = "";
                pass_textbox.Text = "";
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