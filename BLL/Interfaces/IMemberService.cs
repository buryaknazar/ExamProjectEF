using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberDTO> GetElementsByName(string name);
        IEnumerable<MemberDTO> GetByLastName(string lastName);
        IEnumerable<MemberDTO> GetByAge(int age);
        IEnumerable<MemberDTO> GetByGoldenMedals(int medals);
        IEnumerable<MemberDTO> GetBySilverMedals(int medals);
        IEnumerable<MemberDTO> GetByBronzeMedals(int medals);
        IEnumerable<MemberDTO> GetByCountry(string country);
        IEnumerable<MemberDTO> GetBySport(string sport);
    }
}
