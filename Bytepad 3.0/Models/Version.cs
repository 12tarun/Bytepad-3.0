using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bytepad_3._0.Models
{
    public class Version : IVersion
    {
        public int ID { get; set; }
        public DateTime LastAddPaperTime { get; set; }
        public DateTime? getLastAddPaperTime()
        {
            tblVersion temp;
            using (BytepadDBEntities db = new BytepadDBEntities())
            {
                temp = db.tblVersions.FirstOrDefault(data => data.ID == 1);
            }
            if (temp == null)
                return null;
            else return temp.LastAddPaperTime;
        } 
        public void updateLastAddPaperTime()
        {
            using (BytepadDBEntities db = new BytepadDBEntities())
            {
                tblVersion temp = db.tblVersions.FirstOrDefault(data => data.ID == 1);
                if(temp==null)
                {
                    temp = new tblVersion();
                    temp.ID = 1;
                    temp.LastAddPaperTime = DateTime.Now;
                    db.tblVersions.Add(temp);
                    db.SaveChanges();
                }
                else
                {
                    temp.LastAddPaperTime = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }
    }
}