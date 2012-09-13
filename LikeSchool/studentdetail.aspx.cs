using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using LikeSchool.Modals;
using LikeSchool.Services.DB.Services;


namespace LikeSchool
{
    public partial class StudentDetail : BaseSite
    {
        public string admissionNo;
        private string batchId;
        public IStudentTableModal StudentModal;

        protected void Page_Load(object sender, EventArgs e)
        {
            BreadCrumb.HeaderText = "Student Detail";
            var adQuery = Request.QueryString["adno"];
            var batchQuery = Request.QueryString["bno"];
            var sessionAd = Session["adno"];
            var sessionBatch = Session["bno"];
            if (adQuery == null && sessionAd == null && batchQuery == null && sessionBatch == null)
                Response.Redirect("~/searchstudent.aspx");
            else if (adQuery != null && batchQuery != null)
            {
                Session["adno"] = admissionNo = adQuery;
                Session["bno"] = batchId = batchQuery;
            }
            else
            {
                admissionNo = Session["adno"].ToString();
                batchId = Session["bno"].ToString();
            }
            GetStudentDetails();
        }

        protected void GetStudentDetails()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StudentTableDB studDb = new StudentTableDB();
            StudentModal = studDb.SelectStudentData(Convert.ToInt32(admissionNo),Convert.ToInt32(batchId));
        }

    }
}