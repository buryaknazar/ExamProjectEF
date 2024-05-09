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
    public class OlimpiadRepository : IRepository<OlimpiadInfo>, IOlimpiadRepository
    {
        private OlimpiaContext _context;

        public OlimpiadRepository()
        {
            _context = new OlimpiaContext();
        }

        public void Add(OlimpiadInfo values)
        {
            OlimpiadInfo newOlimpiad = new OlimpiadInfo()
            {
                Id = values.Id,
                Name = values.Name,
                Season = values.Season,
                EventDate = values.EventDate,
                CountOfMembers = values.CountOfMembers,
                EventCountry = _context.Countries.Where(c => c.Name == values.EventCountry.Name).First()
            };

            _context.Olimpiads.Add(newOlimpiad);
            _context.SaveChanges();
        }

        public void Delete(OlimpiadInfo values)
        {
            if (values != null)
            {
                OlimpiadInfo tempOlimpiad = _context.Olimpiads.Where(c => c.Id == values.Id).First();

                if (tempOlimpiad != null)
                {
                    _context.Olimpiads.Remove(tempOlimpiad);

                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<OlimpiadInfo> GetAll()
        {
            return _context.Olimpiads.Include(o => o.EventCountry);
        }

        public IEnumerable<OlimpiadInfo> GetByCountOfMembers(int CountOfMembers)
        {
            return _context.Olimpiads.Where(o => o.CountOfMembers == CountOfMembers);
        }

        public IEnumerable<OlimpiadInfo> GetByCountry(string country)
        {
            return _context.Olimpiads.Where(o => o.EventCountry.Name == country);
        }

        public IEnumerable<OlimpiadInfo> GetByEventDate(DateTime eventDate)
        {
            return _context.Olimpiads.Where(o => o.EventDate == eventDate);
        }

        public OlimpiadInfo GetByName(string name)
        {
            return _context.Olimpiads.Where(o => o.Name == name).FirstOrDefault();
        }

        public IEnumerable<OlimpiadInfo> GetBySeason(string season)
        {
            return _context.Olimpiads.Where(o => o.Season == season);
        }

        public void Update(OlimpiadInfo values)
        {
            if (values != null)
            {
                OlimpiadInfo tempOlimpiad = _context.Olimpiads.Where(o => o.Id == values.Id).First();

                if (tempOlimpiad != null)
                {
                    tempOlimpiad.Name = values.Name;
                    tempOlimpiad.Season = values.Season;
                    tempOlimpiad.EventDate = values.EventDate;
                    tempOlimpiad.CountOfMembers = values.CountOfMembers;
                    tempOlimpiad.EventCountry.Name = values.EventCountry.Name;
                    tempOlimpiad.EventCountry.City = values.EventCountry.City;

                    _context.SaveChanges();
                }
            }
        }
    }
}
