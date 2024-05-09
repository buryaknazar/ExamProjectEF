using BLL.Interfaces;
using BLL.Models;
using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OlimpiadService : IService<OlimpiadDTO>, IOlimpiadService
    {
        private OlimpiadRepository _repository;

        public OlimpiadService()
        {
            _repository = new OlimpiadRepository();
        }

        public void Add(OlimpiadDTO values)
        {
            _repository.Add(TranslateOlimpiadDTOToOlimpiadInfo(values));
        }

        public void Delete(OlimpiadDTO values)
        {
            _repository.Delete(TranslateOlimpiadDTOToOlimpiadInfo(values));
        }

        public IEnumerable<OlimpiadDTO> GetAll()
        {
            return TranslateOlimpiadInfoListToOlimpiadDTOList(_repository.GetAll());
        }

        public IEnumerable<OlimpiadDTO> GetByCountOfMembers(int CountOfMembers)
        {
            return TranslateOlimpiadInfoListToOlimpiadDTOList(_repository.GetByCountOfMembers(CountOfMembers));
        }

        public IEnumerable<OlimpiadDTO> GetByCountry(string country)
        {
            return TranslateOlimpiadInfoListToOlimpiadDTOList(_repository.GetByCountry(country));
        }

        public IEnumerable<OlimpiadDTO> GetByEventDate(DateTime eventDate)
        {
            return TranslateOlimpiadInfoListToOlimpiadDTOList(_repository.GetByEventDate(eventDate));
        }

        public OlimpiadDTO GetByName(string name)
        {
            return TranslateOlimpiadInfoToOlimpiadDTO(_repository.GetByName(name));
        }

        public IEnumerable<OlimpiadDTO> GetBySeason(string season)
        {
            return TranslateOlimpiadInfoListToOlimpiadDTOList(_repository.GetBySeason(season));
        }

        public void Update(OlimpiadDTO values)
        {
            _repository.Update(TranslateOlimpiadDTOToOlimpiadInfo(values));
        }

        private OlimpiadInfo TranslateOlimpiadDTOToOlimpiadInfo(OlimpiadDTO olimpiad)
        {
            if (olimpiad.EventCountry == null)
            {
                return new OlimpiadInfo()
                {
                    Id = olimpiad.Id,
                    Name = olimpiad.Name,
                    Season = olimpiad.Season,
                    EventDate = olimpiad.EventDate,
                    CountOfMembers = olimpiad.CountOfMembers,
                    EventCountry = null
                };
            }

            return new OlimpiadInfo()
            {
                Id = olimpiad.Id,
                Name = olimpiad.Name,
                Season = olimpiad.Season,
                EventDate = olimpiad.EventDate,
                CountOfMembers = olimpiad.CountOfMembers,
                EventCountry = new CountryInfo()
                {
                    Id = olimpiad.EventCountry.Id,
                    Name = olimpiad.EventCountry.Name,
                    City = olimpiad.EventCountry.City,
                    GoldMedalsCount = olimpiad.EventCountry.GoldMedalsCount,
                    HostedOlimpiadsCount = olimpiad.EventCountry.HostedOlimpiadsCount
                }
            };
        }

        private OlimpiadDTO TranslateOlimpiadInfoToOlimpiadDTO(OlimpiadInfo olimpiad)
        {
            if(olimpiad.EventCountry == null)
            {
                return new OlimpiadDTO()
                {
                    Id = olimpiad.Id,
                    Name = olimpiad.Name,
                    Season = olimpiad.Season,
                    EventDate = olimpiad.EventDate,
                    CountOfMembers = olimpiad.CountOfMembers,
                    EventCountry = null
                };
            }

            return new OlimpiadDTO()
            {
                Id = olimpiad.Id,
                Name = olimpiad.Name,
                Season = olimpiad.Season,
                EventDate = olimpiad.EventDate,
                CountOfMembers = olimpiad.CountOfMembers,
                EventCountry = new CountryDTO()
                {
                    Id = olimpiad.EventCountry.Id,
                    Name = olimpiad.EventCountry.Name,
                    City = olimpiad.EventCountry.City,
                    GoldMedalsCount = olimpiad.EventCountry.GoldMedalsCount,
                    HostedOlimpiadsCount = olimpiad.EventCountry.HostedOlimpiadsCount
                }
            };
        }

        private List<OlimpiadDTO> TranslateOlimpiadInfoListToOlimpiadDTOList(IEnumerable<OlimpiadInfo> olimpiadInfos)
        {
            List<OlimpiadDTO> result = new List<OlimpiadDTO>();

            foreach (OlimpiadInfo item in olimpiadInfos)
            {
                result.Add(TranslateOlimpiadInfoToOlimpiadDTO(item));
            }

            return result;
        }
    }
}
