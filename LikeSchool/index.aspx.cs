﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LikeSchool.Configuration;
using LikeSchool.Helpers;


namespace LikeSchool
{
    public partial class index : BaseSite
    {
        private string RoleName;
        public List<MenuElement> Elements;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                RoleName = GetRoleName();
                DashboardMenu menu = new DashboardMenu(RoleName);
                Elements = menu.Menus;
            }
        }
    }
}