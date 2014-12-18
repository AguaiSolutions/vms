using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace Vacation_management_system
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           DataTable dt = (DataTable)Session["holiday"];
            DateTime now = DateTime.Now;
            DateTime Fromdate;
            var xxsd = DateTime.TryParseExact("15/08/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out Fromdate);

            var thisYearRows = dt.AsEnumerable().Where(r => r.Field<DateTime>("holiday_date") <= now && r.Field<DateTime>("holiday_date")>=Fromdate);
            if (thisYearRows.Any())
            {
                var result = thisYearRows.ElementAt(1);
                var rs = result.ItemArray[1];
                DataView gd1 = thisYearRows.AsDataView();
                gd.DataSource = gd1;
                gd.DataBind();
               
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}