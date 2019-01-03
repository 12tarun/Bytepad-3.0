using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;

namespace Bytepad_3._0.Models
{
    public class FillPaper : IFillPaper
    {
        private ISubject _subject = null;
        private IPaper _paper = null;
        private IExamType _examType = null;
        private ISession _session = null;
        private ISemester _semester = null;

        public FillPaper(ISubject subject, IPaper paper, IExamType  examType, ISession session, ISemester semester)
        {
            _subject = subject;
            _paper = paper;
            _examType = examType;
            _session = session;
            _semester = semester;
        }

        public void FilledPapers(Paper objPaper, List<HttpPostedFileBase> ListOfPapers, out List<string> listOfRejectedFiles)
        {
            List<string> rejectedFiles = new List<string>();
            try
            {
                foreach (HttpPostedFileBase item in ListOfPapers)
                {
                    // Filling subject table with new subjects

                    string[] inputFileNames = item.FileName.Split('/');
                    _subject.SubjectName = inputFileNames[1].ToString().ToLower();
                    if (_subject.SubjectName != null)
                    {
                        _subject.SubjectName = _subject.SubjectName.Replace(@".DOCX", "");
                        _subject.SubjectName = _subject.SubjectName.Replace(@".docx", "");
                        _subject.SubjectName = _subject.SubjectName.Replace(@".DOC", "");
                        _subject.SubjectName = _subject.SubjectName.Replace(@".doc", "");
                        _subject.SubjectName = _subject.SubjectName.Replace(@".RTF", "");
                        _subject.SubjectName = _subject.SubjectName.Replace(@".rtf", "");
                        _subject.SubjectName = _subject.SubjectName.Replace(@".PDF", "");
                        _subject.SubjectName = _subject.SubjectName.Replace(@".pdf", "");
                    }
                    int subjectId = _subject.FindSubject(_subject);
                    
                    if (subjectId == (-1))
                    {
                        subjectId = _subject.AddSubjects(_subject);
                    }

                    // Creating paper type and file url and then filling paper table with new papers. Store all files in Papers folder in project too.

                    if(item.FileName.Contains("Solution") || item.FileName.Contains("solution") || item.FileName.Contains("SOLUTION"))
                    {
                        objPaper.PaperType = "Solution";
                    }
                    else
                    {
                        objPaper.PaperType = "Question";
                    }

                    string a = _examType.GetExamType(objPaper.ExamTypeId);
                    string b = _session.GetSession(objPaper.SessionId);
                    string c = _semester.GetSemesterTypeById(objPaper.SemesterType.ToString());

                    string fileUrl = $"{a}/{b}/{c}/{item.FileName}";

                    bool findPaperByFileUrl = _paper.FindPaper(fileUrl);
                    if(findPaperByFileUrl == true)
                    {
                        rejectedFiles.Add(item.FileName);
                    }
                    else
                    {
                        _paper.SubjectId = subjectId;
                        _paper.AdminId = 1;
                        _paper.ExamTypeId = objPaper.ExamTypeId;
                        _paper.SessionId = objPaper.SessionId;
                        _paper.SemesterType = objPaper.SemesterType;
                        _paper.PaperType = objPaper.PaperType;
                        _paper.FileUrl = fileUrl;
                        _paper.AddPaper(_paper);

                        string path = HttpContext.Current.Server.MapPath("~/Papers/" + a + "/" + b + "/" + c + "/" + inputFileNames[0].ToLower());
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string finalPath = HttpContext.Current.Server.MapPath("~/Papers/" + a + "/" + b + "/" + c + "/" + inputFileNames[0].ToLower() + "/" + inputFileNames[1].ToLower());
                        item.SaveAs(finalPath);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            listOfRejectedFiles = rejectedFiles;
        }
    }
}