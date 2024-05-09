using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class MedalStatisticWithMember
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public MedalInfo Medals { get; set; }
    }
}
