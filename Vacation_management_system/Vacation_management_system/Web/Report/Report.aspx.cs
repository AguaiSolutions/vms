using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Aguai_Leave_Management_System;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Web.UI.HtmlControls;
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;


namespace Vacation_management_system.Web.MyVacation
{

    public partial class Report : System.Web.UI.Page
    {
        Database ds = new Database();
        string query;
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            panelhide1.Visible = false;

            if (!IsPostBack)
            {
                
                dd_name();

                dd_monthbind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " hiderow();", true);
               
                leavetype();
                if (Session["role_ID"].Equals(3))
                {
                    emp.Style.Add("display","none");
                }
               
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "clear1", " pageLoad();", true);


        }

        private void leavetype()
        {
            Database ob = new Database();
            query = "select * from leave_type";
            SqlDataReader _data;
            ob.RunQuery(out _data, query);
            while (_data.Read())
            {
                drpLeavetype.Items.Add(new ListItem(_data["leave_type"].ToString(), _data["id"].ToString()));
            }
            _data.Close();
            ds.Close();
        }
        private void dd_monthbind()
        {
           
            DateTime now = DateTime.Now;
           
            for (int i = 1; i < 13; i++)
            {

                string month1 = now.ToString("MMMM " + "yyyy");
                //string year = now.ToString("yyyy");

                month.Items.Add(new ListItem(month1, now.Month.ToString()));

                now = now.AddMonths(-1);
            }
            month.Multiple = true;

        }


        private void dd_name()
        {

            if (Session["role_ID"].Equals(1))
            {
                query = "select id ,first_name+' '+last_name as name from employee where  role_id NOT IN (1)";

                SqlDataReader _data;

                ds.RunQuery(out _data, query);
                dt.Load(_data);
                drpName.DataSource = dt;
                drpName.DataValueField = "id";
                drpName.DataTextField = "name";
                drpName.DataBind();
                drpName.Multiple = true;
                _data.Close();
            }
            if (Session["role_ID"].Equals(2))
            {

                query = "select employee.id,employee.first_name+' '+employee.last_name as name from employee left join manager on employee.id=manager.employee_id where manager_id=" + Session["userId"] + "";

                SqlDataReader _data;

                ds.RunQuery(out _data, query);
                dt.Load(_data);
                drpName.DataSource = dt;
                drpName.DataValueField = "id";
                drpName.DataTextField = "name";
                drpName.DataBind();
                drpName.Multiple = true;
            }

            if (Session["role_ID"].Equals(3))
            {
                drpName.Disabled = true;
            }
        }

       

        protected void btnView_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", "clear();", true);
            bindgrind();
        }
        private void bindgrind()
        {

            if (txtFromDate.Text != "" || txtToDate.Text != "")
            {
                if (!(txtFromDate.Text != "" && txtToDate.Text != ""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " daterange();", true);
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Both from and todate is required')</script>");
                    return;
                }
            }
            DateTime fromdate;
            var xxsd = DateTime.TryParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                    out  fromdate);
            DateTime todate;
            var xsd = DateTime.TryParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                    out  todate);

            string query;
            if (Session["role_ID"].Equals(1))
            {
                if ((month.Value == "") && (drpStatus.Value == "") && (drpEmployee.Value == "") && (drpName.Value == "") && ((txtFromDate.Text == "")) && (txtToDate.Text == "") &&(drpLeavetype.Value==""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " hiderow();", true);
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation1", "<script language='javascript'>alert('please select the required report ')</script>");
                }
                else
                {
                    query = "SELECT  L.id, E.first_name,m.leave_type, CONVERT(varchar,L.from_date,103) as from_date, CONVERT(varchar,L.to_date,103) as to_date ,  approval_status=CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'i' THEN 'Ideal' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending'  END  FROM leave_management as L inner join leave_type m on l.type_id=m.id inner join employee as E on E.id=l.emp_id where"; 

                    string oncondition = " (";
                    if (month.Value != "")
                    {

                        for (int i = 0; i <= month.Items.Count - 1; i++)
                        {
                            if (month.Items[i].Selected)
                            {
                                query += oncondition;
                                query += " DATEPART(month,L.from_date)='" + month.Items[i].Value + "' ";
                                //oncondition = "and  ";
                                query += " and DATEPART(year, from_date)=DATEPART(year, GETDATE())";
                                oncondition = "or";
                            }

                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", "Result();", true);
                        oncondition = " ) and (";
                    }

                    if(drpLeavetype.Value!="")
                    {
                        for(int i=0;i<drpLeavetype.Items.Count;i++)
                        {
                            if(drpLeavetype.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "m.leave_type='" + drpLeavetype.Items[i].Text + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = ") and (";
                    }

                    if (drpEmployee.Value != "")
                    {
                        for (int i = 0; i <= drpEmployee.Items.Count - 1; i++)
                        {
                            if (drpEmployee.Items[i].Selected)
                            {
                                query += oncondition;
                                query += " E.isactive='" + drpEmployee.Items[i].Value + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = " ) and  (";
                    }

                    if (drpStatus.Value != "")
                    {
                        for (int i = 0; i <= drpStatus.Items.Count - 1; i++)
                        {
                            if (drpStatus.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "   L.approval_status='" + drpStatus.Items[i].Value + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = ") and (";
                    }

                    if (drpName.Value != "")
                    {
                        for (int i = 0; i <= drpName.Items.Count - 1; i++)
                        {
                            if (drpName.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "  e.id='" + drpName.Items[i].Value + "'";
                                oncondition = "or ";
                            }

                        }
                        oncondition = " )and (";
                    }
                    if (txtFromDate.Text.Length != 0 && txtToDate.Text.Length != 0)
                    {
                        if (fromdate <= todate)
                        // if ((txtFromDate.Text != "") && (txtToDate.Text != ""))
                        {
                            query += oncondition;
                            query += "L.from_date>='" + fromdate + "' and ";
                            oncondition = "and ";
                            query += "L.to_date<='" + todate + "'";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", "showcheckfordate();", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " daterange();", true);
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation2", "<script language='javascript'>alert('Fromdate should be less then Todate ')</script>");
                            return;
                        }
                    }

                    else if (!((month.Value == "") || (drpStatus.Value == "") || (drpEmployee.Value == "") || (drpName.Value == "") || (drpLeavetype.Value == "")))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " daterange();", true);
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation3", "<script language='javascript'>alert('From date should be less then To date ')</script>");
                        return;
                    }

                    if (txtFromDate.Text.Length == 0 && txtToDate.Text.Length == 0 && month.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " hiderow();", true);

                    }

                    query += ")";
                    SqlDataReader _data;
                    ds.RunQuery(out _data, query);
                    GridviewBind(_data);
                    _data.Close();
                    ds.Close();
                }
            }
            if (Session["role_ID"].Equals(3))
            {

                if ((month.Value == "") && (drpStatus.Value == "") && (drpEmployee.Value == "") && (drpName.Value == "") && ((txtFromDate.Text == "")) && (txtToDate.Text == "") && (drpLeavetype.Value == ""))
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " hiderow();", true);
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation4", "<script language='javascript'>alert('please select the required report')</script>");
                }
                else
                {
                    query = "SELECT  L.id, E.first_name,m.leave_type,m.id, CONVERT(varchar,L.from_date,103) as from_date, CONVERT(varchar,L.to_date,103) as to_date ,approval_status= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'i' THEN 'Ideal' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END  FROM leave_management as L inner join leave_type m on l.type_id=m.id inner join employee as E on E.id=l.emp_id  where e.id=" + Session["userId"] + "";
                    string oncondition = " and (";
                    if (month.Value != "")
                    {

                        for (int i = 0; i <= month.Items.Count - 1; i++)
                        {
                            if (month.Items[i].Selected)
                            {
                                query += oncondition;
                                query += " DATEPART(month,L.from_date)='" + month.Items[i].Value + "' ";
                                //oncondition = "and  ";
                                query += " and DATEPART(year, from_date)=DATEPART(year, GETDATE())";
                                oncondition = "or";
                            }

                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", "Result();", true);

                        oncondition = " ) and (";
                    }

                    if (drpLeavetype.Value != "")
                    {
                        for (int i = 0; i < drpLeavetype.Items.Count; i++)
                        {
                            if (drpLeavetype.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "m.leave_type='" + drpLeavetype.Items[i].Text + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = ") and (";
                    }

                    if (drpEmployee.Value != "")
                    {
                        for (int i = 0; i <= drpEmployee.Items.Count - 1; i++)
                        {
                            if (drpEmployee.Items[i].Selected)
                            {
                                query += oncondition;
                                query += " E.isactive='" + drpEmployee.Items[i].Value + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = " ) and  (";
                    }

                    if (drpStatus.Value != "")
                    {
                        for (int i = 0; i <= drpStatus.Items.Count - 1; i++)
                        {
                            if (drpStatus.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "   L.approval_status='" + drpStatus.Items[i].Value + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = ") and (";
                    }

                    if (drpName.Value != "")
                    {
                        for (int i = 0; i <= drpName.Items.Count - 1; i++)
                        {
                            if (drpName.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "  e.id='" + drpName.Items[i].Value + "'";
                                oncondition = "or ";
                            }

                        }
                        oncondition = " ) and (";
                    }
                    if (txtFromDate.Text.Length != 0 && txtToDate.Text.Length != 0)
                    {
                        if(fromdate<=todate)
                       // if ((txtFromDate.Text != "") && (txtToDate.Text != ""))
                        {
                            query += oncondition;
                            query += "L.from_date>='" + fromdate + "' and ";
                            oncondition = "and ";
                            query += "L.to_date<='" + todate + "'";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", "showcheckfordate();", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " daterange();", true);
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation5", "<script language='javascript'>alert('Fromdate should be less then Todate ')</script>");
                            return;
                        }
                    }

                    else if (!((month.Value == "") || (drpStatus.Value == "") || (drpEmployee.Value == "") || (drpName.Value == "") || (drpLeavetype.Value == "")))
                
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " daterange();", true);
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation6", "<script language='javascript'>alert('From date should be less then To date ')</script>");
                        return;
                    }

                    if (txtFromDate.Text.Length == 0 && txtToDate.Text.Length == 0 && month.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " hiderow();", true);

                    }
                    query += ")";
                    SqlDataReader _data;
                    ds.RunQuery(out _data, query);
                   
                    GridviewBind(_data);
                    _data.Close();
                    ds.Close();
                }
            }
            if (Session["role_ID"].Equals(2))
            {
                if ((month.Value == "") && (drpStatus.Value == "") && (drpEmployee.Value == "") && (drpName.Value == "") && ((txtFromDate.Text == "")) && (txtToDate.Text == "") && (drpLeavetype.Value == ""))
                {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " hiderow();", true);
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('please select the required report ')</script>");
                }
                else
                {

                    query = "SELECT  L.id,E.id, E.first_name,t.leave_type, CONVERT(varchar,L.from_date,103)as from_date, CONVERT(varchar,L.to_date,103) as to_date , approval_status= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'i' THEN 'Ideal' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END FROM leave_management as L inner join manager m on l.emp_id=m.employee_id inner join leave_type as t on l.type_id=t.id inner join  employee E on l.emp_id=e.id";
                    string oncondition = " and (";

                    if (Session["role_ID"].Equals(2))
                    {

                        query += oncondition;
                        query += " m.manager_id='" + Session["userId"] + "'";
                        oncondition = " ) and ( ";

                    }

                    if (drpLeavetype.Value != "")
                    {
                        for (int i = 0; i < drpLeavetype.Items.Count; i++)
                        {
                            if (drpLeavetype.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "t.leave_type='" + drpLeavetype.Items[i].Text + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = ") and (";
                    }
                    if (month.Value != "")
                    {

                        for (int i = 0; i <= month.Items.Count - 1; i++)
                        {
                            if (month.Items[i].Selected)
                            {
                                query += oncondition;
                                query += " DATEPART(month,L.from_date)='" + month.Items[i].Value + "' ";
                                //oncondition = "and  ";
                                query += " and DATEPART(year, from_date)=DATEPART(year, GETDATE())";
                                oncondition = "or";
                            }

                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", "Result();", true);
                        oncondition = " ) and (";
                    }



                    if (drpEmployee.Value != "")
                    {
                        for (int i = 0; i <= drpEmployee.Items.Count - 1; i++)
                        {
                            if (drpEmployee.Items[i].Selected)
                            {
                                query += oncondition;
                                query += " E.isactive='" + drpEmployee.Items[i].Value + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = " ) and  (";
                    }

                    if (drpStatus.Value != "")
                    {
                        for (int i = 0; i <= drpStatus.Items.Count - 1; i++)
                        {
                            if (drpStatus.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "   L.approval_status='" + drpStatus.Items[i].Value + "'";
                                oncondition = "or ";
                            }
                        }
                        oncondition = ") and (";
                    }

                    if (drpName.Value != "")
                    {
                        for (int i = 0; i <= drpName.Items.Count - 1; i++)
                        {
                            if (drpName.Items[i].Selected)
                            {
                                query += oncondition;
                                query += "  e.id='" + drpName.Items[i].Value + "'";
                                oncondition = "or ";
                            }

                        }
                        oncondition = " )and (";
                    }
                    if (txtFromDate.Text.Length != 0 && txtToDate.Text.Length != 0)
                    {
                        if (fromdate <= todate)
                        // if ((txtFromDate.Text != "") && (txtToDate.Text != ""))
                        {
                            query += oncondition;
                            query += "L.from_date>='" + fromdate + "' and ";
                            oncondition = "and ";
                            query += "L.to_date<='" + todate + "'";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", "showcheckfordate();", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " daterange();", true);
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Fromdate should be less then Todate ')</script>");
                            return;
                        }
                    }

                    else if (!((month.Value == "") || (drpStatus.Value == "") || (drpEmployee.Value == "") || (drpName.Value == "") || (drpLeavetype.Value == "")))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " daterange();", true);
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('From date should be less then To date ')</script>");
                        return;
                    }
                    if (txtFromDate.Text.Length == 0 && txtToDate.Text.Length == 0 && month.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "clear", " hiderow();", true);

                    }
                    query += ")";
                    SqlDataReader _data;
                    ds.RunQuery(out _data, query);
                    GridviewBind(_data);
                    _data.Close();
                    ds.Close();

                }
            }
        }




        protected void grdview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdview1.PageIndex = e.NewPageIndex;
            bindgrind();

        }


        protected void btnclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");

        }

        protected void grdview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblrecords = (Label)e.Row.FindControl("lblrecords");

            }
        }

        protected void GridviewBind(SqlDataReader data)
        {
            //HtmlGenericControl panel = new HtmlGenericControl("panelhide");
            panelhide1.Visible = true;
            DataTable dt = new DataTable();
            dt.Load(data);
            grdview1.DataSource = dt;
            grdview1.DataBind();
            No_of_records.Text = "<b>Number of records found: </b> " + dt.Rows.Count + "";
        }

        //protected void from_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (from.Checked==true)
        //    {

        //        txtFromDate.Enabled = true;

        //        txtToDate.Enabled = true;
        //        month.Disabled = true;

        //    }

        //    if(rmonth.Checked==true)
        //    {
        //        month.Disabled = false;
        //        txtFromDate.Enabled = false;
        //        txtToDate.Enabled = false;
        //    }
        //}


    }
}