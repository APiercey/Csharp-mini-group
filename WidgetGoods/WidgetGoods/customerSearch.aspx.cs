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
    public partial class customerSearch : System.Web.UI.Page
    {
        Customer customer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null &&
                    Request.QueryString["action"] != null)
                {
                    deleteCustomerAndCascade(Request.QueryString["id"].ToString());
                }
            }
            
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE CustomerID = @CustomerID", db);
                    command.Parameters.AddWithValue("@CustomerID", GridView2.DataKeys[GridView2.SelectedIndex].Value.ToString());

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customer = new Customer(reader);
                            Session["customer"] = customer;

                            Response.Redirect("~/customerProfile.aspx");
                        }
                    }

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        protected void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Customers VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax, @Email)", db);
                    command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    command.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                    command.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                    command.Parameters.AddWithValue("@ContactTitle", txtContactTitle.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                    command.Parameters.AddWithValue("@City", txtCity.Text);
                    command.Parameters.AddWithValue("@Region", txtRegion.Text);
                    command.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                    command.Parameters.AddWithValue("@Country", txtCountry.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Fax", txtFax.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);

                    command.ExecuteNonQuery();

                    SqlCommand commandSelect = new SqlCommand("SELECT * FROM Customers WHERE CustomerID = @CustomerID", db);
                    commandSelect.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);

                    SqlDataReader reader = commandSelect.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customer = new Customer(reader);
                            Session["customer"] = customer;

                            Response.Redirect("~/customerProfile.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        protected void btnShowCustomerSearch_Click(object sender, EventArgs e)
        {
            pnlCustomerSearch.Visible = true;
            pnlAddNewCustomer.Visible = false;
        }

        protected void btnShowAddCustomer_Click(object sender, EventArgs e)
        {
            pnlCustomerSearch.Visible = false;
            pnlAddNewCustomer.Visible = true;
        }
        protected void deleteCustomerAndCascade(String customerID)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    String query = "SELECT OrderID FROM Orders WHERE CustomerID = @customerID";
                    SqlCommand command = new SqlCommand(query, db);
                    command.Parameters.AddWithValue("@customerID", customerID);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        String deleteQuery = "DELETE FROM [Order Details] WHERE OrderID = @orderID";

                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, db);
                        deleteCommand.Parameters.AddWithValue("@orderID", reader[0]);

                        deleteCommand.ExecuteNonQuery();
                    }

                    command = new SqlCommand("DELETE FROM Orders WHERE CustomerID = @customerID", db);
                    command.Parameters.AddWithValue("@customerID", customerID);

                    command.ExecuteNonQuery();

                    command = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @customerID", db);
                    command.Parameters.AddWithValue("@customerID", customerID);

                    command.ExecuteNonQuery();




                }
                catch(Exception exc)
                {

                }
                finally
                {

                }
            }
        }
    }
}