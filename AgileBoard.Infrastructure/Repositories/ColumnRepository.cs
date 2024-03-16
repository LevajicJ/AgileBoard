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
    public class ColumnRepository : IColumnRepository
    {
        private AgileBoardDbContext _dbContext;

        public ColumnRepository(AgileBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Column> Add(Column entity)
        {
            _dbContext.Column.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Column entity)
        {
            _dbContext.Column.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Column>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Column> GetById(int id)
        {
            return await _dbContext.Column.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Column> GetColumnIdFromBoardByColumnName(int boardId, string columnName)
        {
            return await _dbContext.Column.FirstOrDefaultAsync(c => c.BoardId == boardId && c.Name == columnName);
        }

        public async Task<List<Column>> GetColumnsFromBoard(int boardId)
        {
            return await _dbContext.Column.Where(c => c.BoardId == boardId).ToListAsync();
        }

        public Task<Column> Update(Column entity)
        {
            throw new NotImplementedException();
        }
    }
}
