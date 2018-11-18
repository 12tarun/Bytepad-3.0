using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Models
{
    public class FillPaper : Paper
    {
        private ISubject _subject = null;
        public FillPaper(ISubject subject)
        {
            _subject = subject;
        }
        public bool filledPapers(Paper objPaper, List<HttpPostedFileBase> ListOfPapers, out List<string> listOfRejectedFiles)
        {
            try
            {
                foreach (var item in ListOfPapers)
                {
                    _subject.SubjectName = item.FileName;
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
                    // create url of subject and add paperurl to db along with paper type
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
    }
}