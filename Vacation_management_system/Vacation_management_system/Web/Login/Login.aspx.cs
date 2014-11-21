using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vacation_management_system.Web.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void butsignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/Dashboard/Dashboard.aspx");
        }
    }
}