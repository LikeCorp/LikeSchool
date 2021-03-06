﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Modals
{
   public class CourseModal : ICourseModal
    {
       public string CourseName { get; set; }
       public int CouserId { get; set; }
       public int NoOfStudents { get; set; }
       public string SubjectIds { get; set; }
       public IUpdaterDetailTableModal UpdateModal { get; set; }
    }
}
