using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace HolidayService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        //[WebInvoke(UriTemplate = "IService1/InsertJson", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        int InsertJson(Jclass json);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "IService1/PostData", BodyStyle = WebMessageBodyStyle.WrappedRequest,ResponseFormat = WebMessageFormat.Json)]
        int PostData(string json);

        [OperationContract]
        //[WebGet(UriTemplate = "IService1/GetData({id})")]
        string GetData(int value);

        [OperationContract]
        //[WebInvoke(UriTemplate = "IService1/GetDataUsingDataContract", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        //[WebGet(UriTemplate = "IService1/Name")]
        string Name();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)] 
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    public class Jclass
    {
        public string Name { get; set; }

        public string Date { get; set; }
    }
}
