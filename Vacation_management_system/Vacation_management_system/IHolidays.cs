using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Vacation_management_system
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHolidays" in both code and config file together.
    [ServiceContract]
    public interface IHolidays
    {
        [OperationContract]
        int InsertJson(JClass json);

        [OperationContract]
        string Test();

    }

    [DataContract]
    public class JClass
    {
        public string hoilday { get; set; }

        public string holidayname { get; set; }
    }
}
