using System;
using System.Web;
using System.Web.UI;
using LikeSchool.Helpers;
using LikeSchool.Modals;

namespace LikeSchool
{
    public class BaseSite : Page
    {
        private ILoginTableModal loginModal;
               

        protected void SetJavaScriptFunction(string message)
        {
            ClientScript.RegisterStartupScript
       (GetType(), "Javascript", string.Format("javascript: {0}; ", message), true);
        }

        protected ILoginTableModal LoginModal
        {
            get
            {
                loginModal = Session[Constants.SessionLoginName] as ILoginTableModal;
                return loginModal;
            }
        }

        protected DateTime CurrentServerDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }

        protected bool IsAdmin
        {
            get
            {
                return HttpContext.Current.User.IsInRole(Constants.Administrator);
            }
        }

        protected bool IsClassTeacherOrPrincipal
        {
            get
            {
                return HttpContext.Current.User.IsInRole(Constants.ClassTeacher);
            }
        }

        protected bool IsTeacher
        {
            get{
                return HttpContext.Current.User.IsInRole(Constants.Teacher);
            }
        }

        protected bool IsStudent
        {
            get
            {
                return HttpContext.Current.User.IsInRole(Constants.Student);
            }
        }

        protected string GetRoleName()
        {
            if (IsAdmin)
                return Constants.Administrator;
            else if (IsClassTeacherOrPrincipal)
                return Constants.ClassTeacher;
            else if (IsTeacher)
                return Constants.Teacher;
            else if (IsStudent) 
                return Constants.Student;

            return string.Empty;
        }
      
	}

	
}