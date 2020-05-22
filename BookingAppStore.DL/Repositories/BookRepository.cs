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
   public  class BookRepository : IRepository<Book>
     {
          DataContext database;

          public BookRepository(DataContext database)
          {
               this.database = database;
          }

          public void Create(Book item)
          {
               database.Books.Add(item);

          }

          public void Delete(int id)
          {
               database.Books.Remove(Get(id));
          }

          public IEnumerable<Book> Find(Func<Book, bool> predicate)
          {
               return database.Books.Where(predicate);
          }


          public Book Get(int id)
          {
               return database.Books.Find(id);
          }

          public IEnumerable<Book> GetAll()
          {
               return database.Books.ToList();
          }

          public void Update(Book item)
          {
               database.Entry(item).State = System.Data.Entity.EntityState.Modified;
          }
     }
}
