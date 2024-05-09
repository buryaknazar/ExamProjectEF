using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface ISportRepository
    {
        IEnumerable<SportInfo> GetElementsByName(string name);
        IEnumerable<SportInfo> GetByMaxTeams(int teams);
        IEnumerable<SportInfo> GetByOlimpiad(string olimpiad);
    }
}
