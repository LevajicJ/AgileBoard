﻿using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Domain.Contracts
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<List<Card>> GetCardsFromColumn(int columnId);
        Task<Card> ChangeCardColumn(int cardId, int columnId);
    }
}
