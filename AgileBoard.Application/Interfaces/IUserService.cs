using AgileBoard.Application.DTOs;
using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(UserLoginDTO userDto);
        Task<User> Register(UserRegisterDTO userDto);
        Task<User> GetUserById(int id);
        Task<User> GetUserEmail(string email);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> DeleteUser(int userId);
    }
}
