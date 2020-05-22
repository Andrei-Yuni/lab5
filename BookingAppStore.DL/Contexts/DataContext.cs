using BookingAppStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingAppStore.DAL.Contexts
{
     public class DataContext:DbContext
     {
          public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
          {
               
          }
          static DataContext()
          {
               Database.SetInitializer<DataContext>(new AdminInitializer());
          }
          public DbSet<User> Users { get; set; }
          public DbSet<Book> Books { get; set; }
          public object Book { get; internal set; }
     }
     class AdminInitializer : CreateDatabaseIfNotExists<DataContext>
     {
          protected override void Seed(DataContext db)
          {
               User admin = new User { Age = 999, Email = "admin@mail.ru", Password = "admin", Role = "admin" };

               db.Users.Add(admin);
               db.SaveChanges();
          }
     }
}