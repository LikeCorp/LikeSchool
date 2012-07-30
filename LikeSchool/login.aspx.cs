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

        }

        private void SetJavaScriptFunction(string message)
        {
            ClientScript.RegisterStartupScript
       (GetType(), "Javascript", string.Format("javascript: {0}; ", message), true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = user.Value;
            string password = pass.Value;
            if (userName == string.Empty)
            {
                SetJavaScriptFunction("fnValidateUser()");
            }
            else if (password == string.Empty)
            {
                SetJavaScriptFunction("fnValidatePass()");
            }
            else
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                LoginTableModal userDetails = serializer.Deserialize<LoginTableModal>(LoginDB.SelectLoginTable(userName, password));
                if (userDetails != null)
                {
                    SetJavaScriptFunction("fnHideMessage()");
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
                    SetJavaScriptFunction("fnShowMessage()");
                }
            }
        }
    }

}