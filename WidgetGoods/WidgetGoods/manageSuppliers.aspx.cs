using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public partial class manageSuppliers : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using(SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        string sql = "SELECT SupplierID, CompanyName FROM Suppliers ORDER BY CompanyName";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ddlSuppliers.DataSource = dataTable;
                        ddlSuppliers.DataTextField = "CompanyName";
                        ddlSuppliers.DataValueField = "SupplierID";
                        ddlSuppliers.DataBind();

                        //Adds a default value to the drop down list with a value of 0
                        //at the 0 index of the drop down list (the top of the list)
                        ddlSuppliers.Items.Insert(0, new ListItem("-- Supplier List --", "0"));
                    }
                    catch (Exception Ex)
                    {
                        Response.Write("Exception occurred: " + Ex.Message);
                    }
                }
            }
        }

        protected void ddlSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check if the selected index is the default selection
            if (ddlSuppliers.SelectedIndex != 0)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        //creates a command and adds the SupplierID from the drop down list
                        //to the parameters in the select statement
                        string sql = "SELECT * FROM Suppliers WHERE SupplierID = @SupplierID";
                        SqlCommand command = new SqlCommand(sql, con);
                        command.Parameters.AddWithValue("@SupplierID", ddlSuppliers.SelectedValue);

                        DataTable supplierDataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(supplierDataTable);

                        //uses the DataTable results to populate the form fields with the results
                        lblSupplierID.Text = supplierDataTable.Rows[0]["SupplierID"].ToString();
                        txtCompanyName.Text = supplierDataTable.Rows[0]["CompanyName"].ToString();
                        txtContactName.Text = supplierDataTable.Rows[0]["ContactName"].ToString();
                        txtContactTitle.Text = supplierDataTable.Rows[0]["ContactTitle"].ToString();
                        txtAddress.Text = supplierDataTable.Rows[0]["Address"].ToString();
                        txtCity.Text = supplierDataTable.Rows[0]["City"].ToString();
                        txtRegion.Text = supplierDataTable.Rows[0]["Region"].ToString();
                        txtPostalCode.Text = supplierDataTable.Rows[0]["PostalCode"].ToString();
                        txtCountry.Text = supplierDataTable.Rows[0]["Country"].ToString();
                        txtPhone.Text = supplierDataTable.Rows[0]["Phone"].ToString();
                        txtFax.Text = supplierDataTable.Rows[0]["Fax"].ToString();
                        txtHomePage.Text = supplierDataTable.Rows[0]["HomePage"].ToString();
                    }
                    catch (Exception Ex)
                    {
                        Response.Write("System error: " + Ex.Message);
                    }
                }
            }
            else
            {
                //resets the form value
                ddlSuppliers.SelectedIndex = 0;

                lblSupplierID.Text = "";
                txtCompanyName.Text = "";
                txtContactName.Text = "";
            }
        }

        protected void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    //create an update command and add the parameter values
                    string sql = "UPDATE Suppliers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @PhoneNumber, Fax = @FaxNumber, HomePage = @HomePage  WHERE SupplierID = @SupplierID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                    cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                    cmd.Parameters.AddWithValue("@ContactTitle", txtContactTitle.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@FaxNumber", txtFax.Text);
                    cmd.Parameters.AddWithValue("@HomePage", txtHomePage.Text);
                    
                    cmd.Parameters.AddWithValue("@SupplierID", lblSupplierID.Text);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    Response.Write("System error: " + Ex.Message);
                }
                finally
                {
                    con.Close();
                }

                //Redirects back to current page to refresh the list of categories
                Response.Redirect(Request.Url.ToString(), false);
            }
        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    
                    //create an update command and add the parameter values
                    string sql = "INSERT INTO Suppliers VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @PhoneNumber, @FaxNumber, @HomePage)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                    cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                    cmd.Parameters.AddWithValue("@ContactTitle", txtContactTitle.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@FaxNumber", txtFax.Text);
                    cmd.Parameters.AddWithValue("@HomePage", txtHomePage.Text);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    Response.Write("System error: " + Ex.Message);
                }
                finally
                {
                    con.Close();
                }

                //Redirects back to current page to refresh the list of categories
                Response.Redirect(Request.Url.ToString(), false);
            }
        }
    }
}