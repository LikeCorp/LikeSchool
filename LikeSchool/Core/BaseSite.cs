using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LikeSchool
{
    public class BaseSite : Page
    {
        protected override void OnLoad(EventArgs e)
        {            
            base.OnLoad(e);
        }

        protected void SetJavaScriptFunction(string message)
        {
            ClientScript.RegisterStartupScript
       (GetType(), "Javascript", string.Format("javascript: {0}; ", message), true);
        }

        protected bool IsAdmin
        {
            get
            {
                return HttpContext.Current.User.IsInRole("admin");
            }
        }

    }
}