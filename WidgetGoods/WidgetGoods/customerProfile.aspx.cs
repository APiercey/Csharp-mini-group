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
    public partial class customerProfile : System.Web.UI.Page
    {
        Customer customer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("~/customerSearch.aspx");
            }
            else
            {
                customer = (Customer)Session["customer"];
            }

            if (!IsPostBack)
            {
                txtCompanyName.Text = customer.getPropertyValue("CompanyName");
                txtContactName.Text = customer.getPropertyValue("ContactName");
                txtContactTitle.Text = customer.getPropertyValue("ContactTitle");
                txtEmail.Text = customer.getPropertyValue("Email");
                txtCity.Text = customer.getPropertyValue("City");
                txtPhone.Text = customer.getPropertyValue("Phone");
                txtFax.Text = customer.getPropertyValue("Fax");
            }
        }

        protected void btnEditCustomer_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    //Creates an update command and add the parameter values to the command
                    SqlCommand command = new SqlCommand("UPDATE Customers SET CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, Email=@Email, City=@City, Phone=@Phone, Fax=@Fax " +
                        "WHERE CustomerID=@CustomerID", db);
                    command.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                    command.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                    command.Parameters.AddWithValue("@ContactTitle", txtContactTitle.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@City", txtCity.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Fax", txtFax.Text);
                    command.Parameters.AddWithValue("@CustomerID", customer.getPropertyValue("CustomerID"));

                    //Updates all of the product details in the database
                    command.ExecuteNonQuery();

                    SqlCommand commandSelect = new SqlCommand("SELECT * FROM Customers WHERE CustomerID = @CustomerID", db);
                    commandSelect.Parameters.AddWithValue("@CustomerID", customer.getPropertyValue("CustomerID"));

                    SqlDataReader reader = commandSelect.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customer = new Customer(reader);
                            Session["customer"] = customer;

                            Response.Redirect(Request.Url.ToString(), false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        protected void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/addOrder.aspx");
        }
    }
}