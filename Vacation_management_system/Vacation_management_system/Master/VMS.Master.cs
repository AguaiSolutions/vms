using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Aguai_Leave_Management_System;



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
                    AlertsMessages();
                    GetMenu();

                }
                else
                    Response.Redirect("~/Login.aspx");

            }

        }
        private void GetMenu()
        {

            StringBuilder menulist = new StringBuilder();
            Database ob = new Database();
            string current_url = Request.Url.AbsolutePath;
            try
            {
                if (Session["menuslist"] == null)
                {
                    string query = "select menu_name, menu.id as menuID ,url, parent_id, icon, Friendly_name from  user_roles inner join roles_access  on user_roles.id=" + Session["role_ID"] + " and role_id=" + Session["role_ID"] + " left join menu  on menu_id=menu.id order by order_id";
                    SqlDataReader data;
                    ob.RunQuery(out data, query);
                    DataTable menus = new DataTable();
                    menus.Load(data);
                    Session["menuslist"] = menus;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Login.aspx");
            }
            int k = 1;
            DataTable dt = new DataTable();
            dt = (DataTable)Session["menuslist"];

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
                        if (current_url.Contains(dt.Rows[j]["Friendly_name"].ToString()))
                        {
                            menulist.Append("<li class=\"active\">");
                            var msg = "<script language='javascript'> $(\"#demo" + k + "\").removeClass(\"collapse\");</script>";
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "validationvms", msg);
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
                    if (current_url.Contains(dt.Rows[i]["Friendly_name"].ToString()))
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

            bool res = CheckPageAccess(current_url, (DataTable)Session["menuslist"]);
            if (!res)
            {
                Response.Redirect("~/Web/Dashboard/Dashboard.aspx");
            }


        }




        protected void Logout(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void AlertsMessages()
        {
            try
            {
                if (Session["name"] == null)
                {
                    List<string> Employee_Name = new List<string>();
                    List<string> employee_id = new List<string>();

                    Database ob = new Database();
                    string query = "select (first_name+' ' +last_name) as name, (DATENAME(month, date_of_birth)+' '+DATENAME(DAY, date_of_birth)) as dob, image_url from employee join employee_additional on  employee.id= employee_additional.emp_id  where day(date_of_birth)=DAY(GETDATE()) and MONTH(date_of_birth)=MONTH(GETDATE()) and employee.id!=" + Session["userId"];
                    SqlDataReader data;
                    ob.RunQuery(out data, query);
                    while (data.Read())
                    {
                        Employee_Name.Add(data["name"].ToString());
                        // date.Add (data["dob"].ToString());
                        employee_id.Add(data["image_url"].ToString());

                    }
                    Session["name"] = Employee_Name;
                    Session["employee_id"] = employee_id;
                    data.Close();
                    ob.Close();
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Login.aspx");
            }

            List<string> Name = new List<string>();
            List<string> emp_id = new List<string>();
            Name = (List<string>)Session["name"];
            emp_id = (List<string>)Session["employee_id"];

            if (Name.Count != 0)
            {
                StringBuilder menulist = new StringBuilder();
                menulist.Append("<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\"><i class=\"fa fa-bell\"></i><span class=\"badge\" id=\"count\">" + Name.Count + "</span></a>");
                menulist.Append("<ul class=\"dropdown-menu alert-dropdown arrow_box\" >");
                menulist.Append("<li class=\"text-center\" style=\"color:blue\">");
                menulist.Append(" Notifications <br /></li>");
                menulist.Append("<li class=\"divider\"></li>");
                for (int j = 0; j < Name.Count; j++)
                {
                    menulist.Append("<li >");
                    menulist.Append(" <img src =" + emp_id[j] + " id=\"alertbdayimage\" width=\"55\" height=\"45\"/>");
                    menulist.Append(" <div id=\"alertbirthday\"> " + Name[j] + "<br/> birthday Today.<//div>");
                }

                menulist.Append("<li class=\"divider\"></li>");
                menulist.Append("<li class=\"text-center\" style=\"color:blue\">");
                menulist.Append("<a href=\"/Web/Dashboard/Birthdaylist.aspx\" runat=\"server\">View All</a> </li> </ul>");
                alerts.InnerHtml = menulist.ToString();
            }
        }

        private bool CheckPageAccess(string url, DataTable dt)
        {
            int i;
            bool flag = false;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (url.Contains(dt.Rows[i]["Friendly_name"].ToString()))
                {
                    flag = true;
                }
            }
            return flag;

        }

    }
}


