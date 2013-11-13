using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public partial class manageSuppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlSuppliers.Items.Add("-- Supplier List --");
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