using BokingAppStore.BLL.Interface;
using BookingAppStore.DL.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokingAppStore.BLL.API
{
     public class AdminAPI : API, IAdminAPI
     {
          public AdminAPI(IUnitOfWork database) : base(database)
          {
          }

          public void DeleteBook(int id)
          {
               database.Books.Delete(id);
               database.Save();
          }
     }
}
