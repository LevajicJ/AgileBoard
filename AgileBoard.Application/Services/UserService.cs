using AgileBoard.Application.DTOs;
using AgileBoard.Application.Interfaces;
using AgileBoard.Domain.Contracts;
using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            var userExists = await _userRepository.GetById(id);
            
            if (userExists == null)
            {
                throw new Exception("User with this ID doesn't exist");
            }

            return userExists;
        }

        public async Task<User> Login(UserLoginDTO userDto)
        {
            User authenticatedUser = await _userRepository.AuthenticateUser(userDto.Email, userDto.Password);

            if (authenticatedUser == null)
            {
                throw new Exception("Invalid email or password");
            }

            return authenticatedUser;
        }

        public async Task<User> Register(UserRegisterDTO userDto)
        {

            var userExists = await _userRepository.GetUserByEmail(userDto.Email);

            if (userExists == null)
            {
                User newUser = new User
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    Password = userDto.Password
                };

                return await _userRepository.Add(newUser);
                
            }

            throw new Exception("User with this email already exist");

        }

        public async Task<User> GetUserEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
                throw new Exception("User doesn't exist");

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null)
                throw new Exception("User does not exist");

            else
            {
                await _userRepository.Delete(user);
                return true;
            }

        }
    }
}
