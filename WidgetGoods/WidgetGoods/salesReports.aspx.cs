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
    public partial class salesReports : System.Web.UI.Page
    {
        DataTable dataTableCategory = new DataTable();
        SqlDataAdapter adapter;
        Decimal totalSales;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cldStartDate.TodaysDate = DateTime.Now.AddYears(-16);
                cldEndDate.TodaysDate = DateTime.Now.AddYears(-15);

                using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
                {
                    try
                    {
                        adapter = new SqlDataAdapter("SELECT EmployeeID, FirstName, LastName FROM Employees ORDER BY FirstName", db);
                        adapter.Fill(dataTableCategory);

                        dataTableCategory.Columns.Add("FullName", typeof(string), "FirstName + ' ' + LastName");
                        ddlEmployeeList.DataSource = dataTableCategory;
                        ddlEmployeeList.DataTextField = "FullName";
                        ddlEmployeeList.DataValueField = "EmployeeID";
                        ddlEmployeeList.DataBind();

                        ddlEmployeeList.Items.Insert(0, new ListItem("-- Employee List --", "0"));
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalSales += Decimal.Parse(e.Row.Cells[5].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Decimal commission;

                using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
                {
                    try
                    {
                        db.Open();

                        //Creates an update command and add the parameter values to the command
                        SqlCommand command = new SqlCommand("SELECT Commission FROM Employees WHERE EmployeeID=@EmployeeID", db);
                        command.Parameters.AddWithValue("@EmployeeID", ddlEmployeeList.SelectedValue);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                commission = (Decimal)reader[0];
                                totalSales = totalSales * (commission / 100);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                e.Row.Cells[4].Text = "Total Commision: ";
                e.Row.Cells[5].Text = (totalSales).ToString();
            }
        }
    }
}