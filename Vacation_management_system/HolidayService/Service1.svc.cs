using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Caching;

namespace HolidayService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        //[WebInvoke(UriTemplate = "Service1/InsertJson", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        public int InsertJson(Jclass json)
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

            //if (json.Equals("Raghava"))
            //{
            //    res = 1;

            //}


            var name = json.Name;

            var date = json.Date;

            return res;
        }

        //[WebInvoke(Method = "POST", UriTemplate = "Service1/PostData", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public int PostData(string json)
        {
            if (json != "")
            {
                var obj = json;
            }
            return 1;
        }

        //[WebGet(UriTemplate = "Service1/GetData({id})")]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        //[WebInvoke(UriTemplate = "Service1/GetDataUsingDataContract", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
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

        //[WebGet(UriTemplate = "Service1/Name")]
        public string Name()
        {
            return "HolidayService";
        }
    }
}
