using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public partial class manageCategories : System.Web.UI.Page
    {
        DataTable dataTableCategory = new DataTable();
        SqlDataAdapter adapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
                {
                    try
                    {
                       //Selects the CategoryID and Category Name of all categories in the database
                        adapter = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName", db);
                        //Fills the DataTable using the SqlDataAdapter
                        adapter.Fill(dataTableCategory);

                        //Assigns the DataTable as a DataSource for the Categories drop down list
                        //The visible text will be the categorName
                        //The SelectedValue will be the categoryID
                        ddlCategories.DataSource = dataTableCategory;
                        ddlCategories.DataTextField = "CategoryName";
                        ddlCategories.DataValueField = "CategoryID";
                        ddlCategories.DataBind();

                        //Adds a default value to the drop down list with a value of 0
                        //at the 0 index of the drop down list (the top of the list)
                        ddlCategories.Items.Insert(0, new ListItem("-- Category List --", "0"));
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Checks to see if selected value is not the default value
            //If it is, it clears the form fields.
            if (ddlCategories.SelectedIndex != 0)
            {
                using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
                {
                    try
                    {
                        //Creates a command and adds the CategoryID from the drop down list
                        //to the parameters in the select statement 
                        SqlCommand command = new SqlCommand("SELECT * FROM Categories WHERE CategoryID = @CategoryID", db);
                        command.Parameters.AddWithValue("@CategoryID", ddlCategories.SelectedValue);

                        adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTableCategory);

                        //Uses the DataTable results to populate the form fields with the results
                        //Of the select statement
                        lblCategoryID.Text = dataTableCategory.Rows[0]["CategoryID"].ToString();
                        txtCategoryName.Text = dataTableCategory.Rows[0]["CategoryName"].ToString();
                        txtDescription.Text = dataTableCategory.Rows[0]["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            else
            {
                //Resets all of the values of the form to the defaults
                ddlCategories.SelectedIndex = 0;

                lblCategoryID.Text = "";
                txtCategoryName.Text = "";
                txtDescription.Text = "";
            }
        }

        protected void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    //Creates an update command and add the parameter values to the command
                    SqlCommand command = new SqlCommand("UPDATE Categories SET CategoryName = @CategoryName, Description = @Description, Picture = @Picture " +
                        "WHERE CategoryID = @CategoryID", db);
                    command.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@Picture", fupPicture.FileBytes);
                    command.Parameters.AddWithValue("@CategoryID", lblCategoryID.Text);

                    //Updates all of the product details in the database
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    lblCategoryID.Text = ex.ToString();
                }

                //Redirects back to current page to refresh the list of categories
                //in the drop down list
                Response.Redirect(Request.Url.ToString(), false);
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                try
                {
                    db.Open();

                    //Creates an insert command and adds the parameters to the statement
                    SqlCommand command = new SqlCommand("INSERT INTO Categories (CategoryName, Description, Picture) VALUES (@CategoryName, @Description, @Picture)", db);

                    command.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@Picture", fupPicture.FileBytes);

                    //Executes the command, inserting the new category into the database
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    lblCategoryID.Text = ex.ToString();
                }

                //Redirects back to current page to refresh the list of categories
                //in the drop down list
                Response.Redirect(Request.Url.ToString(), false);
            }
        }
    }
}