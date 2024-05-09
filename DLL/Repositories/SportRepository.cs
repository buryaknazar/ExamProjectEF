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
    public class SportRepository : IRepository<SportInfo>, ISportRepository
    {
        private OlimpiaContext _context;

        public SportRepository()
        {
            _context = new OlimpiaContext();
        }

        public void Add(SportInfo values)
        {
            SportInfo newSport = new SportInfo()
            {
                Id = values.Id,
                Name = values.Name,
                CountOfTeams = values.CountOfTeams,
                Olimpiad = _context.Olimpiads.Where(o => o.Id == values.Olimpiad.Id).First()
            };

            if(newSport.Olimpiad != null)
            {
                _context.Sports.Add(newSport);
                _context.SaveChanges();
            }
        }

        public void Delete(SportInfo values)
        {
            if (values != null)
            {
                SportInfo tempSport = _context.Sports.Where(c => c.Id == values.Id).First();

                if (tempSport != null)
                {
                    _context.Sports.Remove(tempSport);

                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<SportInfo> GetAll()
        {
            return _context.Sports.Include(s => s.Olimpiad);
        }

        public IEnumerable<SportInfo> GetByMaxTeams(int teams)
        {
            return _context.Sports.Include(s => s.Olimpiad).Where(s => s.CountOfTeams == teams);
        }

        public IEnumerable<SportInfo> GetByOlimpiad(string olimpiad)
        {
            return _context.Sports.Include(s => s.Olimpiad).Where(s => s.Olimpiad.Name == olimpiad);
        }

        public IEnumerable<SportInfo> GetElementsByName(string name)
        {
            return _context.Sports.Include(s => s.Olimpiad).Where(s => s.Name == name);
        }

        public void Update(SportInfo values)
        {
            if (values != null)
            {
                SportInfo tempSport = _context.Sports.Where(s => s.Id == values.Id).First();

                if(tempSport != null)
                {
                    tempSport.Name = values.Name;
                    tempSport.CountOfTeams = values.CountOfTeams;
                    tempSport.Olimpiad = _context.Olimpiads.Where(o => o.Id == values.Olimpiad.Id).First();

                    _context.SaveChanges();
                }
            }
        }

        public SportInfo GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
