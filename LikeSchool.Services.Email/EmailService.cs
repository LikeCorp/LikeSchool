using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace LikeSchool.Services.Email
{
    public class EmailService
    {
        private const string ToMail = "likeschoolhelp@gmail.com";
        private const string ToMailPassword = "Thoughts1234@";
        private string fromMail;
        private EmailStructure content;
        private Attachment[] attachs;
        public EmailService(string fMail, EmailStructure cont, Attachment[] attachments)
        {
            fromMail = fMail;
            content = cont;
            attachs = attachments;
        }

        public bool SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(ToMail);
                mail.From = new MailAddress(fromMail);
                mail.Subject = content.Subject;
                mail.Body = content.Body;
                mail.IsBodyHtml = true;
                if ( attachs != null && attachs.Length > 0)
                {
                    foreach (Attachment attach in attachs)
                    {
                        mail.Attachments.Add(attach);
                    }
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential
                     (ToMail, ToMailPassword);               

                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}
