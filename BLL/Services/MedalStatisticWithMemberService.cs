using BLL.Interfaces;
using BLL.Models;
using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class MedalStatisticWithMemberService : IMedalStatisticService
    {
        private MedalStatisticRepository _repository;

        public MedalStatisticWithMemberService()
        {
            _repository = new MedalStatisticRepository();
        }

        public void DeleteElement(MedalStatisticWithMemberDTO values)
        {
            _repository.DeleteElement(TranslatorDTOToInfo(values));
        }

        public IEnumerable<MedalStatisticWithMemberDTO> GetAllElements()
        {
            return TranslatorListInfoToListDTO(_repository.GetAllElements());
        }

        public IEnumerable<MedalStatisticWithMemberDTO> GetMedalStatisticByBronzeAmount(int bronzeMedals)
        {
            return TranslatorListInfoToListDTO(_repository.GetMedalStatisticByBronzeAmount(bronzeMedals));
        }

        public IEnumerable<MedalStatisticWithMemberDTO> GetMedalStatisticByGoldenAmount(int goldenMedals)
        {
            return TranslatorListInfoToListDTO(_repository.GetMedalStatisticByGoldenAmount(goldenMedals));
        }

        public IEnumerable<MedalStatisticWithMemberDTO> GetMedalStatisticBySilverAmount(int silverMedals)
        {
            return TranslatorListInfoToListDTO(_repository.GetMedalStatisticBySilverAmount(silverMedals));
        }

        public IEnumerable<MedalStatisticWithMemberDTO> GetMembersStatisticByName(string name)
        {
            return TranslatorListInfoToListDTO(_repository.GetMembersStatisticByName(name));
        }

        public IEnumerable<MedalStatisticWithMemberDTO> GetMembersStatisticByLastName(string lastName)
        {
            return TranslatorListInfoToListDTO(_repository.GetMembersStatisticByLastName(lastName));
        }

        public void UpdateElement(MedalStatisticWithMemberDTO values)
        {
            throw new NotImplementedException();
        }

        private MedalStatisticWithMemberDTO TranslatorInfoToDTO(MedalStatisticWithMember medals)
        {
            return new MedalStatisticWithMemberDTO()
            {
                Name = medals.Name,
                LastName = medals.LastName,
                Medals = new MedalInfo()
                {
                    Id = medals.Medals.Id,
                    CountOfGold = medals.Medals.CountOfGold,
                    CountOfSilver = medals.Medals.CountOfSilver,
                    CountOfBronze = medals.Medals.CountOfBronze
                }
            };
        }

        private MedalStatisticWithMember TranslatorDTOToInfo(MedalStatisticWithMemberDTO medals)
        {
            return new MedalStatisticWithMember()
            {
                Name = medals.Name,
                LastName = medals.LastName,
                Medals = new MedalInfo()
                {
                    Id = medals.Medals.Id,
                    CountOfGold = medals.Medals.CountOfGold,
                    CountOfSilver = medals.Medals.CountOfSilver,
                    CountOfBronze = medals.Medals.CountOfBronze
                }
            };
        }

        private List<MedalStatisticWithMemberDTO> TranslatorListInfoToListDTO(IEnumerable<MedalStatisticWithMember> medalInfos)
        {
            List<MedalStatisticWithMemberDTO> result = new List<MedalStatisticWithMemberDTO>();

            foreach (var medalInfo in medalInfos)
            {
                result.Add(TranslatorInfoToDTO(medalInfo));
            }

            return result;
        }
    }
}
