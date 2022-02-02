using MVC_001.Models;
using MVC_001.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVC_001.DataAccess;

namespace MVC_001.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Email))
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new
                    {
                        controller = "Student",
                        action = "Login"
                    }));
            else
            {
                User user = new User();
                user = UserDAL.Methods.GetByEmail(SessionPersister.Email, "Student");
                CustomPrincipal mp = new CustomPrincipal(user);
                if (!mp.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "Student",
                            action = "AuthFailed"
                        }));
            }
        }
    }
}