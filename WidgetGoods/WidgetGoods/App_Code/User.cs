using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WidgetGoods
{
    public class User
    {
        private Hashtable userProperties;

        public User(SqlDataReader reader)
        {
            userProperties = new Hashtable();

            //Uses the provided SqlDataReader to loop through and add
            //a property for every SQL entity element as a Key -> Value pair
            //Key = Element Name (EmployeeID)
            //Value = Element Value (1)
            for (int i = 0; i < reader.FieldCount; i++)
            {
                userProperties[reader.GetName(i)] = reader[i];
            }
        }

        //Returns true or false depending on security level of an Employee
        public bool isAdmin()
        {
            if (userProperties["Admin"].ToString() == "1")
            {
                return true;
            }

            return false;
        }
        public string getPropertyValue(string propertyName)
        {
            //Returns the value of any given Entity element
            return userProperties[propertyName].ToString();
        }
    }
}