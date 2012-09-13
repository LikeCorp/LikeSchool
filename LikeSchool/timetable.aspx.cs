using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LikeSchool
{
    public partial class timetable : BaseSite
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BreadCrumb.HeaderText = "Time Table";
        }
    }
}