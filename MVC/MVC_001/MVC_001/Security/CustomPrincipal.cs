using MVC_001.Models;
using MVC_001.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVC_001.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private User User;
        public IIdentity Identity { get; set; }

        public CustomPrincipal(User user)
        {
            User = user;
            Identity = new GenericIdentity(user.Email);
        }


        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            foreach(var r in roles){
                if (r == User.Role.Name)
                    return true;
            }
            return false;
        }
    }
}