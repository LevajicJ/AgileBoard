using AgileBoard.Application.DTOs;
using AgileBoard.Domain.Models;

namespace AgileBoard.UI.Services
{
    public interface IUserService
    {
        Task<string> Login(UserLoginDTO userLoginDto);
        Task<bool> Register(UserRegisterDTO userRegisterDto);
        Task<int> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> DeleteUser(int userId);
    }
}
