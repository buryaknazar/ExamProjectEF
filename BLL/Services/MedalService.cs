using BLL.Models;
using DLL.Interfaces;
using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MedalService : IRepository<MedalStatisticDTO>
    {
        private MedalStatisticRepository _repository;

        public MedalService()
        {
            _repository = new MedalStatisticRepository();
        }

        public void Add(MedalStatisticDTO values)
        {
            if(values != null)
            {
                _repository.Add(TranslateMedalDTOToMedalInfo(values));
            }
        }

        public void Delete(MedalStatisticDTO values)
        {
            if (values != null)
            {
                _repository.Delete(TranslateMedalDTOToMedalInfo(values));
            }
        }

        public IEnumerable<MedalStatisticDTO> GetAll()
        {
            return TranslateMedalInfoListToMedalDTOList(_repository.GetAll());
        }

        public MedalStatisticDTO GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(MedalStatisticDTO values)
        {
            throw new NotImplementedException();
        }

        private MedalInfo TranslateMedalDTOToMedalInfo(MedalStatisticDTO medal)
        {
            return new MedalInfo()
            {
                Id = medal.Id,
                CountOfGold = medal.CountOfGold,
                CountOfSilver = medal.CountOfSilver,
                CountOfBronze = medal.CountOfBronze,
            };
        }

        private MedalStatisticDTO TranslateMedalInfoToMedalDTO(MedalInfo medal)
        {
            return new MedalStatisticDTO()
            {
                Id = medal.Id,
                CountOfGold = medal.CountOfGold,
                CountOfSilver = medal.CountOfSilver,
                CountOfBronze = medal.CountOfBronze,
            };
        }

        private List<MedalStatisticDTO> TranslateMedalInfoListToMedalDTOList(IEnumerable<MedalInfo> medalInfos)
        {
            List<MedalStatisticDTO> result = new List<MedalStatisticDTO>();

            foreach (MedalInfo item in medalInfos)
            {
                result.Add(TranslateMedalInfoToMedalDTO(item));
            }

            return result;
        }
    }
}
