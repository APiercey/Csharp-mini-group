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
        DataTable dataTable;
        SqlDataAdapter dataAdapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            if (!IsPostBack)
            {
                ddlSuppliers.Items.Add("-- Supplier List --");

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
                    }
                    catch (Exception Ex)
                    {
                        Response.Write("Exception occurred: " + Ex.Message);
                    }
                }
            }
        }

        protected void btnUpdateSupplier_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {

        }

    }
}