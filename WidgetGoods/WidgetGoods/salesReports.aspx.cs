using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Web.UI.WebControls;
// the logic of calculating Commission and Total sold tested and verified 
// needs some color adjustment
namespace WidgetGoods
{
    public partial class salesReports : System.Web.UI.Page
    {
        decimal totalSold = 0M;
        decimal commissionRate = 0M;
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
                using (SqlConnection db = new SqlConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
                {
                    try
                    {
                        db.Open();
                        //retreive commission rate from employee-T
                        SqlCommand cmd = new SqlCommand("SELECT Commission FROM Employees WHERE EmployeeID=@EmployeeID", db);
                        cmd.Parameters.AddWithValue("@EmployeeID", ddlEmployeeList.SelectedValue);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                commissionRate = (Decimal)reader[0];
                            }
                        }
                    }
                    catch (Exception err)
                    {
                    }
                }
                Label lblTotalSold = (Label)e.Row.FindControl("lblTotalSold");
                Label lblTotalCommission = (Label)e.Row.FindControl("lblTotalCommission");
                lblTotalSold.Text = totalSold.ToString("C");
                lblTotalCommission.Text = (totalSold * commissionRate).ToString("C");
            }
            
        }
        

     }
}