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
    public partial class addOrder : System.Web.UI.Page
    {
        Customer customer;
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("~/customerSearch.aspx");
            }
            else
            {
                customer = (Customer)Session["customer"];
                user = (User)Session["user"];
            }

            if (!IsPostBack)
            {
                for (int i = 0; i < 100; i++)
                {
                    string quantity = (i + 1).ToString();
                    ddlQuantity.Items.Add(new ListItem(quantity, quantity));
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlProductSearch.Visible = false;
            pnlAddOrder.Visible = true;

            lblCustomerName.Text = customer.getPropertyValue("CompanyName");
            ddlEmployeeName.SelectedValue = user.getPropertyValue("EmployeeID");

            //These should come after the other items are added to the drop down list
            ddlEmployeeName.Items.Insert(0, new ListItem("-- Employee List --", "0"));
            ddlShippingCompany.Items.Insert(0, new ListItem("-- Shipping List --", "0"));

        }

        protected void btnShowSearchProducts_Click(object sender, EventArgs e)
        {
            pnlProductSearch.Visible = true;
            pnlAddOrder.Visible = false;
        }

        protected void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try 
                {
                    db.Open();
                    String query = @"INSERT INTO Orders (CustomerID,   EmployeeID,  OrderDate, 
                                                         RequiredDate, ShipVia,
                                                         Freight,      ShipName,    ShipAddress, 
                                                         ShipCity,     ShipRegion,  ShipPostalCode, 
                                                         ShipCountry)

                                                 VALUES (@CustomerID,   @EmployeeID,  @OrderDate, 
                                                         @RequiredDate, @ShipVia,
                                                         @Freight,      @ShipName,    @ShipAddress, 
                                                         @ShipCity,     @ShipRegion,  @ShipPostalCode, 
                                                         @ShipCountry)";

                    SqlCommand command = new SqlCommand(query,db);

                    command.Parameters.AddWithValue("@EmployeeID", Convert.ToInt32(ddlEmployeeName.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@CustomerID", customer.getPropertyValue("CustomerID").ToString());
                    command.Parameters.AddWithValue("@OrderDate", cldOrderDate.SelectedDate.ToString());
                    command.Parameters.AddWithValue("@RequiredDate", cldRequiredDate.SelectedDate.ToString());
                    command.Parameters.AddWithValue("@ShipVia", Convert.ToInt32(ddlShippingCompany.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Freight", decimal.Parse(txtFreight.Text));
                    command.Parameters.AddWithValue("@ShipName", txtShipName.Text);
                    command.Parameters.AddWithValue("@ShipAddress", txtShipAddress.Text);
                    command.Parameters.AddWithValue("@ShipCity", txtShipCity.Text);
                    command.Parameters.AddWithValue("@ShipRegion", txtShipRegion.Text);
                    command.Parameters.AddWithValue("@ShipPostalCode", txtShipPostalCode.Text);
                    command.Parameters.AddWithValue("@ShipCountry", txtShipCountry.Text);

                    for(int i = 0; i < Convert.ToInt32(ddlQuantity.SelectedValue.ToString()); i++)
                    {
                        command.ExecuteNonQuery();
                    }


                }
                catch (Exception exc) 
                {
                    lblCustomerName.Text = exc.Message;
                }
                finally 
                {
                    db.Close();
                }
            }
        }
    }
}