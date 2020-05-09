using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingAppStore.Models
{
     public class UserContext : DbContext
     {
          public UserContext() :
              base("DefaultConnection")
          { }

          public DbSet<User> Users { get; set; }
     }
     public class AdminInitializer : CreateDatabaseIfNotExists<UserContext>
     {
          protected override void Seed(UserContext context)
          {
               base.Seed(context);
               context.Users.Add(new User { Email = "admin@sobaka.ru", Password = "123456", Role="admin" });
          }
     }
}