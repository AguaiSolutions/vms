using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Aguai_Leave_Management_System;

namespace Vacation_management_system.Web.Employee
{
    public partial class Roles : System.Web.UI.Page
    {
        DataTable dt_role = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            Database ds = new Database();
            SqlDataReader _data;
            string query;
            if (!IsPostBack)
            {
                query = "SELECT id,role_name FROM user_roles where role_name NOT IN ('Admin') ORDER BY ID DESC ";

                ds.RunQuery(out _data, query);
                while (_data.Read())
                {
                    drplist_Roles.Items.Add(new ListItem(_data["role_name"].ToString(), _data["id"].ToString()));
                }
                _data.Close();
                ds.Close();
                drplist_Roles_SelectedIndexChanged(sender, e);

            }


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            var text = drplist_Roles.SelectedValue;
            var dhbd = drplist_Roles.SelectedItem;
            var texdfd = drplist_Roles.SelectedIndex;

        }

        protected void drplist_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var msg = "<script language='javascript'> $(\"#demo1\").removeClass(\"collapse\");</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation13", msg);
            StringBuilder menulist = new StringBuilder();
            Database ds = new Database();
            var role_id = drplist_Roles.SelectedValue;
            string query = "select menu_name, menu.id as menuID , parent_id from  user_roles inner join roles_access  on user_roles.id=" + role_id + " and role_id=" + role_id + " left join menu  on menu_id=menu.id order by order_id";
            // string query = "select menu_name, menu.id as menuID , parent_id from  user_roles inner join roles_access  on user_roles.id=1 and role_id=1 left join menu  on menu_id=menu.id order by order_id";

            SqlDataReader data;
            ds.RunQuery(out data, query);
            dt_role.Load(data);
            data.Close();
            ds.Close();

            SqlDataReader _data;
            query = "select menu_name, id, parent_id  from menu where parent_id=0 order by order_id";
            ds.RunQuery(out _data, query);
            DataTable dt = new DataTable();
            dt.Load(_data);
            gvmenu.DataSource = dt;
            gvmenu.DataBind();
            _data.Close();
            ds.Close();

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Int32 Id = Convert.ToInt32(gvmenu.DataKeys[e.Row.RowIndex].Value);
                GridView gvChildmenu = e.Row.FindControl("gvChildmenu") as GridView;
                CheckBox chkbox = e.Row.FindControl("chk_name") as CheckBox;
                Database ds = new Database();
                Label lblDashboard = e.Row.FindControl("lblName") as Label;

                if (lblDashboard.Text == "Dashboard")
                {
                    chkbox.Enabled = false;
                    chkbox.Checked = true;
                    chkbox.ForeColor = System.Drawing.Color.Blue;
                }
                bool contains = dt_role.AsEnumerable().Any(row => Id == row.Field<Int32>("menuID"));
                if (contains)
                {
                    ((CheckBox)chkbox).Checked = true;
                    chkbox.ForeColor = System.Drawing.Color.Blue;
                }

                string query = "select menu_name, id from menu where parent_id=" + Id + " order by order_id";
                SqlDataReader _data;
                ds.RunQuery(out _data, query);
                DataTable dt = new DataTable();
                if (_data.HasRows == true)
                {
                    dt.Load(_data);
                    gvChildmenu.DataSource = dt;
                    _data.Close();
                    ds.Close();
                    gvChildmenu.DataBind();
                }

            }

        }
        protected void gvchild_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvchild = sender as GridView;
                int Id = Convert.ToInt32(gvchild.DataKeys[e.Row.RowIndex].Value);
                CheckBox chkbox1 = e.Row.FindControl("chk_child_name") as CheckBox;
                bool contains1 = dt_role.AsEnumerable().Any(row => Id == row.Field<Int32>("menuID"));
                if (contains1)
                {
                    ((CheckBox)chkbox1).Checked = true;
                }
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();

            query.Append("insert into roles_access values");
            Database ds = new Database();
            string delete = "delete from roles_access where role_id=" + drplist_Roles.SelectedValue + "";
            var res = ds.RunCommand(delete);
            string join = "";
            foreach (GridViewRow row in gvmenu.Rows)
            {
                if ((row.FindControl("chk_name") as CheckBox).Checked)
                {
                    query.Append(join);
                    Int32 x = Convert.ToInt32(gvmenu.DataKeys[row.RowIndex].Value);
                    query.Append("(" + drplist_Roles.SelectedValue + "," + x + ")");
                    join = ",";

                };
                GridView gvChildmenu = (GridView)row.FindControl("gvChildmenu");
                foreach (GridViewRow r in gvChildmenu.Rows)
                {
                    if ((r.FindControl("chk_child_name") as CheckBox).Checked)
                    {
                        query.Append(join);
                        Int32 y = Convert.ToInt32(gvChildmenu.DataKeys[r.RowIndex].Value);
                        query.Append("(" + drplist_Roles.SelectedValue + "," + y + ")");
                        join = ",";

                    }

                }

            }

            var res1 = ds.RunCommand(query.ToString());
            if (res1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "confirmation();", true);
            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (DuplicateValidation() == 0)
            {
                Database ds = new Database();
                string query = "insert into user_roles (role_name) values ('" + txtRole_Name.Text.Trim() +
                               "') SELECT SCOPE_IDENTITY()";
                Int32 Role_ID = Convert.ToInt32(ds.ExecuteObjectQuery(query));
                query = "insert into roles_access values(" + Role_ID + ",1)";
                var res = ds.RunCommand(query);
                Response.Redirect("Roles.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation",
                    "<script language='javascript'>alert('Role Name already exists.')</script>");

            }
            txtRole_Name.Text = "";
        }

        public int DuplicateValidation()
        {
            Database ds = new Database();
            string _query =
                 "IF EXISTS (SELECT role_name FROM user_roles where role_name like '%" + txtRole_Name.Text.Trim() + "%')BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";
            return Convert.ToInt32(ds.ExecuteObjectQuery(_query));

        }

        //protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    var selectall = (CheckBox)sender;
        //    foreach (GridViewRow row in gvmenu.Rows)
        //    {
        //        var lblDashboard = row.FindControl("lblName") as Label;
        //        if (!(lblDashboard.Text.Equals("Dashboard")))
        //        {
        //            if (selectall.Checked)
        //            {
        //                var parentCheck = row.FindControl("chk_name") as CheckBox;
        //                if (!parentCheck.Checked)
        //                {
        //                    parentCheck.Checked = true;
        //                }
        //                GridView gvChildmenu = (GridView)row.FindControl("gvChildmenu");
        //                foreach (GridViewRow r in gvChildmenu.Rows)
        //                {
        //                    var childCheck = r.FindControl("chk_child_name") as CheckBox;
        //                    if (!childCheck.Checked)
        //                    {
        //                        childCheck.Checked = true;

        //                    }

        //                }

        //            }
        //            else
        //            {
        //                var parentCheck = row.FindControl("chk_name") as CheckBox;
        //                if (!parentCheck.Checked)
        //                {
        //                    parentCheck.Checked = true;
        //                }
        //                GridView gvChildmenu = (GridView)row.FindControl("gvChildmenu");
        //                foreach (GridViewRow r in gvChildmenu.Rows)
        //                {
        //                    var childCheck = r.FindControl("chk_child_name") as CheckBox;
        //                    if (!childCheck.Checked)
        //                    {
        //                        childCheck.Checked = true;

        //                    }

        //                }
        //            }


        //        }
        //    }


        //}

    }
}