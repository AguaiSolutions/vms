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

namespace Vacation_management_system.Web.MyVacation
{
    public partial class MyVacation : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
              if( Session["role_ID"].Equals(1))
              {
                  btnapplyleave.Visible = false;
                  string query = "SELECT  L.id, E.first_name,CONVERT(varchar,L.from_date,103)as from_date,CONVERT(varchar,L.to_date,103)as to_date,L.description,leave_type.leave_type as type_id, 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' END,L.reason FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id  order by 1 DESC";
                  ds.RunQuery(out _data, query);
                  DataTable table = new DataTable();
                  if (_data.HasRows == true)
                  {
                      table.Load(_data);
                      GridView1.DataSource = table;
                      GridView1.DataBind();
                  }
                  else
                      lblEmpty.Text = "No records found";
                  _data.Close();
                  ds.Close();

              }
              else
              { 
                //Employee Leave Management
                string query = "SELECT   L.id,E.first_name,CONVERT(varchar,L.from_date,103)as from_date,CONVERT(varchar,L.to_date,103)as to_date,L.description,leave_type.leave_type as type_id, 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' END,L.reason FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id where emp_id=" + Session["userId"] + " order by 1 DESC";
                ds.RunQuery(out _data, query);
                DataTable table = new DataTable();
                if (_data.HasRows == true)
                {
                    table.Load(_data);
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
                else
                    lblEmpty.Text = "No records found";
                _data.Close();
                ds.Close();
              }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           lblRow_Id.Text = (e.CommandArgument).ToString();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button lbtCancel = (Button)e.Row.FindControl("btncancel");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[6].Text.Equals("Cancelled"))
                {
                    lbtCancel.Visible = false;
                }

            }
        }

        protected void btnApplyLeave_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApplyNewVacation.aspx");
        }

        protected void btncancel(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;

            ////Get the row that contains this button
            //GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            //lblEmpty.Text = gvr.Cells[0].Text;
            //txtCfromdate.Text = gvr.Cells[2].Text;
            //txtCtodate.Text = gvr.Cells[3].Text;
            //txtCleavetype.Text = gvr.Cells[5].Text;
            //txtCapprover.Text = gvr.Cells[6].Text;
            //txtCdesc.Text = gvr.Cells[4].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true); 
        }

       
       protected void  btnCancelReason_Click(object sender, EventArgs e)
        {

            string query = "update [dbo].[leave_management] set approval_status='c', reason='"+txtCreason.Text+"' where id=" +lblRow_Id.Text+ "";
           var res= ds.RunCommand(query);
           ds.Close();
           if(!res)
           {
               ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('you are already applied vacation for this dates.')</script>");
                      
           }
           else
             Response.Redirect("~/Web/MyVacation/MyVacation.aspx");
      


        }
    }
}
