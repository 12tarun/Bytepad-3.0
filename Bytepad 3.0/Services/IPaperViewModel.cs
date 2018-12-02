using System.Collections.Generic;

namespace Bytepad_3._0
{
    public interface IPaperViewModel
    {
        string ExamType { get; set; }
        int PaperID { get; set; }
        string PaperType { get; set; }
        string Semester { get; set; }
        string Session { get; set; }
        string SubjectDetails { get; set; }
        string FileUrl{ get; set; }
        List<PaperViewModel> getAllPapers();
    }
}