using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LikeSchool.Configuration;

namespace LikeSchool.Helpers
{
    public class DashboardMenu
    {
        private DashboardConfiguration config;
        private string roleName;
        private List<MenuElement> elements;
        public DashboardMenu(string rName)
        {
            roleName = rName;
            config = DashboardConfiguration.GetConfig();
            elements = GetSortedList();
        }
        public List<MenuElement> Menus
        {
            get
            {
                return elements;
            }
        }
        public List<MenuElement> GetSubMenus(MenuElement element)
        {
            List<MenuElement> submenus = new List<MenuElement>();
            foreach (MenuElement m in config.DashboardCollection)
            {
                if ((m.RoleType == "general" || m.RoleType == roleName) && m.HighLevelId == element.Id)
                {
                    submenus.Add(m);
                }
            }
            return submenus;
        }
        protected List<MenuElement> GetSortedList()
        {
            List<MenuElement> menus = new List<MenuElement>();
            foreach (MenuElement m in config.DashboardCollection)
            {
                if ((m.RoleType == "general" || m.RoleType == roleName) && m.IsHigherLevel)
                {
                    menus.Add(m);
                }
            }
            return menus;
        }
        public MenuElement GetMenu(int id)
        {
            return (from m in elements where m.Id == id select m).FirstOrDefault<MenuElement>();
        }
    }
}
