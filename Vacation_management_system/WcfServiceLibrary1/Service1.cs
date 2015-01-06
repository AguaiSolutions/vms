using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int InsertData(string holidayName, string holiday)
        {
            int res;
            string connectionString =
                @"Initial Catalog=Aguai_Leave_Management;Data Source=RAGHAV-PC\SQLEXPRESS2012;Integrated Security=SSPI;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into holidays VALUES (@Name,@Day)", con);
                cmd.Parameters.AddWithValue("@Name",holidayName);
                cmd.Parameters.AddWithValue("@Day", holiday);
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }

        
        public int InsertJson(JClass json)
        {
            var res = 0;

            string connectionString =
                @"Initial Catalog=Aguai_Leave_Management;Data Source=RAGHAV-PC\SQLEXPRESS2012;Integrated Security=SSPI;";
           // for (int i = 0; i < data.Count; i++)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into holidays VALUES (@Name,@Day)", con);
                    cmd.Parameters.AddWithValue("@Name", json.holidayname);
                    cmd.Parameters.AddWithValue("@Day", json.hoilday);
                    res= cmd.ExecuteNonQuery();
                }
            }
            return res;
        }
    }
}
