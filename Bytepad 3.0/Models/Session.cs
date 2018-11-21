using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bytepad_3._0.dbClashFiles;

namespace Bytepad_3._0.Models
{
    public class Session : ISession
    {
        public int Id { get; set; }
        public string EachSession { get; set; }
        public List<Session> GetAllSessions()
        {
            List<Session> dataSession = new List<Session>();
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    List<tblSession> dataTblSession = new List<tblSession>();
                    dataTblSession = db.tblSessions.ToList();
                    foreach(var item in dataTblSession)
                    {
                        dataSession.Add(new Session
                        {
                            Id = item.Id,
                            EachSession = item.Session,
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
            }
            return dataSession;
        }
        public string GetSession(int id)
        {
            string foundSession = "";
            try
            {
                using (BytepadDBEntities db = new BytepadDBEntities())
                {
                    var found = db.tblSessions.FirstOrDefault(data => data.Id == id);
                    foundSession = found.Session.ToString();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            return foundSession;
        }
    }
}
