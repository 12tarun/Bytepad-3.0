using System.Collections.Generic;

namespace Bytepad_3._0.Models
{
    public interface ISubject
    {
        int Id { get; set; }
        string SubjectName { get; set; }
        int AddSubjects(ISubject dataSubject);
        int FindSubject(ISubject dataSubject);
        List<Subject> GetAllSubjects();
    }
}