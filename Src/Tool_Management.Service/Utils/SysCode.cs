using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Management.Service.Utils
{
    public class SysCode
    {
        public enum Status 
        {
            報廢 = 9,
            正常入庫 = 1,
            維修入庫 = 2,
            正常出庫 = 3, 
            維修出庫 = 4
             
        }
    }
}
