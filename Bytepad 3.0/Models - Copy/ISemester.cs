using System.Collections.Generic;

namespace Bytepad_3._0.Models
{
    public interface ISemester
    {
        int Id { get; set; }
        string SemesterType { get; set; }
        List<Semester> GetAllSemesters();
        string GetSemesterTypeById(string id);
    }
}