﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    [Table("Sports")]
    public class SportInfo
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountOfTeams { get; set; }

        [Required]
        public virtual OlimpiadInfo Olimpiad { get; set; }
    }
}
