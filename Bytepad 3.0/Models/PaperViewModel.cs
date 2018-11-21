using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bytepad_3._0.dbClashFiles;
using Bytepad_3._0.Models;
namespace Bytepad_3._0
{
    public class PaperViewModel : IPaperViewModel
    {
        public int PaperID { get; set; }
        public string SubjectDetails { get; set; }
        public string ExamType { get; set; }
        public string Semester { get; set; }
        public string Session { get; set; }
        public string PaperType { get; set; }

        IExamType _examType = null;
        ISession _session = null;
        public PaperViewModel(IExamType Examtype, ISession session)
        {
            _examType = Examtype;
            _session = session;
        }
        public List<PaperViewModel> getAllPapers()
        {
            List<PaperViewModel> showPapers = new List<PaperViewModel>();
            using (BytepadDBEntities db = new BytepadDBEntities())
            {
                List<tblPaper> allPapers = db.tblPapers.ToList();
                foreach (var paper in allPapers)
                {
                    PaperViewModel tempPaper = new PaperViewModel(_examType, _session);//because objects will be required for object creation
                    tempPaper.PaperID = paper.Id;
                    tempPaper.PaperType = paper.PaperType;
                    tempPaper.Semester = getSemesterTypeById(paper.SemesterType);
                    tempPaper.ExamType = _examType.GetExamType(paper.ExamTypeId);
                    tempPaper.Session = _session.GetSession(paper.SessionId);
                    showPapers.Add(tempPaper);
                }
            }
            return showPapers;
        }
        private string getSemesterTypeById(string id)
        {
            if (id == "1")
            {
                return "Even Semester";
            }
            else//id="2"
            {
                return "Odd Semester";
            }

        }

    }
}