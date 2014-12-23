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


using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;


namespace Vacation_management_system.Web.MyVacation
{

    public partial class Report : System.Web.UI.Page
    {
        Database ds = new Database();
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               dd_name();
               month.Items.Insert(0, new ListItem("-select-", string.Empty));
                dd_monthbind();
                //drpEmployee.Items.Insert(0, new ListItem("-select-", string.Empty));

                //drpStatus.Items.Insert(0, new ListItem("-select-", string.Empty));
            }
            if (Session["role_ID"].Equals(3))
            {
                drpName.Visible = false;
                name.Visible = false;

            }
            
        }


        private void dd_monthbind()
        {

            DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
            for (int i = 1; i < 13; i++)
            {
               month.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
            }
            month.Multiple = true;

        }


        private void dd_name()
       {
           query = "select id ,first_name+' '+last_name as name from employee";
           DataTable dt = new DataTable();

           SqlDataReader _data;

           ds.RunQuery(out _data, query);
           dt.Load(_data);
           drpName.DataSource = dt;
           drpName.DataValueField = "id";
           drpName.DataTextField = "name";
           drpName.DataBind();
           drpName.Multiple = true;

        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            bindgrind();
        }
        private void bindgrind()
        {
            DateTime fromdate;
            var xxsd = DateTime.TryParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                    out  fromdate);
            DateTime todate;
            var xsd = DateTime.TryParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                    out  todate);

            string query;
            if (Session["role_ID"].Equals(1))
            {
                if ((month.Value=="") && (drpStatus.Value == "") && (drpEmployee.Value == "") && ((txtFromDate.Text == "") && (txtToDate.Text == "")))
                {

                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('please select any one of the below ')</script>");
                }
                else
                {
                    query = "SELECT  L.id, E.first_name, CONVERT(varchar,L.from_date,103) as from_date, CONVERT(varchar,L.to_date,103) as to_date ,'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'i' THEN 'Ideal' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END FROM leave_management as L inner join employee as E on E.id=l.emp_id where";
                    string oncondition = " (";
                     if (month.Value != "")
                        {
                            
                            for (int i = 0; i <= month.Items.Count - 1; i++ )
                            {
                                if(month.Items[i].Selected)
                                {
                                    query += oncondition;
                                    query += " DATEPART(month,L.from_date)='" + month.Items[i].Value+ "'";
                                    oncondition = "or  ";
                                }
                              
                                }
                            
                            oncondition = " ) and (";
                           }



                        if (drpEmployee.Value != "")
                        {
                            for (int i = 0; i <= drpEmployee.Items.Count - 1; i++)
                            {
                                if (drpEmployee.Items[i].Selected)
                                {
                                    query += oncondition;
                                    query += " E.isactive='" + drpEmployee.Items[i].Value+ "'";
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

                        if(drpName.Value!="")
                        {
                            for(int i=0;i<=drpName.Items.Count-1;i++)
                            {
                                if(drpName.Items[i].Selected)
                                {
                                    query += oncondition;
                                    query += "  e.id='" + drpName.Items[i].Value + "'";
                                    oncondition = "or ";
                                }

                            }
                            oncondition =  " )and (";
                       }
                        if ((txtFromDate.Text.Length > 0) && (txtToDate.Text.Length > 0))
                        {
                            query += oncondition;
                            query += "L.from_date>='" + fromdate + "' and ";
                            oncondition = "and ";
                            query += "L.to_date<='" + todate + "'";
                        }
                      
                         query+=")";
                        SqlDataReader _data;
                        ds.RunQuery(out _data, query);

                        if (_data.HasRows == true)
                        {
                            lblEmpty.Visible = false;
                            DataTable dt = new DataTable();
                            grdview1.Visible = true;

                            dt.Load(_data);


                            grdview1.DataSource = dt;
                            grdview1.DataBind();
                            _data.Close();
                            ds.Close();

                        }

                        else
                        {
                            lblEmpty.Visible = true;
                            grdview1.Visible = false;
                            lblEmpty.Text = "No records found";
                            _data.Close();
                            ds.Close();

                        }
                    
                }
            }
            if (Session["role_ID"].Equals(3))  
            {
                drpName.Visible = false;
                if ((month.Value=="") && (drpStatus.Value == "") && (drpEmployee.Value == "") && ((txtFromDate.Text == "") && (txtToDate.Text == "")))
                {
                

                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('please select ')</script>");
                }
                else
                {
                    query = "SELECT  L.id,E.id, E.first_name, CONVERT(varchar,L.from_date,103)as from_date, CONVERT(varchar,L.to_date,103) as to_date , 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'i' THEN 'Ideal' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END FROM leave_management as L inner join  employee E on l.emp_id=e.id where e.id=" + Session["userId"] + "";
                    string oncondition = " and (";
                    if (month.Value != "")
                    {

                        for (int i = 0; i <= month.Items.Count - 1; i++)
                        {
                            if (month.Items[i].Selected)
                            {
                                query += oncondition;
                                query += " DATEPART(month,L.from_date)='" + month.Items[i].Value + "'";
                                oncondition = "or  ";
                            }

                        }

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
                    if ((txtFromDate.Text.Length > 0) && (txtToDate.Text.Length > 0))
                    {
                        query += oncondition;
                        query += "L.from_date>='" + fromdate + "' and ";
                        oncondition = "and ";
                        query += "L.to_date<='" + todate + "'";
                    }

                    query += ")";
                    SqlDataReader _data;
                    ds.RunQuery(out _data, query);

                    if (_data.HasRows == true)
                    {
                        lblEmpty.Visible = false;
                        DataTable dt = new DataTable();
                        grdview1.Visible = true;

                        dt.Load(_data);


                        grdview1.DataSource = dt;
                        grdview1.DataBind();
                        _data.Close();
                        ds.Close();

                    }

                    else
                    {
                        lblEmpty.Visible = true;
                        grdview1.Visible = false;
                        lblEmpty.Text = "No records found";
                        _data.Close();
                        ds.Close();

                    }

                }
            }
            if (Session["role_ID"].Equals(2))
            {
                if ((month.Value=="") && (drpStatus.Value == "") && (drpEmployee.Value == "") && ((txtFromDate.Text == "") && (txtToDate.Text == "")))
                
                {

                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('please select ')</script>");
                }
                else
                {

                    query = "SELECT  L.id,E.id, E.first_name, CONVERT(varchar,L.from_date,103)as from_date, CONVERT(varchar,L.to_date,103) as to_date , 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'i' THEN 'Ideal' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END FROM leave_management as L inner join manager m on l.emp_id=m.employee_id inner join  employee E on l.emp_id=e.id ";
                    string oncondition = " and (";
                    if (month.Value != "")
                    {

                        for (int i = 0; i <= month.Items.Count - 1; i++)
                        {
                            if (month.Items[i].Selected)
                            {
                                query += oncondition;
                                query += " DATEPART(month,L.from_date)='" + month.Items[i].Value + "'";
                                oncondition = "or  ";
                            }

                        }

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
                    if ((txtFromDate.Text.Length > 0) && (txtToDate.Text.Length > 0))
                    {
                        query += oncondition;
                        query += "L.from_date>='" + fromdate + "' and ";
                        oncondition = "and ";
                        query += "L.to_date<='" + todate + "'";
                    }

                    query += ")";
                    SqlDataReader _data;
                    ds.RunQuery(out _data, query);

                    if (_data.HasRows == true)
                    {
                        lblEmpty.Visible = false;
                        DataTable dt = new DataTable();
                        grdview1.Visible = true;

                        dt.Load(_data);


                        grdview1.DataSource = dt;
                        grdview1.DataBind();
                        _data.Close();
                        ds.Close();

                    }

                    else
                    {
                        lblEmpty.Visible = true;
                        grdview1.Visible = false;
                        lblEmpty.Text = "No records found";
                        _data.Close();
                        ds.Close();

                    }

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




    }
}