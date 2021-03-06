﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokingAppStore.BLL.DataTransfer
{
     public class BookDTO
     {
          // ID книги
          public int Id { get; set; }
          // название книги
          public string Name { get; set; }
          // номер лаб.работы
          public int NumberLab { get; set; }
          // вариант
          public int Variant { get; set; }
          public string FileName { get; set; }
          public string RealFileName { get; set; }
     }
}
