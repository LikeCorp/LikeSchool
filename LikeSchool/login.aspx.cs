using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using LikeSchool.Services.DB.Modals;
using LikeSchool.Services.DB.Services;

namespace LikeSchool
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.loginBtn.ServerClick += login_ServerClick;
        }

        void login_ServerClick(object sender, EventArgs e)
        {
            var userName = user.Value;
            var password = pass.Value;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            LoginTableModal userDetails = serializer.Deserialize<LoginTableModal>(LoginDB.SelectLoginTable(userName, password));
            if (userDetails != null)
            {
                RemoveJavaScriptError();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(50), rememberCheckbox.Checked, userDetails.Roles, FormsAuthentication.FormsCookiePath);
                string hashCookies = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies);
                Response.Cookies.Add(cookie);
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null) returnUrl = "~/index.aspx";
                Response.Redirect(returnUrl);
            }
            else
            {
                user.Value = string.Empty;
                pass.Value = string.Empty;
                rememberCheckbox.Checked = false;
                SetJavaScriptError();
            }
        }

        private void SetJavaScriptError()
        {
            ClientScript.RegisterStartupScript
       (GetType(), "Javascript", "javascript: fnShowMessage(); ", true);
        }
        private void RemoveJavaScriptError()
        {
            ClientScript.RegisterStartupScript
           (GetType(), "Javascript", "javascript: fnHideMessage(); ", true);
        }
    }

}