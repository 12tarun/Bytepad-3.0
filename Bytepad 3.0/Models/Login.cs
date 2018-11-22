using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bytepad_3._0.dbClashFiles;
namespace Bytepad_3._0.Models
{
    public class Login : ILogin
    {
        [Required]
        public string  Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        public bool isValidCredentials(Login data)
        {
            bool present = false;
            using (BytepadDBEntities db = new BytepadDBEntities())
            {
                var temp=db.tblAdmins.Where(a=>a.Username==data.Username&&a.Password==data.Password).FirstOrDefault();
                if(temp!=null)
                {
                    present = true;
                }
            }
            return present;
        }
    }
}