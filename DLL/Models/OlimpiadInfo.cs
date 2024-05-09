using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    [Table("Olimpiads")]
    public class OlimpiadInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual CountryInfo EventCountry { get; set; }

        [Required]
        [MaxLength(30)]
        public string Season { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public int CountOfMembers { get; set; }
    }
}
