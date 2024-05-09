using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<CountryDTO> GetElementsByName(string name);
        IEnumerable<CountryDTO> GetAllElements();
        IEnumerable<CountryDTO> GetByCity(string city);
        IEnumerable<CountryDTO> GetByGoldenMedals(int medals);
        IEnumerable<CountryDTO> GetByHosts(int hosts);
        IEnumerable<CountryDTO> GetByOlimpiadName(string olimpiadName);
    }
}
