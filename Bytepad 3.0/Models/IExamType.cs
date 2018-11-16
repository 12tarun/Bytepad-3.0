using System.Collections.Generic;

namespace Bytepad_3._0.Models
{
    public interface IExamType
    {
        string Exam { get; set; }
        int Id { get; set; }

        List<ExamType> GetAllExamTypes();
    }
}