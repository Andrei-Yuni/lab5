using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingAppStore.Models;

namespace BookingAppStore.Controllers
{
     public class HomeController : Controller
     {
          BookContext db = new BookContext();
         
          
          public ActionResult Index()
          {
               var books = db.Books;
               ViewBag.Books = books;
               User user = null;
               if (User.Identity.IsAuthenticated)
               using (var db = new UserContext())
               {
                    user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
               }
               return View(user);
          }
          [Authorize]
          [HttpGet]
          public ActionResult Create()
          {
               return View();
          }
          [HttpPost]
          public ActionResult Create(Book book, HttpPostedFileBase file)
          {
               if (ModelState.IsValid)
               {
                    if (file != null)
                    {
                         var directory = Server.MapPath("~/Files");
                         var extention = Path.GetExtension(file.FileName);
                         if (extention == ".pdf" || extention == ".docx" || extention == ".doc")
                         {
                              var fileName = Path.GetFileName(file.FileName);
                              var realFileName =fileName;
                              while (db.Books.Where(b => b.RealFileName == realFileName).FirstOrDefault() != null)
                              {
                                   var fileNameWithoutExt = Path.GetFileNameWithoutExtension(realFileName);
                                   realFileName = fileNameWithoutExt + "1" + extention;
                              }
                              if (!Directory.Exists(directory))
                                   Directory.CreateDirectory(directory);
                              file.SaveAs(directory + "/" + realFileName);
                              book.FileName = fileName;
                              book.RealFileName = realFileName;
                         }
                    }
                    db.Books.Add(book);
                    db.SaveChanges();

                    return RedirectToAction("Index");
               }
               return View(book);
          }



          [HttpGet]
          public ActionResult Delete(int id)
          {
               Book b = db.Books.Find(id);
               if (b == null)
               {
                    return HttpNotFound();
               }
               return View(b);
          }
          [HttpPost, ActionName("Delete")]
          public ActionResult DeleteConfirmed(int id)
          {
               Book b = db.Books.Find(id);
               if (b == null)
               {
                    return HttpNotFound();
               }
               db.Books.Remove(b);
               db.SaveChanges();
               return RedirectToAction("Index");
          }

          [HttpGet]
          public ActionResult Buy(int id)
          {
               ViewBag.Books = id;
               return View();
          }

          [HttpPost]
          public string Buy(Purchase purchase)
          {
               purchase.Date = DateTime.Now;
               // добавляем информацию о покупке в базу данных
               db.Purchases.Add(purchase);
               // сохраняем в бд все изменения
               db.SaveChanges();
               return "Спасибо," + purchase.Person + ", за покупку!";
          }

          [HttpGet]
          public FileResult Download(int id)
          {
               var book = db.Books.Find(id);
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