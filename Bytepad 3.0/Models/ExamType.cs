using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bytepad_3._0.dbClashFiles;
namespace Bytepad_3._0.Models
{
    public class ExamType : IExamType
    {
        public int Id { get; set; }
        public string Exam { get; set; }
        public List<ExamType> GetAllExamTypes()
        {
            List<ExamType> dataExamType = new List<ExamType>();
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    List<tblExamType> dataTblExamType = new List<tblExamType>();
                    dataTblExamType = db.tblExamTypes.ToList();
                    foreach (var item in dataTblExamType)
                    {
                        dataExamType.Add(new ExamType
                        {
                            Id = item.Id,
                            Exam = item.ExamType,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return dataExamType;
        }
        public string GetExamType(int id)
        {
            string foundExamType = "";
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    var found = db.tblExamTypes.FirstOrDefault(data => data.Id == id);
                    foundExamType = found.ExamType.ToString();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return foundExamType;
        }
    }
}
