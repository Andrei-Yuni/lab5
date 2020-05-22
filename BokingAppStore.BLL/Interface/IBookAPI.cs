using BokingAppStore.BLL.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokingAppStore.BLL.Interface
{
     public interface IBookAPI
     {
          List<BookDTO> GetAllBooks();
          BookDTO GetBook(int id);
     }
}
