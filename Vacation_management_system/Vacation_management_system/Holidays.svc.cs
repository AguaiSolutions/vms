using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Vacation_management_system
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Holidays" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Holidays.svc or Holidays.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Holidays : IHolidays
    {
        public int InsertJson(string json)
        {
            int res = 0;

            //var data = json;

            //string connectionString =
            //    @"Initial Catalog=Aguai_Leave_Management;Data Source=RAGHAV-PC\SQLEXPRESS2012;Integrated Security=SSPI;";
            // for (int i = 0; i < data.Count; i++)
            
                //using (SqlConnection con = new SqlConnection(connectionString))
                //{
                //    con.Open();
                //    SqlCommand cmd = new SqlCommand("insert into holidays VALUES (@Name,@Day)", con);
                //    //cmd.Parameters.AddWithValue("@Name", data.Holidayname);
                //    //cmd.Parameters.AddWithValue("@Day", data.Hoilday);
                //    res += cmd.ExecuteNonQuery();
                //}

            if (json.Equals("Raghava"))
            {
                res = 1;

            }

            return res;
        }

        public string Test()
        {
            return "Hello..!";
        }
    }
}
