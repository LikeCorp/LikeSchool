using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LikeSchool.Helpers;

namespace LikeSchool
{
    public partial class mainpage : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdatePageTitle();
        }
        private void UpdatePageTitle()
        {
            string path = HelperMethods.GetSubString("/", ".", HttpContext.Current.Request.Url.PathAndQuery);
            string title = string.Empty;
            switch (path.ToLower())
            {
                case "index":
                    title = Constants.DashBoard;
                    break;
                case "attendance":
                    title = Constants.Attendance;
                    break;
                case "timetable":
                    title = Constants.TimeTable;
                    break;
                case "leave":
                    title = Constants.Leave;
                    break;
                case "settings":
                    title = Constants.Settings;
                    break;
                case "calendar":
                    title = Constants.Calendar;
                    break;
            }
            Page.Header.Title = string.Format(Constants.TitlePrefix, title);
        }

    }
}