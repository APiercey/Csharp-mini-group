using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public partial class manageEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is a test!
        }

        protected void btnShowAddEmployee_Click(object sender, EventArgs e)
        {            
            pnlEditEmployee.Visible = false;
            pnlAddEmployee.Visible = true;
        }

        protected void btnShowEditEmployee_Click(object sender, EventArgs e)
        {
            pnlEditEmployee.Visible = true;
            pnlAddEmployee.Visible = false;
        }
    }
}