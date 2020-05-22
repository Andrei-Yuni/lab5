using BookingAppStore.DL.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokingAppStore.BLL.API
{
     public abstract class API: IDisposable
     {
          protected API(IUnitOfWork database)
          {
               this.database = database;
          }

          protected IUnitOfWork database { get; set; }

          public void Dispose()
          {
               database.Dispose();
          }
     }
}
