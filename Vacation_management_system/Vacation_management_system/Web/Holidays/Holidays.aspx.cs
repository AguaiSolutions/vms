using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vacation_management_system;
using Vacation_management_system.HolidayService;
using Vacation_management_system.ServiceReference1;

namespace Vacation_management_system.Web.Holidays
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public partial class Holidays : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        [ScriptMethod]
        public static int GetData(Product json)
        {
            return 1;
        }

        protected void btnSave1_OnClick(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "myScript", "GetValues();", true);

            //System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            //string line = "";
            //line = sr.ReadToEnd();

            JClass line = new JClass();

            line.holidayname = "New Year";

            line.hoilday = "2014-01-01";
           
            //int rest = client.InsertJson((Jclass)line);

            int res = client.InsertJson(line);
        }

        protected void btnCancel1_OnClick(object sender, EventArgs e)
        {
            //HolidayService.Service1Client hClient = new HolidayService.Service1Client();

            //Jclass line = new Jclass();

            //line.Name = "New Year";

            //line.Date = "2014-01-01";

            //int res = hClient.InsertJson(line);
        }
    }

    public class Product
    {
        public string Name { get; set; }

        public string ExpiryDate { get; set; }
    }
}