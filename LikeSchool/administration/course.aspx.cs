using LikeSchool.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LikeSchool
{
    public partial class course : BaseSite
    {
        private SubjectCollection subjectCollection;
        public SubjectCollection SubjectCollection
        {
            get
            {
                if (subjectCollection == null)
                    subjectCollection = new SubjectCollection();

                return subjectCollection;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BreadCrumb.HeaderText = "Course Manager";
                SubjectCollection.Add(new Modals.SubjectModal() { SubjectName = "Hindi" });
                SubjectCollection.Add(new Modals.SubjectModal() { SubjectName = "English" });
                SubjectCollection.Add(new Modals.SubjectModal() { SubjectName = "Tamil" });
                SubjectCollection.Add(new Modals.SubjectModal() { SubjectName = "Physics" });
                SubjectCollection.Add(new Modals.SubjectModal() { SubjectName = "Chemistry" });
                SubjectCollection.Add(new Modals.SubjectModal() { SubjectName = "Botany" });
                SubjectCollection.Add(new Modals.SubjectModal() { SubjectName = "Zoology" });
            }
        }
    }
}