using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_001.DataAccess;

namespace MVC_001.ModelBase
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }

        public Role Role {
            get {
                return RoleDAL.Methods.GetByID(this.RoleID);
            }  
        }

        public bool Login()
        {
            // TODO: Burada UserDAL kullanılarak oturum kontrolü yapılacak.
            return true;
        }
    }
}