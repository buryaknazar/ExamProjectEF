using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISportService
    {
        IEnumerable<SportDTO> GetElementsByName(string name);
        IEnumerable<SportDTO> GetByMaxTeams(int teams);
        IEnumerable<SportDTO> GetByOlimpiad(string olimpiad);
    }
}
