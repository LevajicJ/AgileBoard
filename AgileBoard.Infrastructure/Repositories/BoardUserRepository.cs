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
    public class BoardUserRepository : IBoardUserRepository
    {
        private AgileBoardDbContext _dbContext;
        public BoardUserRepository(AgileBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BoardUser> Add(BoardUser entity)
        {
            _dbContext.BoardUsers.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task Delete(BoardUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<BoardUser> DeleteUserFromBoard(BoardUser boardUser)
        {
            _dbContext.BoardUsers.Remove(boardUser);
            await _dbContext.SaveChangesAsync();

            return boardUser;
        }

        public Task<IEnumerable<BoardUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BoardUser>> GetBoardsByUserId(int userId)
        {
            return await _dbContext.BoardUsers.Include(b => b.Board)
                .Where(bu => bu.UserId == userId).ToListAsync();
        }

        public Task<BoardUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BoardUser> Update(BoardUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
