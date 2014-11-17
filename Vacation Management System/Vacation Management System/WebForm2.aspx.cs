using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aguai_Leave_Management_System
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string message = "Hello! Mudassar.";
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("<script type = 'text/javascript'>");
            //sb.Append("window.onload=function(){");
            //sb.Append("alert('");
            //sb.Append(message);bb
            //sb.Append("')};");
            //sb.Append("</script>");
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //string cmd = "SELECT  L.id,E.emp_id,E.first_name,L.from_date,L.to_date,L.description,leave_type.leave_type as Type,T.Approver,'approval_status'= CASE L.approval_status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' then 'Cancel' END,L.reason FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id  left join (select ID,first_name as Approver from employee where role_id = 1) as T on T.id = L.approver_id where";

            //string conjuction = " ";
            //if (!(string.IsNullOrWhiteSpace(this.TextBox1.Text)))
            //{
            //    cmd += conjuction;
            //    cmd += " " + "first_name like" + " " + "'%" + TextBox1.Text + "%'";
            //    conjuction = " OR ";

            //}

            //if (!(string.IsNullOrWhiteSpace(this.TextBox2.Text)))
            //{
            //    cmd += conjuction;
            //    cmd += " " + "E.emp_id like" + " " + "'%" + TextBox2.Text + "%'";
            //    conjuction = " OR ";
            //}

            //if (!(string.IsNullOrWhiteSpace(this.TextBox3.Text)))
            //{
            //    cmd += conjuction;
            //    cmd += " " + "leave_type.leave_type like" + " " + "'%" + TextBox3.Text + "%'";
            //    conjuction = " OR ";

            //}



            //if (!((string.IsNullOrWhiteSpace(this.TextBox4.Text)) && (string.IsNullOrWhiteSpace(this.TextBox5.Text))))
            //{
            //    cmd += conjuction;
            //    cmd += " " + "L.from_date >= " + " '" + TextBox4.Text + "'AND";
            //    cmd += " " + "L.to_date <= '" + TextBox5.Text + "'";
            //    conjuction = " OR ";
            //}

            //var c = cmd;
        }


        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}