using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bytepad_3._0.Models;
using Bytepad_3._0.Services;

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
        public PaperViewModel(IExamType Examtype, ISession session, IPaper paper, ISemester semester, ISubject subject)
        {
            _examType = Examtype;
            _session = session;
            _paper = paper;
            _semester = semester;
            _subject = subject;
        }
        public void RemovePaperBySession(int sessionId)
        {
            _paper.RemovePaperBySession(sessionId);
        }
        public void RemovePapersByExamTypeAndSession(int sessionId,int examTypeId)
        {
            _paper.RemovePapersByExamTypeAndSession(sessionId,examTypeId);
        }
        public List<PaperViewModel> getAllPapers()
        {
            List<PaperViewModel> showPapers = new List<PaperViewModel>();
            List<Paper> allPapers = _paper.GetAllPapers();
            foreach (var paper in allPapers)
            {
                showPapers.Add(new PaperViewModel(_examType, _session, _paper, _semester, _subject)
                {
                    PaperID = paper.Id,
                    PaperType = paper.PaperType,
                    Semester = _semester.GetSemesterTypeById(paper.SemesterType.ToString()),
                    ExamType = _examType.GetExamType(paper.ExamTypeId),
                    SubjectDetails = _subject.subjectDetailsById(paper.SubjectId),
                    Session = _session.GetSession(paper.SessionId),
                    FileUrl = paper.FileUrl
                });
            }
            return showPapers;
        }
        public List<PaperViewSession> getAll()
        {
            int sessionPaperCount;
            List<PaperViewSession> papers=new List<PaperViewSession>();
            foreach(var session in _session.GetAllSessions())
            {
                sessionPaperCount = 0;
                List<PaperViewExamType> paperViewExamTypes = new List<PaperViewExamType>();
                foreach(var examtype in _examType.GetAllExamTypes())
                {
                    PaperViewExamType paperviewExam = new PaperViewExamType {
                        ExamTypeId = examtype.Id,
                        ExamTypeName=examtype.Exam
                    };
                    List<Paper> paperList = _paper.getPapersBySessionAndExamType(session.Id,examtype.Id);
                    paperviewExam.Papers = paperList;
                    paperviewExam.Count = paperList.Count();
                    paperViewExamTypes.Add(paperviewExam);
                    sessionPaperCount += paperviewExam.Count;
                }
                PaperViewSession viewSession = new PaperViewSession {
                    SessionId=session.Id,
                    SessionName=session.EachSession,
                    examTypes =paperViewExamTypes,
                    Count=sessionPaperCount
                };
                papers.Add(viewSession);
            }
            return papers;
        }
    }
}