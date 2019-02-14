using System.Collections.Generic;

namespace Bytepad_3._0.Models
{
    public interface IPaper
    {
        int AdminId { get; set; }
        int ExamTypeId { get; set; }
        string FileUrl { get; set; }
        int Id { get; set; }
        string PaperType { get; set; }
        int SemesterType { get; set; }
        int SessionId { get; set; }
        int SubjectId { get; set; }
        string SubjectName { get; set; }

        void AddPaper(IPaper dataPaper);
        void DeletePaperByID(int id);
        bool FindPaper(string fileUrl);
        List<Paper> FindPapersBySubjectId(int id);
        List<Paper> GetAllPapers();
        List<Paper> getPapersBySessionAndExamType(int sessionId, int examId);
        void RemovePaperBySession(int sessionId);
        void RemovePapersByExamTypeAndSession(int sessionId, int examTypeId);
    }
}