using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OlimpiadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDTO EventCountry { get; set; }
        public string Season { get; set; }
        public DateTime EventDate { get; set; }
        public int CountOfMembers { get; set; }
    }
}
