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
    public class CountryService : IService<CountryDTO>, ICountryService
    {
        private CountryRepository _repository;

        public CountryService()
        {
            _repository = new CountryRepository();
        }

        public void Add(CountryDTO values)
        {
            _repository.Add(TranslateCountryDTOToCountryInfo(values));
        }

        public void Delete(CountryDTO values)
        {
            _repository.Delete(TranslateCountryDTOToCountryInfo(values));
        }

        public IEnumerable<CountryDTO> GetAll()
        {
            return TranslateCountryInfoListToCountryDTOList(_repository.GetAll());
        }

        public IEnumerable<CountryDTO> GetByCity(string city)
        {
            return TranslateCountryInfoListToCountryDTOList(_repository.GetByCity(city));
        }

        public IEnumerable<CountryDTO> GetByGoldenMedals(int medals)
        {
            return TranslateCountryInfoListToCountryDTOList(_repository.GetByGoldenMedals(medals));
        }

        public IEnumerable<CountryDTO> GetByHosts(int hosts)
        {
            return TranslateCountryInfoListToCountryDTOList(_repository.GetByHosts(hosts));
        }

        public IEnumerable<CountryDTO> GetElementsByName(string name)
        {
            return TranslateCountryInfoListToCountryDTOList(_repository.GetElementsByName(name));
        }

        public CountryDTO GetByName(string name)
        {
            return TranslateCountryInfoToCountryDTO(_repository.GetByName(name));
        }

        public IEnumerable<CountryDTO> GetByOlimpiadName(string olimpiadName)
        {
            return TranslateCountryInfoListToCountryDTOList(_repository.GetByOlimpiadName(olimpiadName));
        }

        public void Update(CountryDTO values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CountryDTO> GetAllElements()
        {
            throw new NotImplementedException();
        }

        private CountryInfo TranslateCountryDTOToCountryInfo(CountryDTO country)
        {
            return new CountryInfo()
            {
                Id = country.Id,
                Name = country.Name,
                City = country.City,
                GoldMedalsCount = country.GoldMedalsCount,
                HostedOlimpiadsCount = country.HostedOlimpiadsCount,
            };
        }

        private CountryDTO TranslateCountryInfoToCountryDTO(CountryInfo country)
        {
            return new CountryDTO()
            {
                Id = country.Id,
                Name = country.Name,
                City = country.City,
                GoldMedalsCount = country.GoldMedalsCount,
                HostedOlimpiadsCount = country.HostedOlimpiadsCount,
            };
        }

        private List<CountryDTO> TranslateCountryInfoListToCountryDTOList(IEnumerable<CountryInfo> olimpiadInfos)
        {
            List<CountryDTO> result = new List<CountryDTO>();

            foreach (CountryInfo item in olimpiadInfos)
            {
                result.Add(TranslateCountryInfoToCountryDTO(item));
            }

            return result;
        }
    }
}
