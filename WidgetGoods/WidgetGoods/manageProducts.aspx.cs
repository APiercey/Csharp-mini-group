using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public partial class manageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Add("-- Product List --");
                ddlCategoryID.Items.Add("-- Categories --");
                ddlSupplierID.Items.Add("-- Suppliers --");
                //test
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {

        }
    }
}