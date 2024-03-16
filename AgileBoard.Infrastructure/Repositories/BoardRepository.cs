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
    public class BoardRepository : IBoardRepository
    {
        private AgileBoardDbContext _dbContext;
        public BoardRepository(AgileBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Board> Add(Board entity)
        {
            _dbContext.Board.Add(entity);
            await _dbContext.SaveChangesAsync();
            
            return entity;
        }

        public async Task<Board> Update(Board entity)
        {
            _dbContext.Board.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Board>> GetAllAsync()
        {
            return await _dbContext.Board.ToListAsync();
        }

        public async Task<Board> GetById(int id)
        {
            return await _dbContext.Board.Include(a => a.Columns)
                .ThenInclude(x => x.Cards)
                .Include(b => b.BoardUsers).ThenInclude(u => u.User) 
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(Board entity)
        {
            _dbContext.Board.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
