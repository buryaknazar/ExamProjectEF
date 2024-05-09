using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IOlimpiadRepository
    {
        IEnumerable<OlimpiadInfo> GetByCountry(string country);
        IEnumerable<OlimpiadInfo> GetByEventDate(DateTime eventDate);
        IEnumerable<OlimpiadInfo> GetBySeason(string season);
        IEnumerable<OlimpiadInfo> GetByCountOfMembers(int CountOfMembers);
    }
}
