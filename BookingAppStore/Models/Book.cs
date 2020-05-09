using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingAppStore.Models
{
     public class Book
     {          
               // ID книги
               [Required]
               public int Id { get; set; }
               // название книги
               [Required]
               public string Name { get; set; }
               // автор книги
               [Required]
               public string Author { get; set; }
               // цена
               [Required]
               public int Price { get; set; }
               public string FileName { get; set; }
               public string RealFileName { get; set; }
     }
}