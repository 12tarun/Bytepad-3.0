using Bytepad_3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Services
{
    public class PaperViewExamType
    {
        public int ExamTypeId { get; set; }
        public int Count { get; set; }
        public string ExamTypeName { get; set; }
        public List<Paper> Papers { get; set; }
    }
}