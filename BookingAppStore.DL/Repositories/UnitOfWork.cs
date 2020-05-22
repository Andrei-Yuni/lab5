using BookingAppStore.DAL.Contexts;
using BookingAppStore.DAL.Entities;
using BookingAppStore.DL.Intefraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppStore.DL.Repositories
{
     public class UnitOfWork : IUnitOfWork
     {
          DataContext database;

          public UnitOfWork(string Connection)
          {
               database = new DataContext(Connection);
               Users = new UserRepository(database);
               Books = new BookRepository(database);
               
          }
          public IRepository<User> Users { get; }

          public IRepository<Book> Books { get; }


          public void Save()
          {
               database.SaveChanges();
          }

          #region IDisposable Support
          private bool disposedValue = false; 

         

          protected virtual void Dispose(bool disposing)
          {
               if (!disposedValue)
               {
                    if (disposing)
                    {
                         database.Dispose();
                    }

                    disposedValue = true;
               }
          }

          public void Dispose()
          {
               Dispose(true);
              
          }
          #endregion
     }
}
