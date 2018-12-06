using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public string FileUrl { get; set; }

        private IExamType _examType = null;
        private ISession _session = null;
        private IPaper _paper = null;
        private ISemester _semester = null;
        private ISubject _subject = null;
        public PaperViewModel(IExamType Examtype, ISession session, IPaper paper, ISemester semester,ISubject subject)
        {
            _examType = Examtype;
            _session = session;
            _paper = paper;
            _semester = semester;
            _subject = subject;
        }

        public List<PaperViewModel> getAllPapers()
        {
            List<PaperViewModel> showPapers = new List<PaperViewModel>();
            List<Paper> allPapers = _paper.GetAllPapers();
            foreach (var paper in allPapers)
            {
                showPapers.Add(new PaperViewModel(_examType, _session, _paper, _semester,_subject)
                {
                    PaperID = paper.Id,
                    PaperType = paper.PaperType,
                    Semester = _semester.GetSemesterTypeById(paper.SemesterType),
                    ExamType = _examType.GetExamType(paper.ExamTypeId),
                    SubjectDetails = _subject.subjectDetailsById(paper.SubjectId),
                    Session = _session.GetSession(paper.SessionId),
                    FileUrl = paper.FileUrl
                });
            }
            return showPapers;
        }
    }
}