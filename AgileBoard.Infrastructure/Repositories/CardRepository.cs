using AgileBoard.Domain.Contracts;
using AgileBoard.Domain.Models;
using AgileBoard.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private AgileBoardDbContext _dbContext;

        public CardRepository(AgileBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Card> Add(Card entity)
        {
            _dbContext.Card.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }


        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _dbContext.Card.ToListAsync();
        }

        public async Task<Card> GetById(int id)
        {
            return await _dbContext.Card.Include(com => com.Comments)
                                        .ThenInclude(u => u.User)
                                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Card>> GetCardsFromColumn(int columnId)
        {
            return await _dbContext.Card.Include(com => com.Comments).ThenInclude(u => u.User).Where(c => c.ColumnId == columnId).ToListAsync();
        }

        public async Task<Card> Update(Card entity)
        {
            _dbContext.Card.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Card> ChangeCardColumn(int cardId, int columnId)
        {
            var card = await _dbContext.Card.FindAsync(cardId);
            card.ColumnId = columnId;
            await _dbContext.SaveChangesAsync();
            return card;
            //throw new NotImplementedException();
        }

        public async Task Delete(Card entity)
        {
            _dbContext.Card.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
