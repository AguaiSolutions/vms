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
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;
using System.Globalization;

namespace Vacation_management_system.Web.Holidays
{
    public partial class Holidays : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        private SqlDataReader _data2;
        private string query;
        Int32 Hid;
        List<DateTime> holidayDates;
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

                    holidaytable.Style.Add("display", "none");
                    btnSave.Visible = false;
                    table.Load(_data);
                    gvHolidays.DataSource = table;
                    gvHolidays.DataBind();
                }
                else
                {
                    holidaytable.Style.Add("display", "inline");
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                }
                _data.Close();
                ds.Close();
            }

            catch (Exception ex)
            {
                Response.Redirect("~/Web/Login/Login.aspx");
            }
        }

        public List<DateTime> GetHolidaydates()
        {
            holidayDates = new List<DateTime>();

            query = "SELECT id,holiday_date from holidays";
            ds.RunQuery(out _data2, query);
            while (_data2.Read())
            {
                if (_data2["id"] != null)
                {
                    holidayDates.Add(Convert.ToDateTime(_data2["holiday_date"]));
                }
            }
            _data2.Close();
            ds.Close();

            return holidayDates;
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
            H_date = Convert.ToDateTime(holiday_date.Text);
            var duplicate1 = duplicate_check(H_date, GetHolidaydates());
            if (duplicate1 == true)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('You have entered an existing holiday.')</script>");
            }
            else
            {
                query = "update holidays set holiday_name='" + holiday_name.Text + "', holiday_date='" + H_date + "' where id=" + id + "";
                ds.RunCommand(query);
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Holidays Updated Successfully.')</script>");
                ds.Close();
            }
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
            if (e.CommandName.Equals("Insert"))
            {

                TextBox name = (TextBox)gvHolidays.FooterRow.FindControl("txtHname3");
                TextBox date = (TextBox)gvHolidays.FooterRow.FindControl("txtHdate3");
                if (!(name.Text.Equals("") || date.Text.Equals("")))
                {
                    DateTime H_date1;
                    H_date1 = Convert.ToDateTime(date.Text);
                    var duplicate1 = duplicate_check(H_date1, GetHolidaydates());
                    if (duplicate1 == true)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('You have entered an existing holiday.')</script>");
                    }
                    else
                    {
                        query = "insert into holidays values('" + Utilities.convertQuotes(name.Text.Trim()) + "','" + H_date1 + "')";
                        ds.RunCommand(query);
                        ds.Close();
                        load();
                        Response.Redirect("~/Web/Holidays/Holidays.aspx");
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please Enter Holiday Name and Date.')</script>");
                }
            }

        }

        private bool duplicate_check(DateTime H_date1, List<DateTime> Hid)
        {
            var res = false;
            foreach (var holiday in Hid)
            {
                if (DateTime.Equals(H_date1, holiday))
                {
                    res = true;
                }

            }

            return res;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime H_date;
            //var xxsd = DateTime.TryParseExact(txtHdate1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out H_date);
            H_date = Convert.ToDateTime(txtHdate1.Text);
            query = "insert into holidays values('" + Utilities.convertQuotes(txtHname1.Text.Trim()) + "','" + H_date + "')";
            ds.RunCommand(query);
            ds.Close();
            load();
            Response.Redirect("~/Web/Holidays/Holidays.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Control chkRow = null;
            for (int jRow = 0; jRow < gvHolidays.Rows.Count; jRow++)
            {
                chkRow = gvHolidays.Rows[jRow].Cells[0].FindControl("chkRow");
                if (chkRow != null)
                {
                    if (((CheckBox)chkRow).Checked)
                    {
                        int HolidayId = (int)gvHolidays.DataKeys[jRow].Values["id"];
                        query = "delete holidays where id=" + HolidayId + "";
                        ds.RunCommand(query);
                        ds.Close();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please Select an Item to Delete.')</script>");
                    }
                }
            }
            Response.Redirect("~/Web/Holidays/Holidays.aspx");
            load();
        }
    }
}
