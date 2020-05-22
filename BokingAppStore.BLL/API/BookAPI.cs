using BokingAppStore.BLL.DataTransfer;
using BokingAppStore.BLL.Interface;
using BookingAppStore.DAL.Entities;
using BookingAppStore.DL.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokingAppStore.BLL.API
{
     public class BookAPI : API, IBookAPI
     {
          public BookAPI(IUnitOfWork database) : base(database)
          {
          }

          static BookDTO ConvertToDTO (Book book)
          {
               if (book == null)
                    return null;
               return new BookDTO {
                    FileName = book.FileName, 
                    Id = book.Id, 
                    Name = book.Name, 
                    NumberLab = book.NumberLab, 
                    RealFileName = book.RealFileName, 
                    Variant = book.Variant };
          }
          public List<BookDTO> GetAllBooks()
          {
               return database.Books.GetAll().ToList().ConvertAll(ConvertToDTO);
          }

          public BookDTO GetBook(int id)
          {
               return ConvertToDTO(database.Books.Get(id));
          }
     }
}
