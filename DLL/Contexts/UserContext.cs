using DLL.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace DLL.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=UserContext") {}

        public DbSet<UserInfo> Users { get; set; }
    }
}