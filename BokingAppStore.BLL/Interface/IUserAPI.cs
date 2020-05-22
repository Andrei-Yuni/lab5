     using BokingAppStore.BLL.DataTransfer;
using BokingAppStore.BLL.Infostructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BokingAppStore.BLL.Interface
{
     public interface IUserAPI
     {
          ResultMsg Login(UserDTO userDTO);
          ResultMsg Register(UserDTO userDTO);
          ResultMsg Upload(BookDTO bookDTO, HttpPostedFileBase file, string directory);


          UserDTO GetUser(string mail);



     }
}

