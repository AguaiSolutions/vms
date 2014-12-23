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
                if (Session["UserName"] != null)
                {
                    lblUsername.Text = Session["UserName"].ToString();
                }
                else
                    Response.Redirect("~/Web/Login/Login.aspx");
               
                    getMenu();
                    AlertsMessages();
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
                            var msg = "<script language='javascript'> $(\"#demo" + k + "\").removeClass(\"collapse\");</script>"; 
                           Page. ClientScript.RegisterStartupScript(Page.GetType(), "validation", msg);
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


        protected void Logout(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/Web/Login/Login.aspx");
        }

        protected void AlertsMessages()
        {

            List<string> Name = new List<string>();
            List<string> image = new List<string>();
            List<string> date = new List<string>(); 
           
            Database ob = new Database();
            string query = "select  (first_name+' ' +last_name) as name, (DATENAME(month, date_of_birth)+' '+DATENAME(DAY, date_of_birth)) as dob, image from employee join employee_additional on  employee.id= employee_additional.emp_id  where day(date_of_birth)=DAY(GETDATE()) and MONTH(date_of_birth)=MONTH(GETDATE())";
            SqlDataReader data;
            ob.RunQuery(out data, query);
            while(data.Read())
            {
                Name.Add(data["name"].ToString());
                date.Add (data["dob"].ToString());
                image.Add(data["image"].ToString());
              
            }
            data.Close();
            ob.Close();
            StringBuilder menulist = new StringBuilder();

            menulist.Append("<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\"><i class=\"fa fa-bell\"></i><span class=\"badge\" id=\"count\">" + Name.Count + "</span></a>");
            menulist.Append("<ul class=\"dropdown-menu alert-dropdown arrow_box\" >");
            menulist.Append("<li class=\"text-center\" style=\"color:blue\">");
            menulist.Append(" Notifications <br /></li>");
            menulist.Append("<li class=\"divider\"></li>");
            if (Name.Count != 0)
            {
                for (int j = 0; j < Name.Count; j++)
                {
                    menulist.Append("<li >");
                    menulist.Append(" <img src =\"../Images/" + image[j] + "\" id=\"alertbdayimage\" width=\"55\" height=\"45\"/>");
                    menulist.Append(" <div id=\"alertbirthday\"> " + Name[j] + "<br/> birthday Today.<//div>");

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "hide", "counthide();", true);
                menulist.Append("<li style=\"margin-left: 30px;\" >");
              
                menulist.Append("  No birthdays Today.");

            }



            menulist.Append("<li class=\"divider\"></li>");
            menulist.Append("<li class=\"text-center\" style=\"color:blue\">");
            menulist.Append("<a href=\"#\">View All</a> </li> </ul>");
            alerts.InnerHtml = menulist.ToString(); 
        }

    }
}


