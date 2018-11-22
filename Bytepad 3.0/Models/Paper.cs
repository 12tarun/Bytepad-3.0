using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Models
{
    public class Paper : IPaper
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int SessionId { get; set; }
        public int SubjectId { get; set; }
        public int ExamTypeId { get; set; }
        public string SemesterType { get; set; }
        public string PaperType { get; set; }
        public string FileUrl { get; set; }
        public bool FindPaper(string fileUrl)
        {
            bool present = false;
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    var check = db.tblPapers.FirstOrDefault(data => data.FileUrl.Equals(fileUrl));
                    if (check != null)
                    {
                        present = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return present;
        }
        public void AddPaper(IPaper dataPaper)
        {
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    tblPaper dataTblPaper = new tblPaper
                    {
                        AdminId = 1,
                        SessionId = dataPaper.SessionId,
                        SubjectId = dataPaper.SubjectId,
                        ExamTypeId = dataPaper.ExamTypeId,
                        SemesterType = dataPaper.SemesterType,
                        PaperType = dataPaper.PaperType,
                        FileUrl = dataPaper.FileUrl
                    };
                    db.tblPapers.Add(dataTblPaper);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
        public List<Paper> FindPapersBySubjectId(int id)
        {
            List<Paper> PapersOfSameSubject = new List<Paper>();
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    foreach(var paper in db.tblPapers.ToList())
                    {
                        if(paper.SubjectId == id)
                        {
                            PapersOfSameSubject.Add(new Paper
                            {
                                Id = paper.Id,
                                AdminId = paper.AdminId,
                                SessionId = paper.SessionId,
                                SubjectId = paper.SubjectId,
                                ExamTypeId = paper.ExamTypeId,
                                SemesterType = paper.SemesterType,
                                PaperType = paper.PaperType,
                                FileUrl = paper.FileUrl
                            });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
            }
            return PapersOfSameSubject;
        }
    }
}