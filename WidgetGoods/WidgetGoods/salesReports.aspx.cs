using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Web.UI.WebControls;
// Hossein looked at the code. In process of modify the table to show total sales properly
namespace WidgetGoods
{
    public partial class salesReports : System.Web.UI.Page
    {
        decimal totalSold = 0M;
        decimal commissionRate = 0.10M;
        DataTable dataTableCategory = new DataTable();
        SqlDataAdapter adapter;

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
        protected void GridView1_RowDataBound(object Sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblOrderTotal = (Label)e.Row.FindControl("lblOrderTotal");
                decimal orderTotal = Decimal.Parse(lblOrderTotal.Text);
                totalSold += orderTotal;

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalSold = (Label)e.Row.FindControl("lblTotalSold");
                Label lblTotalCommission = (Label)e.Row.FindControl("lblTotalCommission");
                lblTotalSold.Text = totalSold.ToString("C");
                lblTotalCommission.Text = (totalSold * commissionRate).ToString("C");
            }
            
        }
        

     }
}