using BokingAppStore.BLL.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAppStore.Models
{
     public class HomePageModel : UserModel
     {
          public IEnumerable<BookDTO> Books;
     }
}