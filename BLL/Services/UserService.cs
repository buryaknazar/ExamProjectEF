using BLL.Interfaces;
using BLL.Models;
using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void Add(UserDTO userInfo)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            return _userRepository.AuthenticateUser(credential);
        }

        public void Edit(UserDTO userInfo)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }
        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
        public UserDTO GetByUsername(string username)
        {
            return UserInfoToUserDTO(_userRepository.GetByUsername(username));
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        private UserDTO UserInfoToUserDTO(UserInfo userInfo)
        {
            return new UserDTO()
            {
                Id = userInfo.Id,
                Username = userInfo.Username,
                Password = userInfo.Password,
                Name = userInfo.Name,
            };
        }
    }
}
