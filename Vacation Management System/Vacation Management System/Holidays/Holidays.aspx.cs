using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Aguai_Leave_Management_System
{
    public partial class Holidays : System.Web.UI.Page
    {
        
        Database ds = new Database();
        SqlDataReader rd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}