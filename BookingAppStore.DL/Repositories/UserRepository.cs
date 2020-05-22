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
     public class UserRepository : IRepository<User>
     {
          DataContext database;

          public UserRepository(DataContext database)
          {
               this.database = database;
          }

          public void Create(User item)
          {
               database.Users.Add(item);   

          }

          public void Delete(int id)
          {
               database.Users.Remove(Get(id));
          }

          public IEnumerable<User> Find(Func<User, bool> predicate)
          {
              return database.Users.Where(predicate);
          }


          public User Get(int id)
          {
               return database.Users.Find(id);
          }

          public IEnumerable<User> GetAll()
          {
               return database.Users.ToList();
          }

          public void Update(User item)
          {
               database.Entry(item).State = System.Data.Entity.EntityState.Modified;
          }
     }
}
