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
    public class MemberService : IService<MemberDTO>, IMemberService
    {
        private MemberRepository _repository;

        public MemberService()
        {
            _repository = new MemberRepository();
        }

        public IEnumerable<MemberDTO> GetAll()
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetAll());
        }

        public void Add(MemberDTO values)
        {
            _repository.Add(TranslateMemberDTOToMemberInfo(values));
        }

        public void Delete(MemberDTO values)
        {
            _repository.Delete(TranslateMemberDTOToMemberInfo(values));
        }

        public IEnumerable<MemberDTO> GetElementsByName(string name)
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetElementsByName(name));
        }

        public IEnumerable<MemberDTO> GetByLastName(string lastName)
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetByLastName(lastName));
        }

        public IEnumerable<MemberDTO> GetByAge(int age)
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetByAge(age));
        }

        public IEnumerable<MemberDTO> GetByGoldenMedals(int medals)
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetByGoldenMedals(medals));
        }

        public IEnumerable<MemberDTO> GetBySilverMedals(int medals)
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetBySilverMedals(medals));
        }
        public IEnumerable<MemberDTO> GetByBronzeMedals(int medals)
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetByBronzeMedals(medals));
        }

        public IEnumerable<MemberDTO> GetByCountry(string country)
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetByCountry(country));
        }

        public IEnumerable<MemberDTO> GetBySport(string sport)
        {
            return TranslateMemberInfoListToMemberDTOList(_repository.GetBySport(sport));
        }

        public void Update(MemberDTO values)
        {
            throw new NotImplementedException();
        }

        public MemberDTO GetByName(string name)
        {
            throw new NotImplementedException();
        }

        private MemberInfo TranslateMemberDTOToMemberInfo(MemberDTO member)
        {
            return new MemberInfo()
            {
                Id = member.Id,
                Name = member.Name,
                LastName = member.LastName,
                Age = member.Age,
                Birthday = member.Birthday,
                Sport = new SportInfo()
                {
                    Id = member.Sport.Id,
                    Name = member.Sport.Name,
                    CountOfTeams = member.Sport.CountOfTeams,
                    Olimpiad = new OlimpiadInfo()
                    {
                        Id = member.Sport.Olimpiad.Id,
                        Name = member.Sport.Olimpiad.Name,
                        Season = member.Sport.Olimpiad.Season,
                        CountOfMembers = member.Sport.Olimpiad.CountOfMembers,
                        EventDate = member.Sport.Olimpiad.EventDate,
                        EventCountry = new CountryInfo()
                        {
                            Id = member.Sport.Olimpiad.EventCountry.Id,
                            Name = member.Sport.Olimpiad.EventCountry.Name,
                            City = member.Sport.Olimpiad.EventCountry.City,
                            GoldMedalsCount = member.Sport.Olimpiad.EventCountry.GoldMedalsCount,
                            HostedOlimpiadsCount = member.Sport.Olimpiad.EventCountry.HostedOlimpiadsCount
                        }
                    }
                },
                Medals = new MedalInfo()
                {
                    Id = member.Medals.Id,
                    CountOfGold = member.Medals.CountOfGold,
                    CountOfSilver = member.Medals.CountOfSilver,
                    CountOfBronze = member.Medals.CountOfBronze
                },
                Country = new CountryInfo()
                {
                    Id = member.Country.Id,
                    Name = member.Country.Name,
                    City = member.Country.City,
                    GoldMedalsCount = member.Country.GoldMedalsCount,
                    HostedOlimpiadsCount = member.Country.HostedOlimpiadsCount
                }
            };
        }

        private MemberDTO TranslateMemberInfoToMemberDTO(MemberInfo member)
        {
            return new MemberDTO()
            {
                Id = member.Id,
                Name = member.Name,
                LastName = member.LastName,
                Age = member.Age,
                Birthday = member.Birthday,
                Sport = new SportDTO()
                {
                    Id = member.Sport.Id,
                    Name = member.Sport.Name,
                    CountOfTeams = member.Sport.CountOfTeams,
                    Olimpiad = new OlimpiadDTO()
                    {
                        Id = member.Sport.Olimpiad.Id,
                        Name = member.Sport.Olimpiad.Name,
                        Season = member.Sport.Olimpiad.Season,
                        CountOfMembers = member.Sport.Olimpiad.CountOfMembers,
                        EventDate = member.Sport.Olimpiad.EventDate,
                        EventCountry = new CountryDTO()
                        {
                            Id = member.Sport.Olimpiad.EventCountry.Id,
                            Name = member.Sport.Olimpiad.EventCountry.Name,
                            City = member.Sport.Olimpiad.EventCountry.City,
                            GoldMedalsCount = member.Sport.Olimpiad.EventCountry.GoldMedalsCount,
                            HostedOlimpiadsCount = member.Sport.Olimpiad.EventCountry.HostedOlimpiadsCount
                        }
                    }
                },
                Medals = new MedalStatisticDTO()
                {
                    Id = member.Medals.Id,
                    CountOfGold = member.Medals.CountOfGold,
                    CountOfSilver = member.Medals.CountOfSilver,
                    CountOfBronze = member.Medals.CountOfBronze
                },
                Country = new CountryDTO()
                {
                    Id = member.Country.Id,
                    Name = member.Country.Name,
                    City = member.Country.City,
                    GoldMedalsCount = member.Country.GoldMedalsCount,
                    HostedOlimpiadsCount = member.Country.HostedOlimpiadsCount
                }
            };
        }

        private List<MemberDTO> TranslateMemberInfoListToMemberDTOList(IEnumerable<MemberInfo> memberInfos)
        {
            List<MemberDTO> result = new List<MemberDTO>();

            foreach (MemberInfo item in memberInfos)
            {
                result.Add(TranslateMemberInfoToMemberDTO(item));
            }

            return result;
        }
    }
}
