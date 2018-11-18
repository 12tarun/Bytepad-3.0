using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Models
{
    public class Subject : ISubject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public List<Subject> GetAllSubjects()
        {
            List<Subject> dataSubject = new List<Subject>();
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    List<tblSubject> dataTblSubject = new List<tblSubject>();
                    dataTblSubject = db.tblSubjects.ToList();
                    foreach(var item in dataTblSubject)
                    {
                        dataSubject.Add(new Subject
                        {
                            Id = item.Id,
                            SubjectName = item.SubjectName,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return dataSubject;
        }
        public void AddSubjects(ISubject dataSubject)
        {
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    tblSubject dataTblSubject = new tblSubject();
     //             dataTblSubject.Id = dataSubject.Id;
                    dataTblSubject.SubjectName = dataSubject.SubjectName;
                    db.tblSubjects.Add(dataTblSubject);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
        public bool FindSubject(ISubject dataSubject)
        {
            bool present = false;
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    var check = db.tblSubjects.FirstOrDefault(data => data.SubjectName.Equals(dataSubject.SubjectName));
                    if(check != null)
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
    }
}