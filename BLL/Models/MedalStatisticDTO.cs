using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MedalStatisticDTO
    {
        public int Id { get; set; }
        public int CountOfGold { get; set; }
        public int CountOfSilver { get; set; }
        public int CountOfBronze { get; set; }
    }
}
