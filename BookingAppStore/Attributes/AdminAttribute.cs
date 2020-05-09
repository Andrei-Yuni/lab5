using BookingAppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingAppStore.Attributes
{
     public class MyAuthorizeAttribute : AuthorizeAttribute
          {
               private string[] allowedRoles = new string[] { };

               public MyAuthorizeAttribute()
               { }

               protected override bool AuthorizeCore(HttpContextBase httpContext)
               {
                    if (!String.IsNullOrEmpty(base.Roles))
                    {
                         allowedRoles = base.Roles.Split(new char[] { ',' });
                         for (int i = 0; i < allowedRoles.Length; i++)
                         {
                              allowedRoles[i] = allowedRoles[i].Trim();
                         }
                    }

                    return httpContext.Request.IsAuthenticated && Role(httpContext);
               }

               private bool Role(HttpContextBase httpContext)
               {
                    if (allowedRoles.Length > 0)
                    {
                    using (var db = new UserContext())
                    {
                         User user = db.Users.FirstOrDefault(u => u.Email == httpContext.User.Identity.Name);
                         if (user !=null)
                         for (int i = 0; i < allowedRoles.Length; i++)
                         {
                              if (user.Role == allowedRoles[i])
                                   return true;
                         }
                    }
                         return false;
                    }
                    return true;
               }
   
}
     
}