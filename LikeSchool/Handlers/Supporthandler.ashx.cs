using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Serialization;
using LikeSchool.Services.Email;

namespace LikeSchool.Handlers
{
    /// <summary>
    /// Summary description for supporthandler
    /// </summary>
    public class Supporthandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            bool returnValue = false;
            string email = context.Request.Form["email"];
            string severity = context.Request.Form["severity"];
            string schoolName = context.Request.Form["schoolname"];
            string shortDesc = context.Request.Form["short"];
            string desc = context.Request.Form["desc"];
            string filename=string.Empty;
            if(context.Request.Files.Count >0)
            {
                string path = context.Server.MapPath("~/Temp");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var file = context.Request.Files[0];
                filename = Path.Combine(path, file.FileName);
                file.SaveAs(filename);                                  
            }
            EmailStructure structure = new EmailStructure();
            string subject = string.Format("{0}-CustomerEmail:{1}-Severity:{2}", shortDesc, email, severity);
            structure.Subject = subject;
            string body = string.Format("<span>Hi Team,</span><br/><br/><span><strong>SchoolName:</strong>{0}</span><br/><br/><strong>Issue:</strong><p>{1}</p><br/><span>Thanks,</span><br/><span>LikeCorpTeam.</span>", schoolName, desc);
            structure.Body = body;
            Attachment[] attach= null;
            if (filename != string.Empty)
            {
                attach = new Attachment[] { new Attachment(filename) };
            }
            EmailService service = new EmailService(email, structure, attach);
            if (service.SendMail())
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
            }

            context.Response.ContentType = "text/plain";
            var serializer = new JavaScriptSerializer();
            var result = new { result = returnValue.ToString() };
            context.Response.Write(serializer.Serialize(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}