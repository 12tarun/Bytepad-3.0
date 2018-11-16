using System.Collections.Generic;

namespace Bytepad_3._0.Models
{
    public interface ISession
    {
        string EachSession { get; set; }
        int Id { get; set; }

        List<Session> GetAllSessions();
    }
}