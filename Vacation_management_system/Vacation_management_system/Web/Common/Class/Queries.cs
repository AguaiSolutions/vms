using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Aguai_Leave_Management_System;

namespace Vacation_management_system.Web.Common.Class
{
    public class Queries
    {

        public bool updateEmployeeLeaves(Int32 user_id, double current_year_vacation = 0, double previous_year_vacation = 0)
        {
            Database ds = new Database();

            string _query;
            _query = "update employee_configuration set";
            {
                if (previous_year_vacation != 0 && current_year_vacation == 0)
                {
                    _query += "  previous_year_leaves= " + previous_year_vacation;

                }
                else
                    if (previous_year_vacation < 0 && current_year_vacation != 0)
                    {
                        previous_year_vacation = 0;
                        _query += " previous_year_leaves= " + previous_year_vacation;
                        _query += ",";
                        _query = _query + " current_year_leaves= " + current_year_vacation;
                    }
                    else
                    {
                        _query = _query + " current_year_leaves= " + current_year_vacation;
                    }

                _query += " where emp_id=" + user_id + " ";
                var res = ds.RunCommand(_query);
                return res;
            }
        }
        public void employees_leave_balance(out double remaining_leaves, out double current_year_vacations, out double previous_year_vacations, Int32 user_id)
        {
            string _query;

            SqlDataReader _data;

            Database ds = new Database();

            remaining_leaves = current_year_vacations = previous_year_vacations = 0;
            _query = "select remaining_leaves,current_year_leaves,previous_year_leaves FROM employee_configuration where emp_id= " + user_id + "";
            ds.RunQuery(out _data, _query);

            while (_data.Read())
            {
                remaining_leaves = Convert.ToDouble(_data["remaining_leaves"]);
                current_year_vacations = Convert.ToDouble(_data["current_year_leaves"]);
                previous_year_vacations = Convert.ToDouble(_data["previous_year_leaves"]);

            }
            _data.Close();
            ds.Close();
        }

        public static bool Statusupdate(char status, int leaveId, string reason = "")
        {
            Database ds = new Database();

            string query = "Update [dbo].[leave_management] set approval_status='" + status + "',reason='" + reason + "'where id=" + leaveId;

            var run = ds.RunCommand(query);

            return run;
        }

        public static void GetDetails(int empid,out string emp_name,out string mail)
        {
            emp_name = null;
            mail = null;
            Database ds = new Database();

            SqlDataReader _data;

            string query = "select first_name,last_name,official_email from employee where id ="+empid;

            ds.RunQuery(out _data, query);

            while(_data.Read())
            {
               emp_name= (_data["first_name"] + " " + _data["last_name"]).ToString();
                mail = _data["official_email"].ToString();
            }


        }

        //public bool Cancelleaves(double previousYearLeaves, double leaves,int empId)
        //{
        //    string query = "update employee_configuration set";

        //    if (previousYearLeaves > 0)
        //    {
        //        query +=" previous_year_leaves = previous_year_leaves+" + leaves;
        //    }
        //    else
        //    {
        //        query += "current_year_leaves = current_year_leaves+" + leaves;
        //    }

        //    query+= " where emp_id =" +empId;

        //    Database db = new Database();

        //    var res = db.RunCommand(query);

        //    return res;
        //}
    }
}