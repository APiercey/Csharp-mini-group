using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        }
    }
}