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
    public class MemberRepository : IRepository<MemberInfo>, IMemberRepository
    {
        private OlimpiaContext _context;

        public MemberRepository()
        {
            _context = new OlimpiaContext();
        }

        public void Add(MemberInfo values)
        {
            MemberInfo newMember = new MemberInfo()
            {
                Id = values.Id,
                Name = values.Name,
                LastName = values.LastName,
                Age = values.Age,
                Birthday = values.Birthday,
                Country = _context.Countries.Where(c => c.Id == values.Country.Id).First(),
                Sport = _context.Sports.Where(s => s.Id == values.Sport.Id).First(),
                Medals = _context.MedalsStatistics.Where(m => m.Id == values.Medals.Id).First()
            };

            _context.Members.Add(newMember);
            _context.SaveChanges();
        }

        public void Delete(MemberInfo values)
        {
            if (values != null)
            {
                MemberInfo tempMember = _context.Members.Where(m => m.Id == values.Id).First();

                if (tempMember != null)
                {
                    _context.Members.Remove(tempMember);

                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<MemberInfo> GetAll()
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country);
        }

        public IEnumerable<MemberInfo> GetElementsByName(string name)
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country).Where(m => m.Name == name);
        }

        public IEnumerable<MemberInfo> GetByAge(int age)
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country).Where(m => m.Age == age);
        }

        public IEnumerable<MemberInfo> GetByCountry(string country)
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country).Where(m => m.Country.Name == country);
        }

        public IEnumerable<MemberInfo> GetByGoldenMedals(int medals)
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country).Where(m => m.Medals.CountOfGold == medals);
        }

        public IEnumerable<MemberInfo> GetBySilverMedals(int medals)
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country).Where(m => m.Medals.CountOfSilver == medals);
        }
        public IEnumerable<MemberInfo> GetByBronzeMedals(int medals)
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country).Where(m => m.Medals.CountOfBronze == medals);
        }

        public IEnumerable<MemberInfo> GetByLastName(string lastName)
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country).Where(m => m.LastName == lastName);
        }

        public IEnumerable<MemberInfo> GetBySport(string sport)
        {
            return _context.Members.Include(m => m.Sport).Include(m => m.Medals).Include(m => m.Country).Where(m => m.Sport.Name == sport);
        }

        public void Update(MemberInfo values)
        {
            if(values != null)
            {
                MemberInfo tempMember = _context.Members.Where(m => m.Id == values.Id).First();

                if(tempMember != null)
                {
                    tempMember.Name = values.Name;
                    tempMember.LastName = values.LastName;
                    tempMember.Age = values.Age;
                    tempMember.Birthday = values.Birthday;
                    tempMember.Sport = _context.Sports.Where(s => s.Id == values.Sport.Id).First();
                    tempMember.Country = _context.Countries.Where(c => c.Id == values.Country.Id).First();
                    tempMember.Medals = _context.MedalsStatistics.Where(ms => ms.Id == values.Medals.Id).First();

                    _context.SaveChanges();
                }
            }
        }
        public MemberInfo GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
