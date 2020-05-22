using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingAppStore.DAL.Entities
{
     public class Book
     {          
               // ID книги
               
               public int Id { get; set; }
               // название книги
               
               public string Name { get; set; }
               // автор книги
               public int NumberLab { get; set; }
               // цена
               public int Variant { get; set; }
               public string FileName { get; set; }
               public string RealFileName { get; set; }
     }
}