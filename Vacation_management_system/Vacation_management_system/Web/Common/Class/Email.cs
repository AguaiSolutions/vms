using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
//using System.Web.HttpContext;
using System.Xml;
using Aguai_Leave_Management_System;
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;



namespace Vacation_management_system.Web.Common.Class
{
    public class Email
    {
        public bool SendRegistrationEmail(string employee_name, string email, string employee_No, string password )
        {
         try
            {
                var message = new MailMessage();
                //message.From = new MailAddress("vmsadmin@aguaisolutions.com");
                message.To.Add(email);
                message.IsBodyHtml = true;
                string subject, body;
               
                //GetMailBodyForNewUser(out subject, out body);

                GetMailBodyForNewUser("~/Web/Common/MailTemplate/RegisterEmployee.xml", out subject, out body);
                body = body.Replace("$$username$$", employee_name);
                body = body.Replace("$$EmpNo$$", employee_No);
                body = body.Replace("$$Official_Email$$", email);
                body = body.Replace("$$Password$$", password);
                message.Subject = subject;
                message.Body = body;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(message);
                return true;
        }
        catch (Exception ex)
        {
            return false;
            //Response.Write(ex.Message);
        }        
       
     }

        public bool VacationRequestEmail(string manager_name, string manager_email, string username, string fromdate, string todate, string leaves, string reason, string url)
        {
            try
            {
                var message = new MailMessage();
                //message.From = new MailAddress("vmsadmin@aguaisolutions.com");
                message.To.Add(manager_email);
                message.IsBodyHtml = true;
                string subject, body;
                
                //GetMailBodyForNewUser(out subject, out body);
               GetMailBodyForNewUser("~/Web/Common/MailTemplate/ApplyVacationMail.xml", out subject, out body);
                body = body.Replace("$$Employee Name$$",username);
                body = body.Replace("$$Manager Name$$", manager_name);
                body = body.Replace("$$fromdate$$", fromdate);
                body = body.Replace("$$todate$$", todate);
                body = body.Replace("$$leaves$$", leaves);
                body = body.Replace("$$reason$$", reason);
                body = body.Replace("$$host$$", url);
                subject = subject.Replace("$$Employee Name$$", username);
                message.Subject = subject;
                message.Body = body;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //Response.Write(ex.Message);
            }

        }



        public bool VacationRequestApprovedEmail(string manager_name, string username, string fromdate, string todate, string leaves, string user_email)
        {
            try
            {
                var message = new MailMessage();
                //message.From = new MailAddress("vmsadmin@aguaisolutions.com");
                message.To.Add(user_email);
                message.IsBodyHtml = true;
                string subject, body;

                //GetMailBodyForNewUser(out subject, out body);

                GetMailBodyForNewUser("~/Web/Common/MailTemplate/VacationApproved.xml", out subject, out body);
                body = body.Replace("$$Employee Name$$", username);
                body = body.Replace("$$Manager Name$$", manager_name);
                body = body.Replace("$$fromdate$$", fromdate);
                body = body.Replace("$$todate$$", todate);
                body = body.Replace("$$leaves$$", leaves);
                //body = body.Replace("$$reason$$", reason);
                
                message.Subject = subject;
                message.Body = body;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //Response.Write(ex.Message);
            }

        }


        /// <summary>
        /// Gets subject and body of the New User Registration email.
        /// </summary>
        static void GetMailBodyForNewUser(string virtualXmlPath, out string subject, out string body)
        {
            //string filePath = HttpContext.Current.Server.MapPath("~/Templates/RegisterUserEmailTemplate.xml");
            string filePath = HttpContext.Current.Server.MapPath(virtualXmlPath);

            XmlDocument document = XmlHelper.GetXmlDocument(filePath);

            XmlNode messageNode = document.SelectSingleNode("/mail/subject");

            subject = messageNode != null ? messageNode.InnerText : "Hello There!";

            messageNode = document.SelectSingleNode("/mail/body");

            body = messageNode.InnerText;
        }



    }
}