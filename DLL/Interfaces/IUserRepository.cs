using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserInfo userInfo);
        void Edit(UserInfo userInfo);
        void Remove(int id);

        UserInfo GetById(int id);
        UserInfo GetByUsername(string username);
        IEnumerable<UserInfo> GetAll();
    }
}
