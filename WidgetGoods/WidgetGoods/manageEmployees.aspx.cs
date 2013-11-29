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
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null &&
                    Request.QueryString["action"] != null)
                {
                    if (Request.QueryString["action"].ToString() == "edit")
                    {
                        displayEditEmployee(Convert.ToInt32(Request.QueryString["id"]));
                    }
                }
            }
        }
        protected void displayEditEmployee(int employeeID)
        {
            btnAddEmployee.Visible = false;
            btnEditEmployee.Visible = true;
            pnlAddEmployee.Visible = true;
            pnlViewEmployees.Visible = false;
            litHeader.Text = "Edit Employee";

            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", db);
                    command.Parameters.Add("@EmployeeID", employeeID);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        txtLastName.Text = reader[1].ToString();
                        txtFirstName.Text = reader[2].ToString();
                        txtTitle.Text = reader[3].ToString();
                        txtTitleOfCourtesy.Text = reader[4].ToString();
                        txtBirthDate.Text = reader[5].ToString();
                        txtHireDate.Text = reader[6].ToString();
                        txtAddress.Text = reader[7].ToString();
                        txtCity.Text = reader[8].ToString();
                        txtRegion.Text = reader[9].ToString();
                        txtPostalCode.Text = reader[10].ToString();
                        txtCountry.Text = reader[11].ToString();
                        txtHomePhone.Text = reader[12].ToString();
                        txtExtension.Text = reader[13].ToString();
                        txtNotes.Text = reader[15].ToString();
                        txtReportsTo.Text = reader[16].ToString();
                        txtComm.Text = reader[18].ToString();
                        txtEmail.Text = reader[19].ToString();
                        txtPassword.Text = reader[20].ToString();
                    }
                    db.Close();
                }
                finally
                {

                }
            }
        }
        protected void btnShowAddEmployee_Click(object sender, EventArgs e)
        {
            pnlViewEmployees.Visible = false;
            pnlAddEmployee.Visible = true;
            btnAddEmployee.Visible = true;
            btnEditEmployee.Visible = false;
            litHeader.Text = "Add Employee";

            txtLastName.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtTitle.Text = String.Empty;
            txtTitleOfCourtesy.Text = String.Empty;
            txtBirthDate.Text = DateTime.Now.ToString();
            txtHireDate.Text = DateTime.Now.ToString();
            txtAddress.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtRegion.Text = String.Empty;
            txtPostalCode.Text = String.Empty;
            txtCountry.Text = String.Empty;
            txtHomePhone.Text = String.Empty;
            txtExtension.Text = String.Empty;
            txtNotes.Text = String.Empty;
            txtReportsTo.Text = String.Empty;
            txtComm.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        protected void btnShowEditEmployee_Click(object sender, EventArgs e)
        {
            pnlViewEmployees.Visible = true;
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
                                                                       @PostalCode, @Country,   @HomePhone, 
                                                                       @Extension,  @Photo,     @Email, 
                                                                       @Admin,      @Password,  @Commission)";

                    SqlCommand command = new SqlCommand(newEmployeeQuery, db);

                    int imgLength = fupPhoto.PostedFile.ContentLength;
                    byte[] byteImage = new byte[imgLength];

                    fupPhoto.PostedFile.InputStream.Read(byteImage, 0, imgLength);

                    command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    command.Parameters.AddWithValue("@Title", txtTitle.Text);
                    command.Parameters.AddWithValue("@TitleOfCourtesy", txtTitleOfCourtesy.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                    command.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime(txtBirthDate.Text));
                    command.Parameters.AddWithValue("@HireDate", Convert.ToDateTime(txtHireDate.Text));
                    command.Parameters.AddWithValue("@City", txtCity.Text);
                    command.Parameters.AddWithValue("@Region", txtRegion.Text);
                    command.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                    command.Parameters.AddWithValue("@Country", txtCountry.Text);
                    command.Parameters.AddWithValue("@HomePhone", txtHomePhone.Text);
                    command.Parameters.AddWithValue("@Extension", txtExtension.Text);
                    command.Parameters.AddWithValue("@Photo", byteImage);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Admin", "0");               //Normal user
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);
                    command.Parameters.AddWithValue("@Commission", double.Parse(txtComm.Text));

                    command.ExecuteNonQuery();

                }
                catch (Exception exc)
                {
                    //Do NOTHING for now?!
                }
            }//END OF: Using

            Response.Redirect(Request.Url.ToString(), false);

        }
        protected void btnEditEmployee_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    String newEmployeeQuery = @"UPDATE Employees SET LastName   = @LastName, FirstName   = @FirstName, Title           = @Title, 
                                                                     BirthDate  = @BirthDate,  HireDate  = @HireDate,  TitleOfCourtesy = @TitleOfCourtesy, 
                                                                     Address    = @Address,    City      = @City,      Region          = @Region, 
                                                                     PostalCode = @PostalCode, Country   = @Country,   HomePhone       = @HomePhone, 
                                                                     Extension  = @Extension,  Photo     = @Photo,     Email           = @Email, 
                                                                     Password   = @Password,  Commission = @Commission

                                                               WHERE EmployeeID = @EmployeeID";

                    SqlCommand command = new SqlCommand(newEmployeeQuery, db);

                    int imgLength = fupPhoto.PostedFile.ContentLength;
                    byte[] byteImage = new byte[imgLength];

                    fupPhoto.PostedFile.InputStream.Read(byteImage, 0, imgLength);

                    command.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(Request.QueryString["id"].ToString()));
                    command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    command.Parameters.AddWithValue("@Title", txtTitle.Text);
                    command.Parameters.AddWithValue("@TitleOfCourtesy", txtTitleOfCourtesy.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                    command.Parameters.AddWithValue("@BirthDate", txtBirthDate.Text);
                    command.Parameters.AddWithValue("@HireDate", txtHireDate.Text);
                    command.Parameters.AddWithValue("@City", txtCity.Text);
                    command.Parameters.AddWithValue("@Region", txtRegion.Text);
                    command.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                    command.Parameters.AddWithValue("@Country", txtCountry.Text);
                    command.Parameters.AddWithValue("@HomePhone", txtHomePhone.Text);
                    command.Parameters.AddWithValue("@Extension", txtExtension.Text);
                    command.Parameters.AddWithValue("@Photo", byteImage);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);
                    command.Parameters.AddWithValue("@Commission", double.Parse(txtComm.Text));

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