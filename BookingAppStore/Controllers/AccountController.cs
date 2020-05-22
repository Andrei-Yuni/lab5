using BokingAppStore.BLL.DataTransfer;
using BokingAppStore.BLL.Interface;
using BookingAppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookingAppStore.Controllers
{
     public class AccountController : BaseController
     {

          public ActionResult Login()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Login(LoginModel model)
          {
               if (ModelState.IsValid)
               {
                    var user = new UserDTO { Email = model.Email, Password = model.Password };
                    var result = UserAPI.Login(user);
                    if (result.Succeeded)
                    {
                         FormsAuthentication.SetAuthCookie(model.Email, true);
                         return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", result.Error);
               }
               return View(model);
          }
          public ActionResult Register()
          {
               return View();
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Register(RegisterModel model)
          {
               if (ModelState.IsValid)
               {
                    var user = new UserDTO { Email = model.Email, Password = model.Password, Age = model.Age, Role = "user" };
                    var result = UserAPI.Register(user);

                    if (result.Succeeded)
                    {
                         FormsAuthentication.SetAuthCookie(model.Email, true);
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError(result.ErrorReason, result.Error);
                    }
               }

               return View(model);
          }
          [Authorize]
          public ActionResult Logout()
          {
               FormsAuthentication.SignOut();
               return RedirectToAction("Index", "Home");
          }
     }
}