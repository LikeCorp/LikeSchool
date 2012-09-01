using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LikeSchool
{
    public partial class logout : BaseSite
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.User = null;
            Response.Redirect("~/login.aspx");
        }
    }
}