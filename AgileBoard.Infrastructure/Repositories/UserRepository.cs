using AgileBoard.Domain.Contracts;
using AgileBoard.Domain.Models;
using AgileBoard.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AgileBoardDbContext _dbContext;

        public UserRepository(AgileBoardDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<User> Add(User entity)
        {
            _dbContext.User.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            User user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email
                                                                && u.Password == password);

            return user;
        }

        public async Task Delete(User entity)
        {
            _dbContext.User.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);

        }


        public async Task<User> Update(User entity)
        {
            _dbContext.User.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    

        
    }
}
