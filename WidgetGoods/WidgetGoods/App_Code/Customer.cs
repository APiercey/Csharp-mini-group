using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WidgetGoods
{
    public class Customer
    {
        Hashtable customerProperties;

        public Customer(SqlDataReader reader)
        {
            customerProperties = new Hashtable();

            //Uses the provided SqlDataReader to loop through and add
            //a property for every SQL entity element as a Key -> Value pair
            //Key = Element Name (EmployeeID)
            //Value = Element Value (1)
            for (int i = 0; i < reader.FieldCount; i++)
            {
                customerProperties[reader.GetName(i)] = reader[i];
            }
        }
        public string getPropertyValue(string propertyName)
        {
            //Returns the value of any given Entity element
            return customerProperties[propertyName].ToString();
        }
    }
}