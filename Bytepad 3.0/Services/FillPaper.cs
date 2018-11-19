using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Bytepad_3._0.Models
{
    public class FillPaper : IFillPaper
    {
        private ISubject _subject = null;
        private IPaper _paper = null;

        public FillPaper(ISubject subject, IPaper paper)
        {
            _subject = subject;
            _paper = paper;
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
                    int subjectId = _subject.FindSubject(_subject);
                    
                    if (subjectId == (-1))
                    {
                        subjectId = _subject.AddSubjects(_subject);
                    }

                    // Creating paper type and file url and then filling paper table with new papers. Store all files in PaperFileUpload in project too.

                    if(item.FileName.Contains("Solution") || item.FileName.Contains("solution") || item.FileName.Contains("SOLUTION"))
                    {
                        objPaper.PaperType = "Solution";
                    }
                    else
                    {
                        objPaper.PaperType = "Question";
                    }

                    string fileUrl = $"{objPaper.SessionId.ToString()}/{objPaper.SemesterType.ToString()}/{item.FileName}";
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





                        // something wrong here.. saare papers store nahi ho rahe..




                        string path =
                            HttpContext.Current.Server.MapPath
                            ("~/PaperFileUpload/" + _paper.GetExamTypeOfPaper(_paper.ExamTypeId) + "/" + _paper.GetSessionOfPaper(_paper.SessionId) + "/" + _paper.SemesterType + "/" + inputFileNames[0]);

                        if(!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        string finalPath =
                            HttpContext.Current.Server.MapPath
                            ("~/PaperFileUpload/" + _paper.GetExamTypeOfPaper(_paper.ExamTypeId) + "/" + _paper.GetSessionOfPaper(_paper.SessionId) + "/" + _paper.SemesterType + "/" + inputFileNames[0] + "/" + inputFileNames[1]);

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