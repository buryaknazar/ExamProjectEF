using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    [Table("Countries")]
    public class CountryInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        public int GoldMedalsCount { get; set; }
        public int HostedOlimpiadsCount { get; set; }
    }
}
