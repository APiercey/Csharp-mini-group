using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WidgetGoods
{
    public partial class manageEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hossein was here again
        }

        protected void btnShowAddEmployee_Click(object sender, EventArgs e)
        {            
            pnlEditEmployee.Visible = false;
            pnlAddEmployee.Visible = true;
        }

        protected void btnShowEditEmployee_Click(object sender, EventArgs e)
        {
            pnlEditEmployee.Visible = true;
            pnlAddEmployee.Visible = false;
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    String newEmployeeQuery = @"INSERT INTO Employees (LastName,   FirstName, Title, 
                                                                       BirthDate,  HireDate,  TitleOfCourtesy, 
                                                                       Address,    City,      Region, 
                                                                       PostalCode, Country,   HomePhone, 
                                                                       Extension,  Photo,     Email, 
                                                                       Admin,      Password,  Commission)

                                                               VALUES (@LastName,   @FirstName, @Title, 
                                                                       @BirthDate,  @HireDate,  @TitleOfCourtesy,  
                                                                       @Address,    @City,      @Region, 
                                                                       @PostalCode  @Country,   @HomePhone, 
                                                                       @Extension,  @Photo,     @Email, 
                                                                       @Admin,      @Password,  @Commission)";

                    SqlCommand command = new SqlCommand(newEmployeeQuery, db);

                    command.Parameters.AddWithValue("@LastName",        txtLastName.Text);
                    command.Parameters.AddWithValue("@FirstName",       txtFirstName.Text);
                    command.Parameters.AddWithValue("@Title",           txtTitle.Text);
                    command.Parameters.AddWithValue("@TitleOfCourtesy", txtTitleOfCourtesy.Text);
                    command.Parameters.AddWithValue("@Address",         txtAddress.Text);
                    command.Parameters.AddWithValue("@BirthDate",       txtBirthDate.Text);
                    command.Parameters.AddWithValue("@HireDate",        txtHireDate.Text);
                    command.Parameters.AddWithValue("@City",            txtCity.Text);
                    command.Parameters.AddWithValue("@Region",          txtRegion.Text);
                    command.Parameters.AddWithValue("@PostalCode",      txtPostalCode.Text);
                    command.Parameters.AddWithValue("@Country",         txtCountry.Text);
                    command.Parameters.AddWithValue("@HomePhone",       txtHomePhone.Text);
                    command.Parameters.AddWithValue("@Extension",       txtExtension.Text);
                    command.Parameters.AddWithValue("@Photo",           fupPhoto.FileName);
                    command.Parameters.AddWithValue("@Email",           txtEmail.Text);
                    command.Parameters.AddWithValue("@Admin",           "0");               //Normal user
                    command.Parameters.AddWithValue("@Password",        txtPassword.Text);
                    command.Parameters.AddWithValue("@Commission",      txtCommission.Text);

                    command.ExecuteNonQuery();

                }
                catch (Exception exc)
                {
                    //Do NOTHING for now?!
                }
            }//END OF: Using

            Response.Redirect(Request.Url.ToString(), false);
            
        }
    }
}