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
    public class CommentRepository : ICommentRepository
    {
        private AgileBoardDbContext _dbContext;
        public CommentRepository(AgileBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> Add(Comment entity)
        {
            _dbContext.Comment.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Comment entity)
        {
            _dbContext.Comment.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _dbContext.Comment.ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _dbContext.Comment.FirstOrDefaultAsync();
        }

        public Task<Comment> Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
