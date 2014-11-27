using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  System.Data;
using  System.Data.SqlClient;
using  Aguai_Leave_Management_System;


namespace Vacation_management_system.Master
{
    public partial class VMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsername.Text = Session["UserName"].ToString(); 
                getMenu();
            }
        }

        private void getMenu()
        {

            StringBuilder menulist = new StringBuilder();
            Database ob = new Database();
            string query = "select menu_name, menu.id as menuID ,url, parent_id, icon, Friendly_name from  user_roles inner join roles_access  on user_roles.id=" + Session["role_ID"] + " and role_id=" + Session["role_ID"] + " left join menu  on menu_id=menu.id order by order_id";
            SqlDataReader data;
            ob.RunQuery(out data, query);
            DataTable dt = new DataTable();
            dt.Load(data);
            int k = 1;
            string current_url = Request.Url.AbsolutePath.Split('/').LastOrDefault();
            //Left side Menu..
            menulist.Append("<ul class=\"nav navbar-nav side-nav\">");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string exp = "parent_id=" + dt.Rows[i]["menuID"] + "";
                DataRow[] foundRows = dt.Select(exp);

                if (foundRows.Length != 0)
                {
                    menulist.Append("<li><a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#demo" + k + "\"  runat=\"Server\"><i class=" + dt.Rows[i]["icon"] + "></i>     " + dt.Rows[i]["menu_name"] + " <i class=\"fa fa-fw fa-caret-down\"></i> </a>");
                    menulist.Append("<ul id=\"demo" + k + "\" class=\"collapse\">");
                    i++;
                    int j;
                    for (j = i; j < (foundRows.Length) + i; j++)
                    {
                        if (((dt.Rows[j]["Friendly_name"].Equals(current_url))))
                        {
                            menulist.Append("<li class=\"active\">");
                        }
                        else
                            menulist.Append("<li>");
                        menulist.Append("<a href=\"" + VirtualPathUtility.ToAbsolute(dt.Rows[j]["url"].ToString()) + "\"  runat=\"Server\"><i class=" + dt.Rows[j]["icon"] + "></i>     " + dt.Rows[j]["menu_name"] + "</a>");
                        menulist.Append("</li>");
                    }
                    k++;
                    i = j - 1;
                    menulist.Append("</ul>");
                }
                else
                {
                    if (((dt.Rows[i]["Friendly_name"].Equals(current_url))))
                    {
                        menulist.Append(" <li class=\"active\">");
                    }
                    else
                        menulist.Append("<li>");

                    menulist.Append("<a href=\"" + VirtualPathUtility.ToAbsolute(dt.Rows[i]["url"].ToString()) + "\"  runat=\"Server\"><i class=" + dt.Rows[i]["icon"] + "></i>     " + dt.Rows[i]["menu_name"] + "</a>");
                }
                menulist.Append("</li>");

            }
            menulist.Append("</ul >");
            menu1.InnerHtml = menulist.ToString();
        }


    }
}


