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
                query = "SELECT  id,holiday_name,CONVERT(varchar,holiday_date,103)as holiday_date,isRH from holidays";
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
                Response.Redirect("~/Login.aspx");
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
            // Update
            int id = Convert.ToInt32(gvHolidays.DataKeys[e.RowIndex].Values["id"]);
            
            TextBox holiday_name = (TextBox)gvHolidays.Rows[e.RowIndex].FindControl("txtName");
            TextBox holiday_date = (TextBox)(gvHolidays.Rows[e.RowIndex].FindControl("txtHolidayDate"));
            Label holiday_date1 = (Label)(gvHolidays.Rows[e.RowIndex].FindControl("lblDate"));
            CheckBox chkRow1 = (CheckBox)gvHolidays.Rows[e.RowIndex].FindControl("chkRow1");

            if (!(holiday_name.Text.Equals("") || holiday_date.Text.Equals("")))
            {
                DateTime H_date;
                DateTime.TryParseExact(holiday_date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out H_date);
                    var duplicate1 = duplicate_check(H_date, GetHolidayList(id));
                    if (duplicate1 == true)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('You have entered an existing holiday.')</script>");
                    }
                    else
                    {
                        if (chkRow1.Checked == true)
                        {
                            query = "update holidays set holiday_name='" + holiday_name.Text + "',holiday_date='" + H_date + "',isRH=1 where id=" + id + "";
                            chkRow1.Enabled = false;
                        }
                        else
                        {
                            query = "update holidays set holiday_name='" + holiday_name.Text + "',holiday_date='" + H_date + "',isRH=0 where id=" + id + "";
                        }
                        
                        ds.RunCommand(query);
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Holidays Updated Successfully.')</script>");
                        ds.Close();
                        load();
                        Response.Redirect("~/Web/Holidays/Holidays.aspx");
                    }

                gvHolidays.EditIndex = -1;
                load();

            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Holiday Name and Date should not be empty.')</script>");
            }
        }

        private List<DateTime> GetHolidayList(int id)
        {
            holidayDates = new List<DateTime>();

            query = "SELECT id,holiday_date from holidays";
            ds.RunQuery(out _data2, query);
            while (_data2.Read())
            {
                if (Convert.ToInt32(_data2["id"]) != id && _data2["id"]!=null)
                {
                    holidayDates.Add(Convert.ToDateTime(_data2["holiday_date"]));
                }
            }
            _data2.Close();
            ds.Close();

            return holidayDates;
        }

        protected void gvHolidays_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHolidays.EditIndex = -1;
            load();
        }

        protected void gvHolidays_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //New Holiday
            if (e.CommandName.Equals("Insert"))
            {

                TextBox name = (TextBox)gvHolidays.FooterRow.FindControl("txtHname3");
                TextBox date = (TextBox)gvHolidays.FooterRow.FindControl("txtHdate3");
                CheckBox chkRow2 = (CheckBox)gvHolidays.FooterRow.FindControl("chkRow2");
                if (!(name.Text.Equals("") || date.Text.Equals("")))
                {
                    DateTime H_date1;
                    DateTime.TryParseExact(date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out H_date1);
               
                    var duplicate1 = duplicate_check(H_date1, GetHolidaydates());
                    if (duplicate1 == true)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('You have entered an existing holiday.')</script>");
                    }
                    else
                    {
                        if (chkRow2.Checked == true)
                        {
                            query = "insert into holidays(holiday_name,holiday_date,isRH) values('" + Utilities.convertQuotes(name.Text.Trim()) + "','" + H_date1 + "',1)";
                        }
                        else
                        {
                            query = "insert into holidays(holiday_name,holiday_date) values('" + Utilities.convertQuotes(name.Text.Trim()) + "','" + H_date1 + "')";
                        }

                        ds.RunCommand(query);
                        ds.Close();


                        string query2 = "select holiday_name, holiday_date from holidays where isRH=0 order by holiday_date ";
                        Database ob2 = new Database();
                        SqlDataReader data2;
                        ob2.RunQuery(out data2, query2);
                        DataTable holiday = new DataTable();
                        holiday.Load(data2);
                        Session["holiday"] = holiday;
                        data2.Close();
                        ob2.Close();


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

        //private bool duplicate_check1(DateTime H_date1, List<DateTime> Hid)
        //{
        //    var res = false;
        //    foreach (var holiday in Hid)
        //    {
        //            if (DateTime.Equals(H_date1, holiday))
        //            {
        //                res = true;
        //            }
        //    }
        //    return res;
        //}

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
            if (!(txtHname1.Text.Equals("") || txtHdate1.Text.Equals("")))
            {
                DateTime H_date;
                var xxsd = DateTime.TryParseExact(txtHdate1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out H_date);

                if (!xxsd)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please Enter valid Holiday Date.')</script>");
                    return;
                }

              //  H_date = Convert.ToDateTime(xxsd);
                query = "insert into holidays (holiday_name,holiday_date) values('" + Utilities.convertQuotes(txtHname1.Text.Trim()) + "','" + H_date + "')";
                ds.RunCommand(query);
                ds.Close();

                string query2 = "select holiday_name, holiday_date from holidays where isRH=0 order by holiday_date ";
                Database ob2 = new Database();
                SqlDataReader data2;
                ob2.RunQuery(out data2, query2);
                DataTable holiday = new DataTable();
                holiday.Load(data2);
                Session["holiday"] = holiday;
                data2.Close();
                ob2.Close();

                load();
                Response.Redirect("~/Web/Holidays/Holidays.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please Enter Holiday Name and Date.')</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Control chkRow;
            for (int jRow = 0; jRow < gvHolidays.Rows.Count; jRow++)
            {
                chkRow = gvHolidays.Rows[jRow].Cells[0].FindControl("chkRow");

                if (((CheckBox)chkRow).Checked)
                {
                    int HolidayId = (int)gvHolidays.DataKeys[jRow].Values["id"];
                    query = "delete holidays where id=" + HolidayId + "";
                    ds.RunCommand(query);
                    ds.Close();
                }
                //else
                //{
                //    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please select an Holiday record to Delete.')</script>");
                //}
            }
            Response.Redirect("~/Web/Holidays/Holidays.aspx");
            load();
        }
    }
}
