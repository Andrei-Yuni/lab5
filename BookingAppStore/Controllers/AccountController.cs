using BookingAppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookingAppStore.Controllers
{
     public class AccountController : Controller
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
                    User user = null;
                    using (var db = new UserContext())
                    {
                         user = db.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);
                    }
                    if (user != null)
                    {
                         FormsAuthentication.SetAuthCookie(model.Name, true);
                         return RedirectToAction("Index", "Home");
                    }
               }
               ModelState.AddModelError("", "Неверные данные для входа");
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
                    User user = null;
                    using (UserContext db = new UserContext())
                    {
                         user = db.Users.FirstOrDefault(u => u.Email == model.Name);
                    }
                    if (user == null)
                    {
                         // создаем нового пользователя
                         using (UserContext db = new UserContext())
                         {
                              _ = db.Users.Add(new User { Email = model.Name, Password = model.Password, Age = model.Age, Role="user" });
                              db.SaveChanges();

                              user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();
                         }
                         // если пользователь удачно добавлен в бд
                         if (user != null)
                         {
                              FormsAuthentication.SetAuthCookie(model.Name, true);
                              return RedirectToAction("Index", "Home");
                         }
                    }
                    else
                    {
                         ModelState.AddModelError("", "Пользователь с таким логином уже существует");
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