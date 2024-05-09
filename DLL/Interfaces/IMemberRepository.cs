using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<MemberInfo> GetElementsByName(string name);
        IEnumerable<MemberInfo> GetByLastName(string lastName);
        IEnumerable<MemberInfo> GetByAge(int age);
        IEnumerable<MemberInfo> GetByGoldenMedals(int medals);
        IEnumerable<MemberInfo> GetBySilverMedals(int medals);
        IEnumerable<MemberInfo> GetByBronzeMedals(int medals);
        IEnumerable<MemberInfo> GetByCountry(string country);
        IEnumerable<MemberInfo> GetBySport(string sport);
    }
}
