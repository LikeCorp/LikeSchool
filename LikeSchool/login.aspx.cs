using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
            JavaScriptSerializer serializer=new JavaScriptSerializer();
            LoginTableModal userDetails = serializer.Deserialize<LoginTableModal>(LoginDB.SelectLoginTable(userName, password));
            
        }
    }
}