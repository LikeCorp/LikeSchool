using LikeSchool.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LikeSchool.Controls
{
    public partial class breadcrumb : System.Web.UI.UserControl
    {
        public string RootName = "Dashboard";
        public char directoryNameSpacer = '_';
        protected StringBuilder sbResult;
        private string _strHeaderText;
        public string HeaderText
        {
            get
            {
                return _strHeaderText;
            }
            set
            {
                _strHeaderText = value;
            }
        }
        public string BreadCrumbText
        {

            get
            {
                if (sbResult == null)
                    sbResult = new StringBuilder();

                return sbResult.ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateBreadCrumb();
        }

        protected void UpdateBreadCrumb()
        {
            sbResult = new StringBuilder();
            sbResult.Append("<ul class='breadcrumb'>");
            string strDomain = Page.Request.ServerVariables["HTTP_HOST"].ToString();
            strDomain.Trim();
            sbResult.Append("<li>");
            sbResult.Append("<a href='/index.aspx'>");
            sbResult.Append(RootName);
            sbResult.Append("</a>");
            sbResult.Append("<span class='divider'><i class='icon-chevron-right icon-black'></i></span>");
            sbResult.Append("</li>");
            string scriptName = Page.Request.ServerVariables["SCRIPT_NAME"].ToString();
            int lastSlash = scriptName.LastIndexOf('/');
            string pathOnly = scriptName.Remove(lastSlash, (scriptName.Length - lastSlash));
            if (pathOnly != string.Empty)
            {
                pathOnly = pathOnly.Substring(1);
                string[] strDirs = pathOnly.Split('/');
                int nNumDirs = strDirs.Length;
                for (int i = 0; i < strDirs.Length; i++)
                {
                    sbResult.Append("<li>");
                    sbResult.Append("<a href='" + Page.Request.ServerVariables["HTTP_REFERER"].ToString() + "'>");
                    sbResult.Append(HelperMethods.ToUpperCaseFirst(strDirs[i]));
                    sbResult.Append("</a>");
                    sbResult.Append("<span class='divider'><i class='icon-chevron-right icon-black'></i></span>");
                    sbResult.Append("</li>");
                }
            }
            sbResult.Append("<li class='active'>");
            sbResult.Append(HeaderText);
            sbResult.Append("</li>");
            sbResult.Append("</ul>");
        }
    }
}