using BokingAppStore.BLL;
using BokingAppStore.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingAppStore.Controllers
{
     public class BaseController : Controller
     {
          BusinessLogic bl;
          public BaseController()
          {
               bl = new BusinessLogic();
          }

          protected IUserAPI UserAPI { get { return bl.UserAPI; } }
          protected IBookAPI BookAPI { get { return bl.BookAPI; } }
          protected IAdminAPI AdminAPI { get { return bl.AdminAPI; } }
     }
}