using BokingAppStore.BLL.DataTransfer;
using BokingAppStore.BLL.Infostructure;
using BokingAppStore.BLL.Interface;
using BookingAppStore.DAL.Entities;
using BookingAppStore.DL.Intefraces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BokingAppStore.BLL.API
{
     public class UserAPI : API, IUserAPI
     {
          public UserAPI(IUnitOfWork database) : base(database)
          {

          }

          public ResultMsg Upload(BookDTO bookDTO, HttpPostedFileBase file, string directory)
          {

               if (file != null)

               {
                    Book book = new Book { Name = bookDTO.Name, NumberLab = bookDTO.NumberLab, Variant = bookDTO.Variant };
                    var extention = Path.GetExtension(file.FileName);
                    if (extention == ".pdf" || extention == ".docx" || extention == ".doc")
                    {
                         var fileName = Path.GetFileName(file.FileName);
                         var realFileName = fileName;
                         while (database.Books.Find(b => b.RealFileName == realFileName).FirstOrDefault() != null)
                         {
                              var fileNameWithoutExt = Path.GetFileNameWithoutExtension(realFileName);
                              realFileName = fileNameWithoutExt + "1" + extention;
                         }
                         if (!Directory.Exists(directory))
                              Directory.CreateDirectory(directory);
                         file.SaveAs(directory + "/" + realFileName);
                         book.FileName = fileName;
                         book.RealFileName = realFileName;
                         database.Books.Create(book);
                         database.Save();
                         return new ResultMsg { Succeeded = true };
                    }
                    else
                    {
                         return new ResultMsg { Succeeded = false, Error = "Тип файла недоступен" };
                    }
               }
               else
               {
                    return new ResultMsg { Succeeded = false, Error = "Не удалось загрузить файл" };
               }
          }

          public ResultMsg Login(UserDTO userDTO)
          {
               User user = database.Users.Find(u => u.Email == userDTO.Email && u.Password == userDTO.Password).FirstOrDefault();
               if (user == null)
               {
                    return new ResultMsg { Succeeded = false, Error = "Неверный пароль или логин", ErrorReason = "" };
               }
               else
                    return new ResultMsg { Succeeded = true };


          }

          public ResultMsg Register(UserDTO userDTO)
          {
               User user = database.Users.Find(u => u.Email == userDTO.Email).FirstOrDefault();
               if (user != null)
               {
                    return new ResultMsg { Succeeded = false, Error = "Такой email уже занят", ErrorReason = "Email" };
               }
               else
               {
                    database.Users.Create(
                         new User
                         {
                              Email = userDTO.Email,
                              Password = userDTO.Password,
                              Age = userDTO.Age,
                              Role = userDTO.Role
                         });
                    database.Save();
                    return new ResultMsg { Succeeded = true };
               }

          }

          static UserDTO ConvertToDTO(User user)
          {
               if (user == null)
                    return null;
               return new UserDTO { Age = user.Age, Email = user.Email, Id = user.Id, Password = user.Password, Role = user.Role };
          }

          public UserDTO GetUser(string mail)
          {
               return ConvertToDTO(database.Users.Find(u => u.Email == mail).FirstOrDefault());
          }
     }
}