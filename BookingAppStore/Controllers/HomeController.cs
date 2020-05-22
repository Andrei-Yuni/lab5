using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BokingAppStore.BLL;
using BokingAppStore.BLL.DataTransfer;
using BokingAppStore.BLL.Interface;
using BookingAppStore.Attributes;
using BookingAppStore.Models;

namespace BookingAppStore.Controllers
{
     public class HomeController : BaseController
     {
          public ActionResult Index()
          {
               var books = BookAPI.GetAllBooks();
               UserDTO user = null;
               if (User.Identity.IsAuthenticated)
                    user = UserAPI.GetUser(User.Identity.Name);
               var model = new HomePageModel { Books = books, User = user };
               return View(model);
          }
          [Authorize]
          [HttpGet]
          public ActionResult Create()
          {
               return View();
          }
          [Authorize]
          [HttpPost]
          public ActionResult Create(BookModel book, HttpPostedFileBase file)
          {

               if (ModelState.IsValid)
               {
                    var bookDTO = new BookDTO { Name = book.Name, NumberLab = book.NumberLab, Variant = book.Variant };

                    var directory = Server.MapPath("~/Files");
                    var result = UserAPI.Upload(bookDTO, file, directory);
                    if (result.Succeeded)
                         return RedirectToAction("Index");
                    ModelState.AddModelError("", result.Error);
               }
               return View(book);
          }


          [Authorize]
          [MyAuthorize(Roles = "admin")]
          [HttpGet]
          public ActionResult Delete(int id)
          {
               var b = BookAPI.GetBook(id);
               if (b == null)
               {
                    return HttpNotFound();
               }
               return View(b);
          }
          [Authorize]
          [MyAuthorize(Roles = "admin")]
          [HttpPost, ActionName("Delete")]
          public ActionResult DeleteConfirmed(int id)
          {
               AdminAPI.DeleteBook(id);
               return RedirectToAction("Index");
          }



          [HttpGet]
          public FileResult Download(int id)
          {
               var book = BookAPI.GetBook(id);
               var filePath = Server.MapPath("~/Files/" + book.RealFileName);
               var contentType = MimeMapping.GetMimeMapping(book.RealFileName);
               return File(filePath, contentType, book.FileName);
          }

          public ActionResult About()
          {
               ViewBag.Message = "Your application description page.";

               return View();
          }

          public ActionResult Contact()
          {
               ViewBag.Message = "Your contact page.";

               return View();
          }
     }
}