using DLL.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace DLL.Contexts
{
    public class OlimpiaContext : DbContext
    {
        public OlimpiaContext() : base("name=OlimpiaContext") {}

        public DbSet<CountryInfo> Countries { get; set; }
        public DbSet<OlimpiadInfo> Olimpiads { get; set; }
        public DbSet<SportInfo> Sports { get; set; }
        public DbSet<MedalInfo> MedalsStatistics { get; set; }
        public DbSet<MemberInfo> Members { get; set; }
    }
}