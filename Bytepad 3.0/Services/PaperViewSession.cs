using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Services
{
    public class PaperViewSession 
    {
        public int SessionId { get; set; }
        public int Count { get; set; }
        public string SessionName { get; set; }
        public List<PaperViewExamType> examTypes { get; set; }
    }
}