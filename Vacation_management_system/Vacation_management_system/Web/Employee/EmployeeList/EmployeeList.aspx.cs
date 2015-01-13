using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aguai_Leave_Management_System;
using Vacation_management_system.Web.Common.Class;

namespace Vacation_management_system.Web.Employee
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack)
            {
                GridviewBind();

                List<string> menu = new List<string>();
                DataTable dt = new DataTable();
                dt = (DataTable) Session["menuslist"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    menu.Add(dt.Rows[i]["menu_name"].ToString());

                }
                if (!menu.Contains("Add Employee"))
                {
                    //Removing the Edit button column from the Grid View 
                    GvEmployeeList.Columns[9].Visible = false;

                }
                
            }
        }

        protected void GvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Web/Employee/AddEmployee/Add.aspx?id=" + id + "");
            }
        }
        protected void GvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Utilities.convertToSingleQuote(e.Row.Cells[2].Text);
                e.Row.Cells[3].Text = Utilities.convertToSingleQuote(e.Row.Cells[3].Text);
            }
        }

        private void GridviewBind()
        {
            string query = "IF EXISTS (SELECT manager_id FROM manager where manager_id = " + Session["userId"] + ")BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";

            int value = Convert.ToInt32(ds.ExecuteObjectQuery(query));

            if(value==1)
            {
                query = "SELECT employee.id ,emp_no,(first_name+' '+last_name) as name,gender = case gender WHEN 'M' THEN 'Male' WHEN 'F' THEN 'Female' END,official_email,CONVERT(varchar,date_of_join,103)as date_of_join,contact_number,permanent_address,isactive = case isactive WHEN '1' THEN 'Active' WHEN '0' THEN 'Inactive' END from manager left join employee on employee.id = employee_id where isactive = 1 and manager_id = " + Session["userId"];
            }
            else
            {
                query = "SELECT id ,emp_no,(first_name+' '+last_name) as name,gender = case gender WHEN 'M' THEN 'Male' WHEN 'F' THEN 'Female' END,official_email,CONVERT(varchar,date_of_join,103)as date_of_join,contact_number,permanent_address,isactive = case isactive WHEN '1' THEN 'Active' WHEN '0' THEN 'Inactive' END from employee where isactive='1' and role_id not in(1) and id not in (" + Session["userId"] + ")";
            }
            
            ds.RunQuery(out _data, query);
            DataTable dt = new DataTable();
            dt.Load(_data);
            GvEmployeeList.DataSource = dt;
            GvEmployeeList.DataBind();
            _data.Close();
            ds.Close();
           
        }

        protected void grdview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var msg = "<script language='javascript'> $(\"#demo1\").removeClass(\"collapse\");</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation11", msg);
            GvEmployeeList.PageIndex = e.NewPageIndex;
            GridviewBind();

        }
    }
}