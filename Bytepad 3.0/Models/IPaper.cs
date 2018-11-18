namespace Bytepad_3._0.Models
{
    public interface IPaper
    {
        int? AdminId { get; set; }
        int ExamTypeId { get; set; }
        string FileUrl { get; set; }
        int Id { get; set; }
        string PaperType { get; set; }
        string SemesterType { get; set; }
        int SessionId { get; set; }
        int SubjectId { get; set; }
        void AddPaper(IPaper dataPaper);
        bool FindPaper(string dataPaper);
        string GetExamTypeOfPaper(int id);
        string GetSessionOfPaper(int id);
    }
}