using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Filter
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        #region Unknown
        //private string[] allowedUsers = new string[] { };
        //private string[] allowedRoles = new string[] { };

        //public MyAuthorizeAttribute()
        //{ }

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    if (!String.IsNullOrEmpty(base.Users))
        //    {
        //        allowedUsers = base.Users.Split(new char[] { ',' });
        //        for (int i = 0; i < allowedUsers.Length; i++)
        //        {
        //            allowedUsers[i] = allowedUsers[i].Trim();
        //        }
        //    }
        //    if (!String.IsNullOrEmpty(base.Roles))
        //    {
        //        allowedRoles = base.Roles.Split(new char[] { ',' });
        //        for (int i = 0; i < allowedRoles.Length; i++)
        //        {
        //            allowedRoles[i] = allowedRoles[i].Trim();
        //        }
        //    }

        //    return httpContext.Request.IsAuthenticated &&
        //         User(httpContext) && Role(httpContext);
        //}

        //private bool User(HttpContextBase httpContext)
        //{
        //    if (allowedUsers.Length > 0)
        //    {
        //        return allowedUsers.Contains(httpContext.User.Identity.Name);
        //    }
        //    return true;
        //}

        //private bool Role(HttpContextBase httpContext)
        //{
        //    if (allowedRoles.Length > 0)
        //    {
        //        for (int i = 0; i < allowedRoles.Length; i++)
        //        {
        //            if (httpContext.User.IsInRole(allowedRoles[i]))
        //                return true;
        //        }
        //        return false;
        //    }
        //    return true;
        //}
        #endregion

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // The user is not authenticated
                base.HandleUnauthorizedRequest(filterContext);
            }
            else if (!this.Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {
                // The user is not in any of the listed roles => 
                // show the unauthorized view
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/NotRoute.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }

}