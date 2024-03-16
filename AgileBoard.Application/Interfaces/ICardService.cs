using AgileBoard.Application.DTOs;
using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.Interfaces
{
    public interface ICardService
    {
        Task<CardDTO> Create(CardDTO cardDto);
        Task<List<ColumnWithCards>> GetColumnsAndCards(int boardId);
        Task<Card> GetCardById(int cardId);
        Task<Card> ChangeCardColumn(int cardId, int newColumnId);
        Task<Card> AssignUserToCard(int cardId, int userId);
        Task<bool> DeleteCard(int cardId);
    }
}
