using DLL.Contexts;
using DLL.Interfaces;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class CountryRepository : IRepository<CountryInfo>, ICountryRepository
    {
        private OlimpiaContext _context;

        public CountryRepository()
        {
            _context = new OlimpiaContext();
        }

        public void Add(CountryInfo values)
        {
            _context.Countries.Add(values);
            _context.SaveChanges();
        }

        public void Delete(CountryInfo values)
        {
            if (values != null)
            {
                CountryInfo tempCountry = _context.Countries.Where(c => c.Id == values.Id).First();
                OlimpiadInfo tempOlimpiad = _context.Olimpiads.Include(o => o.EventCountry).Where(o => o.EventCountry.Id == tempCountry.Id).First();

                if (tempCountry != null)
                {
                    tempOlimpiad.EventCountry = null;
                    _context.SaveChanges();

                    _context.Countries.Remove(tempCountry);

                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<CountryInfo> GetAll()
        {
            var countryInfoList = (
                from cnt in _context.Countries
                join mbr in _context.Members on cnt.Id equals mbr.Country.Id into memberGroup
                from mbr in memberGroup.DefaultIfEmpty()
                join olimpiad in _context.Olimpiads on cnt.Id equals olimpiad.EventCountry.Id into olimpiadGroup
                from olimpiad in olimpiadGroup.DefaultIfEmpty()
                join ms in _context.MedalsStatistics on mbr.Medals.Id equals ms.Id into medalGroup
                from ms in medalGroup.DefaultIfEmpty()
                group new { cnt, olimpiad, ms } by new
                {
                    CountryId = cnt.Id,
                    CountryName = cnt.Name,
                    CountryCity = cnt.City
                } into grouped
                select new
                {
                    CountryId = grouped.Key.CountryId,
                    CountryName = grouped.Key.CountryName,
                    CountryCity = grouped.Key.CountryCity,
                    GoldMedalsCount = grouped.Sum(g => g.ms != null ? g.ms.CountOfGold : 0),
                    HostedOlimpiadsCount = grouped.Select(g => g.olimpiad).Where(o => o != null).Distinct().Count()
                }).ToList();

            return countryInfoList
                .Select(result => new CountryInfo
                {
                    Id = result.CountryId,
                    Name = result.CountryName,
                    City = result.CountryCity,
                    GoldMedalsCount = result.GoldMedalsCount,
                    HostedOlimpiadsCount = result.HostedOlimpiadsCount
                })
                .ToList();
        }





        public IEnumerable<CountryInfo> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CountryInfo> GetByCity(string city)
        {
            var countries = (from cnt in _context.Countries
                             join mbr in _context.Members on cnt.Id equals mbr.Country.Id into memberGroup
                             from mbr in memberGroup.DefaultIfEmpty()
                             join olimpiad in _context.Olimpiads on cnt.Id equals olimpiad.EventCountry.Id into olimpiadGroup
                             from olimpiad in olimpiadGroup.DefaultIfEmpty()
                             join ms in _context.MedalsStatistics on mbr.Medals.Id equals ms.Id into medalGroup
                             from ms in medalGroup.DefaultIfEmpty()
                             group new { cnt, olimpiad, mbr } by new
                             {
                                 CountryId = cnt.Id,
                                 CountryName = cnt.Name,
                                 CountryCity = cnt.City
                             } into grouped
                             select new
                             {
                                 Id = grouped.Key.CountryId,
                                 Name = grouped.Key.CountryName,
                                 City = grouped.Key.CountryCity,
                                 GoldMedalsCount = grouped.Sum(ms => ms.mbr.Medals.CountOfGold),
                                 HostedOlimpiadsCount = grouped.Select(o => o.olimpiad).Where(o => o != null).Distinct().Count()
                             }).Where(c => c.City == city).ToList();


            return countries
                .Select(result => new CountryInfo
                {
                    Id = result.Id,
                    Name = result.Name,
                    City = result.City,
                    GoldMedalsCount = result.GoldMedalsCount,
                    HostedOlimpiadsCount = result.HostedOlimpiadsCount
                })
                .ToList();
        }

        public IEnumerable<CountryInfo> GetByGoldenMedals(int medals)
        {
            var countryInfoList = (
                from country in _context.Countries
                join member in _context.Members on country.Id equals member.Country.Id into memberGroup
                from member in memberGroup.DefaultIfEmpty()
                join olimpiad in _context.Olimpiads on country.Id equals olimpiad.EventCountry.Id into olimpiadGroup
                from olimpiad in olimpiadGroup.DefaultIfEmpty()
                group new { country, member, olimpiad } by new
                {
                    CountryId = country.Id,
                    CountryName = country.Name,
                    CountryCity = country.City
                } into grouped
                select new
                {
                    Id = grouped.Key.CountryId,
                    Name = grouped.Key.CountryName,
                    City = grouped.Key.CountryCity,
                    GoldMedalsCount = grouped.Sum(g => g.member != null ? g.member.Medals.CountOfGold : 0),
                    HostedOlimpiadsCount = grouped.Select(g => g.olimpiad).Where(o => o != null).Distinct().Count()
                }).Where(c => c.GoldMedalsCount == medals).ToList();

                return countryInfoList
                .Select(result => new CountryInfo
                {
                    Id = result.Id,
                    Name = result.Name,
                    City = result.City,
                    GoldMedalsCount = result.GoldMedalsCount,
                    HostedOlimpiadsCount = result.HostedOlimpiadsCount
                })
                .ToList();
        }

        public IEnumerable<CountryInfo> GetByHosts(int hosts)
        {
            var countryInfoList = (
                from country in _context.Countries
                join member in _context.Members on country.Id equals member.Country.Id into memberGroup
                from member in memberGroup.DefaultIfEmpty()
                join olimpiad in _context.Olimpiads on country.Id equals olimpiad.EventCountry.Id into olimpiadGroup
                from olimpiad in olimpiadGroup.DefaultIfEmpty()
                group new { country, member, olimpiad } by new
                {
                    CountryId = country.Id,
                    CountryName = country.Name,
                    CountryCity = country.City
                } into grouped
                select new
                {
                    Id = grouped.Key.CountryId,
                    Name = grouped.Key.CountryName,
                    City = grouped.Key.CountryCity,
                    GoldMedalsCount = grouped.Sum(g => g.member != null ? g.member.Medals.CountOfGold : 0),
                    HostedOlimpiadsCount = grouped.Select(g => g.olimpiad).Where(o => o != null).Distinct().Count()
                }).Where(c => c.HostedOlimpiadsCount == hosts).ToList();

                 return countryInfoList
                .Select(result => new CountryInfo
                {
                    Id = result.Id,
                    Name = result.Name,
                    City = result.City,
                    GoldMedalsCount = result.GoldMedalsCount,
                    HostedOlimpiadsCount = result.HostedOlimpiadsCount
                })
                .ToList();
        }


        public CountryInfo GetByName(string name)
        {
            return _context.Countries.Where(c => c.Name == name).FirstOrDefault();
        }

        public IEnumerable<CountryInfo> GetByOlimpiadName(string olimpiadName)
        {
                        var countryInfoList = (
                from cnt in _context.Countries
                join mbr in _context.Members on cnt.Id equals mbr.Country.Id into memberGroup
                from mbr in memberGroup.DefaultIfEmpty()
                join olimpiad in _context.Olimpiads on cnt.Id equals olimpiad.EventCountry.Id into olimpiadGroup
                from olimpiad in olimpiadGroup.DefaultIfEmpty()
                join ms in _context.MedalsStatistics on mbr.Medals.Id equals ms.Id into medalGroup
                from ms in medalGroup.DefaultIfEmpty()
                where olimpiad.Name == olimpiadName 
                group new { cnt, olimpiad, ms } by new
                {
                    CountryId = cnt.Id,
                    CountryName = cnt.Name,
                    CountryCity = cnt.City
                } into grouped
                select new
                {
                    CountryId = grouped.Key.CountryId,
                    CountryName = grouped.Key.CountryName,
                    CountryCity = grouped.Key.CountryCity,
                    GoldMedalsCount = grouped.Sum(g => g.ms != null ? g.ms.CountOfGold : 0),
                    HostedOlimpiadsCount = grouped.Select(g => g.olimpiad).Where(o => o != null).Distinct().Count()
                }).ToList();

            return countryInfoList
                .Select(result => new CountryInfo
                {
                    Id = result.CountryId,
                    Name = result.CountryName,
                    City = result.CountryCity,
                    GoldMedalsCount = result.GoldMedalsCount,
                    HostedOlimpiadsCount = result.HostedOlimpiadsCount
                })
                .ToList();
        }

        public IEnumerable<CountryInfo> GetElementsByName(string name)
        {
            var countries = (from cnt in _context.Countries
                             join mbr in _context.Members on cnt.Id equals mbr.Country.Id into memberGroup
                             from mbr in memberGroup.DefaultIfEmpty()
                             join olimpiad in _context.Olimpiads on cnt.Id equals olimpiad.EventCountry.Id into olimpiadGroup
                             from olimpiad in olimpiadGroup.DefaultIfEmpty()
                             join ms in _context.MedalsStatistics on mbr.Medals.Id equals ms.Id into medalGroup
                             from ms in medalGroup.DefaultIfEmpty()
                             group new { cnt, olimpiad, mbr } by new
                             {
                                 CountryId = cnt.Id,
                                 CountryName = cnt.Name,
                                 CountryCity = cnt.City
                             } into grouped
                             select new
                             {
                                 Id = grouped.Key.CountryId,
                                 Name = grouped.Key.CountryName,
                                 City = grouped.Key.CountryCity,
                                 GoldMedalsCount = grouped.Sum(ms => ms.mbr.Medals.CountOfGold),
                                 HostedOlimpiadsCount = grouped.Select(o => o.olimpiad).Where(o => o != null).Distinct().Count()
                             }).Where(c => c.Name == name).ToList();


            return countries
                .Select(result => new CountryInfo
                {
                    Id = result.Id,
                    Name = result.Name,
                    City = result.City,
                    GoldMedalsCount = result.GoldMedalsCount,
                    HostedOlimpiadsCount = result.HostedOlimpiadsCount
                })
                .ToList();
        }

        public void Update(CountryInfo values)
        {
            if (values != null)
            {
                CountryInfo tempCountry = _context.Countries.Where(c => c.Id == values.Id).First();

                if(tempCountry != null)
                {
                    tempCountry.Name = values.Name;
                    tempCountry.City = values.City;

                    _context.SaveChanges();
                }
            }
        }
    }
}
