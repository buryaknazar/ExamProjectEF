using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MedalStatisticWithMemberDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public MedalInfo Medals { get; set; }
    }
}
