using DLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SportDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfTeams { get; set; }
        public virtual OlimpiadDTO Olimpiad { get; set; }
    }
}
