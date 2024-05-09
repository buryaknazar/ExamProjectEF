using BLL.Models;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOlimpiadService
    {
        IEnumerable<OlimpiadDTO> GetByCountry(string country);
        IEnumerable<OlimpiadDTO> GetByEventDate(DateTime eventDate);
        IEnumerable<OlimpiadDTO> GetBySeason(string season);
        IEnumerable<OlimpiadDTO> GetByCountOfMembers(int CountOfMembers);
    }
}
