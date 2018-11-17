using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Models
{
    public class Paper
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int SessionId { get; set; }
        public int SubjectId { get; set; }
        public int ExamTypeId { get; set; }
        public string SemesterType { get; set; }
        public string PaperType { get; set; }
        public string FileUrl { get; set; }
    }
}