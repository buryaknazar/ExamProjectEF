using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserDTO userInfo);
        void Edit(UserDTO userInfo);
        void Remove(int id);

        UserDTO GetById(int id);
        UserDTO GetByUsername(string username);
        IEnumerable<UserDTO> GetAll();
    }
}
