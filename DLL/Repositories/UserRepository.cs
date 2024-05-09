using DLL.Contexts;
using DLL.Interfaces;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserContext _context;

        public UserRepository()
        {
            _context = new UserContext();
        }

        public void Add(UserInfo userInfo)
        {
            _context.Users.Add(userInfo);
            _context.SaveChanges();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool isValidUser = false;

            if(credential != null) 
            {
                var userInfo = _context.Users.Where(u => u.Username == credential.UserName && u.Password == credential.Password).FirstOrDefault();

                if(userInfo != null)
                {
                    isValidUser = true;
                }
            }

            return isValidUser;
        }

        public void Edit(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInfo> GetAll()
        {
            return _context.Users;
        }

        public UserInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetByUsername(string username)
        {
            return _context.Users.Where(u => u.Username == username).FirstOrDefault();
        }



        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
