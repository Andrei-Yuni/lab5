using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingAppStore.Models
{
     public class LoginModel
     {
          [Required]
          public string Name { get; set; }
          [Required]
          [DataType(DataType.Password)]
          public string Password { get; set; }
     }

     public class RegisterModel
     {
          [Required] 
          public string Name { get; set; }
          [Required]
          [DataType(DataType.Password)]
          public string Password { get; set; } 
          public int Age { get; set; }


          
     }
}
