using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public int GoldMedalsCount { get; set; }
        public int HostedOlimpiadsCount { get; set; }
    }
}
