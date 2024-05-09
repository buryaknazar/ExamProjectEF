using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    [Table("Members")]
    public class MemberInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public virtual SportInfo Sport { get; set; }

        public virtual CountryInfo Country { get; set; }

        [Required]
        public virtual MedalInfo Medals { get; set; }

    }
}
