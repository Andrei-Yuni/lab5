using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokingAppStore.BLL.Infostructure
{
     public class ResultMsg
     {
          public bool Succeeded { get; set; }
          public string Error { get; set; }
          public string ErrorReason { get; set; }
     }
}
