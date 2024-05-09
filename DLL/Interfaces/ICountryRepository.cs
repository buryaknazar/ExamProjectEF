using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<CountryInfo> GetElementsByName(string name);
        IEnumerable<CountryInfo> GetAllElements();
        IEnumerable<CountryInfo> GetByCity(string city);
        IEnumerable<CountryInfo> GetByGoldenMedals(int medals);
        IEnumerable<CountryInfo> GetByHosts(int hosts);
        IEnumerable<CountryInfo> GetByOlimpiadName(string olimpiadName);
    }
}
