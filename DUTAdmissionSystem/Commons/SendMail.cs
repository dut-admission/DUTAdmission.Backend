using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace DUTAdmissionSystem.Commons
{
    public class SendMail
    {
        public static bool Send(string toEmail, string body, string Subject)
        {
            try
            {
                HeThong heThong = new HeThong();
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.EnableSsl = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(
                    heThong.Email,
                    heThong.Matkhau);
                var msg = new MailMessage
                {
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8,
                    From = new MailAddress(
                        heThong.Email),
                    Subject = Subject,
                    Body = body,
                    Priority = MailPriority.Normal,
                };
                msg.To.Add(toEmail);
                smtpClient.Send(msg);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}