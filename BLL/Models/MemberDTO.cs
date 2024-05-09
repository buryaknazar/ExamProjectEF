using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MemberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public virtual SportDTO Sport { get; set; }
        public virtual CountryDTO Country { get; set; }
        public virtual MedalStatisticDTO Medals { get; set; }
    }
}
