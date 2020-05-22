using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingAppStore.Models
{
     public class RegisterModel
     {
          [Required]
          [DataType(DataType.EmailAddress)]
          public string Email { get; set; }
          [Required]
          [DataType(DataType.Password)]
          public string Password { get; set; }
          public int Age { get; set; }
     }
}