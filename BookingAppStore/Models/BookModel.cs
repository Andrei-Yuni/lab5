using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingAppStore.Models
{
     public class BookModel
     {          
               
               // название книги
               [Required]
               public string Name { get; set; }
               // автор книги
               [Required]
               public int NumberLab { get; set; }
               // цена
               [Required]
               public int Variant { get; set; }
              
     }
}