using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public partial class manageProducts : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        string sql = "SELECT ProductID, ProductName FROM Products ORDER BY ProductName";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        ddlProducts.DataSource = dataTable;
                        ddlProducts.DataTextField = "ProductName";
                        ddlProducts.DataValueField = "ProductID";
                        ddlProducts.DataBind();

                        //Adds a default value to the drop down list with a value of 0
                        //at the 0 index of the drop down list (the top of the list)
                        ddlProducts.Items.Insert(0, new ListItem("-- Products List --", "0"));
                    }
                    catch (Exception Ex)
                    {
                        Response.Write("Exception occurred: " + Ex.Message);
                    }

                    ddlCategoryID.Items.Add("-- Categories --");
                    ddlSupplierID.Items.Add("-- Suppliers --");
                }
            }
        }//end Page_Load

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check if the selected index is the default selection
            if (ddlProducts.SelectedIndex != 0)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        //creates a command and adds the ProductID from the drop down list
                        //to the parameters in the select statement
                        string sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
                        SqlCommand command = new SqlCommand(sql, con);
                        command.Parameters.AddWithValue("@ProductID", ddlProducts.SelectedValue);

                        DataTable productDataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(productDataTable);

                        //grabs all suppliers  to populate the dropdown list
                        sql = "SELECT SupplierID, CompanyName FROM Suppliers ORDER BY CompanyName";
                        adapter = new SqlDataAdapter(sql, con);
                        DataTable supplierDataTable = new DataTable();
                        adapter.Fill(supplierDataTable);

                        ddlSupplierID.DataSource = supplierDataTable;
                        ddlSupplierID.DataTextField = "CompanyName";
                        ddlSupplierID.DataValueField = "SupplierID";
                        ddlSupplierID.DataBind();

                        //grabs all categories to populate the dropdown list
                        sql = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
                        adapter = new SqlDataAdapter(sql, con);
                        DataTable categoryDataTable = new DataTable();
                        adapter.Fill(categoryDataTable);

                        ddlCategoryID.DataSource = categoryDataTable;
                        ddlCategoryID.DataTextField = "CategoryName";
                        ddlCategoryID.DataValueField = "CategoryID";
                        ddlCategoryID.DataBind();

                        //uses the DataTable results to populate the form fields with the results
                        lblProductID.Text = productDataTable.Rows[0]["ProductID"].ToString();
                        txtProductName.Text = productDataTable.Rows[0]["ProductName"].ToString();
                        txtQuantityPerUnit.Text = productDataTable.Rows[0]["QuantityPerUnit"].ToString();
                        txtUnitPrice.Text = productDataTable.Rows[0]["UnitPrice"].ToString();
                        txtUnitsInStock.Text = productDataTable.Rows[0]["UnitsInStock"].ToString();
                        txtUnitsOnOrder.Text = productDataTable.Rows[0]["UnitsOnOrder"].ToString();
                        txtReorderLevel.Text = productDataTable.Rows[0]["ReorderLevel"].ToString();

                        //gets the category and supplier of the currently selected item 
                        DataRow[] foundRow;
                        foundRow = categoryDataTable.Select("CategoryID + '' LIKE '" + productDataTable.Rows[0]["CategoryID"] + "'");
                        ddlCategoryID.SelectedValue = foundRow[0]["CategoryID"].ToString();

                        foundRow = supplierDataTable.Select("SupplierID + '' LIKE '" + productDataTable.Rows[0]["SupplierID"] + "'");
                        ddlSupplierID.SelectedValue = foundRow[0]["SupplierID"].ToString();

                        //is the product discontiuned?
                        if (productDataTable.Rows[0]["Discontinued"].ToString() == "True")
                        {
                            ckbDiscontinued.Checked = true;
                        }
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
                ddlProducts.SelectedIndex = 0;
                ddlCategoryID.SelectedIndex = 0;
                ddlSupplierID.SelectedIndex = 0;
                lblProductID.Text = "";
                txtProductName.Text = "";
                txtQuantityPerUnit.Text = ""; 
                txtUnitPrice.Text = ""; 
                txtUnitsInStock.Text = ""; 
                txtUnitsOnOrder.Text = ""; 
                txtReorderLevel.Text = "";
                ckbDiscontinued.Checked = false;
            }
        }//end ddlProducts_SelectedIndexChanged

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    //create an update command and add the parameter values
                    string sql = "UPDATE Products SET " +
                    "ProductName = @ProductName, " +
                    "SupplierID = @SupplierID, " +
                    "CategoryID = @CategoryID, " +
                    "QuantityPerUnit = @Quantity, " +
                    "UnitPrice = @Price, " +
                    "UnitsInStock = @Stock, " +
                    "UnitsOnOrder = @Order, " +
                    "ReorderLevel = @Level, " +
                    "Discontinued = @Checked " + 
                    "WHERE ProductID = @ProductID";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", ddlSupplierID.SelectedValue);
                    cmd.Parameters.AddWithValue("CategoryID", ddlCategoryID.SelectedValue);
                    cmd.Parameters.AddWithValue("Quantity", txtQuantityPerUnit.Text);
                    cmd.Parameters.AddWithValue("Price", txtUnitPrice.Text);
                    cmd.Parameters.AddWithValue("Stock", txtUnitsInStock.Text);
                    cmd.Parameters.AddWithValue("Order", txtUnitsOnOrder.Text);
                    cmd.Parameters.AddWithValue("Level", txtReorderLevel.Text);
                    cmd.Parameters.AddWithValue("Checked", ckbDiscontinued.Checked.ToString());
                    cmd.Parameters.AddWithValue("@ProductID", lblProductID.Text);

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
                //Response.Redirect(Request.Url.ToString(), false);
            }
        }//end btnUpdateProduct_Click

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {

        }//end btnAddProduct_Click


    }//end partial class manageProducts
}//end namespace WidgetGoods
