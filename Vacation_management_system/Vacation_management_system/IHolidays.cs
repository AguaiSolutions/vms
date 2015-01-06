using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Vacation_management_system
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHolidays" in both code and config file together.
    [ServiceContract]
    public interface IHolidays
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        int InsertJson(string json);

        [OperationContract]
        string Test();

    }

    [DataContract]
    public class JClass
    {
        private string holiday = string.Empty;

        private string holidayName = string.Empty;

        [DataMember]
        public string Hoilday { get; set; }

        [DataMember]
        public string Holidayname { get; set; }
    }
}
