using LikeSchool.Helpers;
using LikeSchool.Modals;
using LikeSchool.Services.DB.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LikeSchool
{
    public partial class course : BaseSite
    {
        private SubjectCollection subjectCollection;
        private CourseCollection courseCollection;
        public SubjectCollection SubjectCollection
        {
            get
            {
                if (subjectCollection == null)
                    subjectCollection = new SubjectCollection();

                return subjectCollection;
            }
        }
        internal CourseCollection CourseCollection
        {
            get
            {
                if (courseCollection == null)
                    courseCollection = new CourseCollection();

                return courseCollection;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            BreadCrumb.HeaderText = "Course Manager";
            if (!Page.IsPostBack)
            {
                LoginIdField.Value = LoginModal.Id.ToString();
                LoginNameField.Value = LoginModal.UserName;
                RoleNameField.Value = IsAdmin.ToString();
                //UpdateCourses();
                //viewTab.InnerHtml = string.Empty;
                //viewTab.InnerHtml = GetCourseDetails();
                //subjectCollection = GetSubjects();
            }
        }

        protected SubjectCollection GetSubjects()
        {
            SubjectDB subjectDb=new SubjectDB();
            SubjectCollection collection = subjectDb.SelectDBWithoutSerialization();
            return collection;
        }
        
        protected void viewCourse_Click(object sender, EventArgs e)
        {
            UpdateCourses();
            //viewTab.InnerHtml = string.Empty;
            //viewTab.InnerHtml = GetCourseDetails();
        }

        protected void UpdateCourses()
        {
            CourseDB courseDb = new CourseDB();
            courseCollection = courseDb.SelectDBWithoutSerialization();
        }

        protected string GetCourseDetails()
        {
            var table = "<legend>Courses</legend><table cellpadding='0' cellspacing='0' border='0' class='table table-striped table-bordered sDataTable'>";
            table += "<thead>";
            table += "<tr>";
            table += "<th>Course Name</th>";
            table += "<th>No of Students</th>";
            table += "<th>View</th>";
            table += "<th>Edit</th>";
            table += "<th>Delete</th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";
            foreach (CourseModal modal in CourseCollection)
            {
                table += "<tr>";
                table += "<td>" + modal.CourseName + "</td>";
                table += "<td>" + modal.NoOfStudents + "</td>";
                table += "<td><a href='#'><i class='icon-eye-open icon-black'></i></a></td>";
                table += "<td><a href='#'><i class='icon-pencil icon-black'></i></a></td>";
                table += "<td><a href='#'><i class='icon-remove icon-black'></i></a></td>";
                table += "</tr>";
            }
            table += "</tbody>";
            table += "</table>";

            return table;
        }
        protected string GetSubjectDetails(SubjectCollection collection)
        {
            var table = "<legend>Subjects</legend><table cellpadding='0' cellspacing='0' border='0' class='table table-striped table-bordered sDataTable'>";
            table += "<thead>";
            table += "<tr>";
            table += "<th>Subject Name</th>";
            table += "<th>View</th>";
            table += "<th>Edit</th>";
            table += "<th>Delete</th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";
            foreach (SubjectModal modal in collection)
            {
                table += "<tr>";
                table += "<td>" + modal.SubjectName + "</td>";
                table += "<td><a href='#'><i class='icon-eye-open icon-black'></i></a></td>";
                table += "<td><a href='#'><i class='icon-pencil icon-black'></i></a></td>";
                table += "<td><a href='#'><i class='icon-remove icon-black'></i></a></td>";
                table += "</tr>";
            }
            table += "</tbody>";
            table += "</table>";

            return table;
        }
    }
}