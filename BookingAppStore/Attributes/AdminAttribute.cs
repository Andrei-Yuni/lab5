using BokingAppStore.BLL;
using BokingAppStore.BLL.API;
using BokingAppStore.BLL.DataTransfer;
using BokingAppStore.BLL.Interface;
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

          BusinessLogic bl;
          public MyAuthorizeAttribute()
          {
               bl = new BusinessLogic();
          }
          IUserAPI UserAPI { get { return bl.UserAPI; } }

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

                    UserDTO user = UserAPI.GetUser(httpContext.User.Identity.Name);
                    if (user != null)
                         for (int i = 0; i < allowedRoles.Length; i++)
                         {
                              if (user.Role == allowedRoles[i])
                                   return true;
                         }

                    return false;
               }
               return true;
          }

     }

}