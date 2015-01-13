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
using Vacation_management_system.Web.Common;

namespace Vacation_management_system.Web.Common.Class
{
    public class ApplyVacation
    {
        Database ds = new Database();
        private SqlDataReader _data;
        private string query;
        public double Countleave(DateTime Fromdate, DateTime Todate, DataTable weeklyoffdays, DataTable holidaylist)
        {
           
            int i;
            double leave = 0, diff, h = 0, w = 0;
            diff = Todate.ToOADate() - Fromdate.ToOADate() + 1;
            var thisYearRows = holidaylist.AsEnumerable().Where(r => r.Field<DateTime>("holiday_date") >= Fromdate && r.Field<DateTime>("holiday_date") <= Todate);
             
            for (i = 0; i < diff; i++)
            {
                //exclude holidays.
                if (thisYearRows.Any())
                {
                    int k = 0;
                    for (k = 0; k < thisYearRows.Count(); k++)
                    {
                        var result = thisYearRows.ElementAt(k);
                        var get = (DateTime)result.ItemArray[1];
                        if (0 == get.CompareTo(Fromdate))
                            h++;
                    }

                }

                //exclude weekends.
                foreach (DataRow row in weeklyoffdays.Rows)
                {
                    foreach (var weeklyoff in row.ItemArray)
                    {
                        if (weeklyoff.Equals(Convert.ToString(Fromdate.DayOfWeek)))
                            w++;
                    }
                }

                Fromdate = Fromdate.AddDays(1);
            }
            //while (0 != Fromdate.CompareTo(Todate));
            leave = diff - (w + h);
            return leave;
        }




        public bool checkholidaylist(DateTime todate, DataTable holidaylist, out int year)
        {
            year =todate.Year;
             var thisYearRows =holidaylist.AsEnumerable().Where(r => r.Field<DateTime>("holiday_date").Year >= todate.Year);
            if (thisYearRows.Any())
            {
                return true;
            }
            else
                return false;
        }


        public bool duplicate_check(DateTime from, DateTime to, Int32 userId)
        {
            SqlDataReader _data2;
            query = (" select from_date,to_date from leave_management where ( (from_date BETWEEN '" + from + "'and '" + to + "') or (to_date BETWEEN '" + from + "'and '" + to + "') or (from_date >='" + from + "'and to_date <='" + to + "' or from_date<='" + from + "' and to_date >='" + to + "' ))and emp_id=" + userId + "and approval_status !='c' and approval_status !='r'");
            ds.RunQuery(out _data2, query);
            if (_data2.HasRows == true)
            {
                _data2.Close();
                ds.Close();
                return false;

            }
            else
            {
                _data2.Close();
                ds.Close();
                return true;
            }
        }


        public void leavetype(DropDownList drpLeaveType)
        {
            query = "select * from leave_type";
            ds.RunQuery(out _data, query);
            while (_data.Read())
            {
                drpLeaveType.Items.Add(new ListItem(_data["leave_type"].ToString(), _data["id"].ToString()));
            }
            _data.Close();
            ds.Close();
        }

    }
}