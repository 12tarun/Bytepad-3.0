using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Models
{
    public class ExamType : IExamType
    {
        public int Id { get; set; }
        public string Exam { get; set; }
        public List<ExamType> GetAllExamTypes()
        {
            List<ExamType> dataExamType = new List<ExamType>();
            using (BytepadDBEntities db = new BytepadDBEntities())
            {
                try
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
                catch (Exception ex)
                {
                    string error = ex.ToString();
                }   
            }
            return dataExamType;
        }
    }
}
