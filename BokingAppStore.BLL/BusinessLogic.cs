using BokingAppStore.BLL.API;
using BokingAppStore.BLL.Interface;
using BookingAppStore.DL.Intefraces;
using BookingAppStore.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokingAppStore.BLL
{
     public class BusinessLogic
     {
          IUnitOfWork database;

          public BusinessLogic()
          {
               database = new UnitOfWork("BookContext");
          }

          IUserAPI userAPI;
          public IUserAPI UserAPI
          {
               get
               {
                    if (userAPI == null)
                         userAPI = new UserAPI(database);

                    return userAPI;
               }
          }
          IAdminAPI adminAPI;
          public IAdminAPI AdminAPI
          {
               get
               {
                    if (adminAPI == null)
                         adminAPI = new AdminAPI(database);

                    return adminAPI;
               }
          }
          IBookAPI bookAPI;
          public IBookAPI BookAPI
          {
               get
               {
                    if (bookAPI == null)
                         bookAPI = new BookAPI(database);

                    return bookAPI;
               }
          }
     }
}
