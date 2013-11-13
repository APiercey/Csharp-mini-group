using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public partial class secureLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginError.Text = "";

            if (Session["user"] != null)
            {
                Response.Redirect("~/homePage.aspx");
            }   
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user;
            SqlCommand command;
            SqlDataReader reader;

            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    //Creates a command and adds parameters from form fields
                    //This will determine if user exists
                    command = new SqlCommand("SELECT * FROM Employees WHERE Email=@Email AND Password=@Password", db);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);

                    //Executes command and returns a SqlDataReader
                    reader = command.ExecuteReader();

                    //Determines if the select statement retrieved a result
                    //If true, than the user exists in the Database
                    if (reader.HasRows)
                    {
                        //Initialize the reader, and move the reader cursorer to the result set
                        while (reader.Read())
                        {
                            //Create a user object by passing the reader to the object constructor
                            //**See the class file to see how this works
                            user = new User(reader);

                            //Add the user to a session variable for future use on other pages
                            //Redirect user to the websites homepage
                            Session["user"] = user;
                            Response.Redirect("~/homePage.aspx");
                        }
                    }
                    else
                    {
                        //If these user does not exist in the database display this error message
                        lblLoginError.Text = "<span id='error'>Email password combination does not exist!</span>";
                    }
                    
                }
                catch (Exception ex)
                {
                    lblEmail.Text = ex.ToString();
                }
            }
        }
    }
}