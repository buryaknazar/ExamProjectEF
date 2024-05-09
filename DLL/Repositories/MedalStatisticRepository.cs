using DLL.Contexts;
using DLL.Interfaces;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DLL.Repositories
{
    public class MedalStatisticRepository : IRepository<MedalInfo>, IMedalStatisticRepository
    {
        private OlimpiaContext _context;

        public MedalStatisticRepository()
        {
            _context = new OlimpiaContext();
        }

        public void Add(MedalInfo values)
        {
            _context.MedalsStatistics.Add(values);
            _context.SaveChanges();
        }

        public void Delete(MedalInfo values)
        {
            if (values != null)
            {
                MedalInfo tempMedal = _context.MedalsStatistics.Where(m => m.Id == values.Id).First();

                if (tempMedal != null)
                {
                    _context.MedalsStatistics.Remove(tempMedal);

                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<MedalInfo> GetAll()
        {
            return _context.MedalsStatistics;
        }

        public IEnumerable<MedalStatisticWithMember> GetMedalStatisticByBronzeAmount(int bronzeMedals)
        {
            var medalInfoList = _context.Members
            .Where(member => member.Medals.CountOfBronze == bronzeMedals)
            .Select(member => new MedalStatisticWithMember
            {
                Name = member.Name,
                LastName = member.LastName,
                Medals = member.Medals
            })
            .ToList();

            return medalInfoList;
        }

        public IEnumerable<MedalStatisticWithMember> GetMedalStatisticByGoldenAmount(int goldenMedals)
        {
            var medalInfoList = _context.Members
            .Where(member => member.Medals.CountOfGold == goldenMedals)
            .Select(member => new MedalStatisticWithMember
            {
                Name = member.Name,
                LastName = member.LastName,
                Medals = member.Medals
            })
            .ToList();

            return medalInfoList;
        }

        public IEnumerable<MedalStatisticWithMember> GetMedalStatisticBySilverAmount(int silverMedals)
        {
            var medalInfoList = _context.Members
            .Where(member => member.Medals.CountOfSilver == silverMedals)
            .Select(member => new MedalStatisticWithMember
            {
                Name = member.Name,
                LastName = member.LastName,
                Medals = member.Medals
            })
            .ToList();

            return medalInfoList;
        }

        public IEnumerable<MedalStatisticWithMember> GetMembersStatisticByName(string name)
        {
            var medalInfoList = _context.Members
            .Where(member => member.Name == name)
            .Select(member => new MedalStatisticWithMember
            {
                Name = member.Name,
                LastName = member.LastName,
                Medals = member.Medals
            })
            .ToList();

            return medalInfoList;
        }

        public IEnumerable<MedalStatisticWithMember> GetMembersStatisticByLastName(string lastName)
        {
            var medalInfoList = _context.Members
            .Where(member => member.LastName == lastName)
            .Select(member => new MedalStatisticWithMember
            {
                Name = member.Name,
                LastName = member.LastName,
                Medals = member.Medals
            })
            .ToList();

            return medalInfoList;
        }

        public IEnumerable<MedalStatisticWithMember> GetAllElements()
        {
            var medalInfoList = _context.Members
            .Select(member => new MedalStatisticWithMember
            {
                Name = member.Name,
                LastName = member.LastName,
                Medals = member.Medals
            })
            .ToList();

            return medalInfoList;
        }

        public void DeleteElement(MedalStatisticWithMember values)
        {
            if (values != null)
            {
                MedalInfo tempMedals = _context.MedalsStatistics.Where(m => m.Id == values.Medals.Id).First();

                if (tempMedals != null)
                {
                    _context.MedalsStatistics.Remove(tempMedals);

                    _context.SaveChanges();
                }
            }
        }

        public void UpdateElement(MedalStatisticWithMember values)
        {
            if(values != null)
            {
                MedalInfo tempMedals = _context.MedalsStatistics.Where(m => m.Id == values.Medals.Id).First();

                if(tempMedals != null)
                {
                    tempMedals.CountOfGold = values.Medals.CountOfGold;
                    tempMedals.CountOfSilver = values.Medals.CountOfSilver;
                    tempMedals.CountOfBronze = values.Medals.CountOfBronze;

                    _context.SaveChanges();
                }
            }
        }

        public void Update(MedalInfo values)
        {
            throw new NotImplementedException();
        }

        public MedalInfo GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
