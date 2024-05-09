using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMedalStatisticService
    {
        IEnumerable<MedalStatisticWithMemberDTO> GetMembersStatisticByName(string name);
        IEnumerable<MedalStatisticWithMemberDTO> GetMembersStatisticByLastName(string lastName);
        IEnumerable<MedalStatisticWithMemberDTO> GetMedalStatisticByGoldenAmount(int goldenMedals);
        IEnumerable<MedalStatisticWithMemberDTO> GetMedalStatisticBySilverAmount(int silverMedals);
        IEnumerable<MedalStatisticWithMemberDTO> GetMedalStatisticByBronzeAmount(int bronzeMedals);

        IEnumerable<MedalStatisticWithMemberDTO> GetAllElements();

        void DeleteElement(MedalStatisticWithMemberDTO values);

        void UpdateElement(MedalStatisticWithMemberDTO values);
    }
}
