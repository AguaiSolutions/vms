using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aguai_Leave_Management_System;
using Vacation_management_system.Web.Common;
using System.Globalization;

namespace Vacation_management_system.Web.Holidays
{
    public partial class Holidays : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        private string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load();
            }
        }

        protected void load()
        {
            try
            {
                query = "SELECT  id,holiday_name,CONVERT(varchar,holiday_date,103)as holiday_date from holidays";
                ds.RunQuery(out _data, query);
                DataTable table = new DataTable();
                if (_data.HasRows == true)
                {
                    table.Load(_data);
                    gvHolidays.DataSource = table;
                    gvHolidays.DataBind();
                }
                else
                    lblEmpty.Text = "No records found";
                _data.Close();
                ds.Close();
            }

            catch (Exception ex)
            {
                Response.Redirect("~/Web/Login/Login.aspx");
            }
        }

        protected void gvHolidays_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHolidays.EditIndex = e.NewEditIndex;
            load();
        }

        protected void gvHolidays_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gvHolidays.DataKeys[e.RowIndex].Values["id"].ToString();
            TextBox holiday_name = (TextBox)gvHolidays.Rows[e.RowIndex].FindControl("txtName");

            TextBox holiday_date = (TextBox)(gvHolidays.Rows[e.RowIndex].FindControl("txtHolidayDate"));
          
            DateTime H_date;
            var xxsd = DateTime.TryParseExact(holiday_date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out H_date);
            query = "update holidays set holiday_name='" + holiday_name.Text + "', holiday_date='" + H_date + "' where id=" + id + "";
            ds.RunCommand(query);
            ds.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Holidays Updated Successfully.')</script>");
            gvHolidays.EditIndex = -1;
            load();
        }

        protected void gvHolidays_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHolidays.EditIndex = -1;
            load();
        }

        protected void gvHolidays_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                query = "delete holidays where ID=" + id + "";
                ds.RunCommand(query);
                ds.Close();

                Response.Redirect("~/Web/Holidays/Holidays.aspx");
            }
        }

        protected void btnAddHolidays_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/Holidays/AddHolidays.aspx");
        }
    }
}