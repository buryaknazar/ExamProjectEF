using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IMedalStatisticRepository
    {
        IEnumerable<MedalStatisticWithMember> GetMembersStatisticByName(string name);
        IEnumerable<MedalStatisticWithMember> GetMembersStatisticByLastName(string lastName);
        IEnumerable<MedalStatisticWithMember> GetMedalStatisticByGoldenAmount(int goldenMedals);
        IEnumerable<MedalStatisticWithMember> GetMedalStatisticBySilverAmount(int silverMedals);
        IEnumerable<MedalStatisticWithMember> GetMedalStatisticByBronzeAmount(int bronzeMedals);

        IEnumerable<MedalStatisticWithMember> GetAllElements();

        void DeleteElement(MedalStatisticWithMember values);

        void UpdateElement(MedalStatisticWithMember values);
    }
}
