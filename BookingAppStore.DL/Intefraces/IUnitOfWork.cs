using BookingAppStore.DAL.Entities;
using BookingAppStore.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppStore.DL.Intefraces
{
     public interface IUnitOfWork: IDisposable 
     {
          IRepository<User> Users { get; }
          IRepository<Book> Books { get; }
          

          void Save();
     }
}
