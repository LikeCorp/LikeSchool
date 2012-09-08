using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LikeSchool.Configuration;
using LikeSchool.Helpers;

namespace LikeSchool
{
    public partial class administration : BaseSite
    {
        private int menuid;
        private string RoleName;
        public List<MenuElement> submenus;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                menuid = Convert.ToInt32(Request.QueryString["id"]);
                RoleName = GetRoleName();
                DashboardMenu menu = new DashboardMenu(RoleName);
                MenuElement mainMenu= menu.GetMenu(menuid);
                submenus = menu.GetSubMenus(mainMenu);
            }
        }
    }
}