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
    public class SportService : IService<SportDTO>, ISportService
    {
        private SportRepository _repository;

        public SportService()
        {
            _repository = new SportRepository();
        }

        public IEnumerable<SportDTO> GetAll()
        {
            return TranslateSportInfoListToSportDTOList(_repository.GetAll());
        }

        public void Add(SportDTO values)
        {
            _repository.Add(TranslateSportDTOToSportInfo(values));
        }

        public void Delete(SportDTO values)
        {
            _repository.Delete(TranslateSportDTOToSportInfo(values));
        }

        public IEnumerable<SportDTO> GetElementsByName(string name)
        {
            return TranslateSportInfoListToSportDTOList(_repository.GetElementsByName(name));
        }

        public IEnumerable<SportDTO> GetByMaxTeams(int teams)
        {
            return TranslateSportInfoListToSportDTOList(_repository.GetByMaxTeams(teams));
        }

        public IEnumerable<SportDTO> GetByOlimpiad(string olimpiad)
        {
            return TranslateSportInfoListToSportDTOList(_repository.GetByOlimpiad(olimpiad));
        }

        public void Update(SportDTO values)
        {
            throw new NotImplementedException();
        }

        public SportDTO GetByName(string name)
        {
            throw new NotImplementedException();
        }

        private SportInfo TranslateSportDTOToSportInfo(SportDTO sport)
        {
            return new SportInfo()
            {
                Id = sport.Id,
                Name = sport.Name,
                CountOfTeams = sport.CountOfTeams,
                Olimpiad = new OlimpiadInfo()
                {
                    Id = sport.Olimpiad.Id,
                    Name = sport.Olimpiad.Name,
                    Season = sport.Olimpiad.Season,
                    CountOfMembers = sport.Olimpiad.CountOfMembers,
                    EventCountry = new CountryInfo()
                    {
                        Id = sport.Olimpiad.EventCountry.Id,
                        Name = sport.Olimpiad.EventCountry.Name,
                        City = sport.Olimpiad.EventCountry.City,
                        GoldMedalsCount = sport.Olimpiad.EventCountry.GoldMedalsCount,
                        HostedOlimpiadsCount = sport.Olimpiad.EventCountry.HostedOlimpiadsCount
                    }
                }
            };
        }

        private SportDTO TranslateSportInfoToSportDTO(SportInfo sport)
        {
            return new SportDTO()
            {
                Id = sport.Id,
                Name = sport.Name,
                CountOfTeams = sport.CountOfTeams,
                Olimpiad = new OlimpiadDTO()
                {
                    Id = sport.Olimpiad.Id,
                    Name = sport.Olimpiad.Name,
                    Season = sport.Olimpiad.Season,
                    CountOfMembers = sport.Olimpiad.CountOfMembers,
                    EventCountry = new CountryDTO()
                    {
                        Id = sport.Olimpiad.EventCountry.Id,
                        Name = sport.Olimpiad.EventCountry.Name,
                        City = sport.Olimpiad.EventCountry.City,
                        GoldMedalsCount = sport.Olimpiad.EventCountry.GoldMedalsCount,
                        HostedOlimpiadsCount = sport.Olimpiad.EventCountry.HostedOlimpiadsCount
                    }
                }
            };
        }

        private List<SportDTO> TranslateSportInfoListToSportDTOList(IEnumerable<SportInfo> sportInfos)
        {
            List<SportDTO> result = new List<SportDTO>();

            foreach (SportInfo item in sportInfos)
            {
                result.Add(TranslateSportInfoToSportDTO(item));
            }

            return result;
        }
    }
}
