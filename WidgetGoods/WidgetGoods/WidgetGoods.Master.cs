using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public partial class WidgetGoods : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user;

            //Checks to see if a user has logged in to the website
            //This is done on the secure login page
            if (Session["user"] == null)
            {
                //If the user has not logged into the site, they are sent
                //Back to the login page
                Response.Redirect("~/secureLogin.aspx");
            }
            else
            {
                //If the user has logged in, determine if the user is an ADMIN and make
                //the proper link available to that user
                user = (User)Session["user"];

                //Disables links to the manager only portions of the website
                if (!user.isAdmin())
                {
                    lnkManageProducts.Visible = false;
                    lnkManageCategories.Visible = false;
                    lnkManageSuppliers.Visible = false;
                    lnkManageEmployees.Visible = false;
                    lnkSalesReports.Visible = false;
                }
            }
        }

        /*********************************************************************
         * 
         * The following redirects the user to different areas of the website
         * *******************************************************************/
        protected void lnkCustomerSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/customerSearch.aspx");
        }

        protected void lnkManageProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/manageProducts.aspx");
        }

        protected void lnkManageCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/manageCategories.aspx");
        }

        protected void lnkManageSuppliers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/manageSuppliers.aspx");
        }

        protected void lnkManageEmployees_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/manageEmployees.aspx");
        }

        protected void lnkSalesReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/salesReports.aspx");
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/secureLogin.aspx");
        }
    }
}