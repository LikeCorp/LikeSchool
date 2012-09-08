using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LikeSchool
{
    public partial class calendar : BaseSite
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoginIdField.Value = LoginModal.Id.ToString();
                LoginNameField.Value = LoginModal.UserName;
                RoleNameField.Value = IsAdmin.ToString();
            }
        }
    }
}