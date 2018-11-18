using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Models
{
    public class FillPaper
    {
        private ISubject _subject = null;
        private IPaper _paper = null;

        public FillPaper(ISubject subject, IPaper paper)
        {
            _subject = subject;
            _paper = paper;
        }

        public bool filledPapers(Paper objPaper, List<HttpPostedFileBase> ListOfPapers, out List<string> listOfRejectedFiles)
        {
            try
            {
                foreach (HttpPostedFileBase item in ListOfPapers)
                {
                    // Filling subject table with new subjects

                    string[] inputFileNames = item.FileName.Split('/');
                    _subject.SubjectName = inputFileNames[1].ToString();
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
                    bool paperAlreadyPresent = _subject.FindSubject(_subject);
                    if (paperAlreadyPresent == false)
                    {
                        _subject.AddSubjects(_subject);
                    }

                    // Creating paper type and file url then filling paper table with new papers
                    
                    if(item.FileName.Contains("Solution") || item.FileName.Contains("solution") || item.FileName.Contains("SOLUTION"))
                    {
                        objPaper.PaperType = "Solution";
                    }
                    else
                    {
                        objPaper.PaperType = "Question";
                    }


                    _paper.SubjectId = _subject.Id;
                    _paper.ExamTypeId = objPaper.ExamTypeId;
                    _paper.SessionId = objPaper.SessionId;
                    _paper.SemesterType = objPaper.SemesterType;
                    _paper.PaperType = objPaper.PaperType;
                    // file url left..
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
    }
}