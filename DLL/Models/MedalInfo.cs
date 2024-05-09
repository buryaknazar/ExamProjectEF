using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    [Table("MedalsStatistics")]
    public class MedalInfo
    {
        public int Id { get; set; }

        [Required]
        public int CountOfGold { get; set; }

        [Required]
        public int CountOfSilver { get; set; }

        [Required]
        public int CountOfBronze { get; set; }
    }
}
