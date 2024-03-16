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
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly IColumnRepository _columnRepository;
        private readonly IUserRepository _userRepository;

        public CardService(ICardRepository cardRepository, IBoardRepository boardRepository, IColumnRepository columnRepository, IUserRepository userRepository)
        {
            _cardRepository = cardRepository;
            _boardRepository = boardRepository;
            _columnRepository = columnRepository;
            _userRepository = userRepository;
        }
        public async Task<CardDTO> Create(CardDTO cardDto)
        {
            var card = new Card
            {
                Name = cardDto.Name,
                Description = cardDto.Description,
                AssignedUser = cardDto.AssignedUser,
                ColumnId = cardDto.ColumnId,
            };


            var newCard = await _cardRepository.Add(card);

            if(newCard == null) 
            {
                throw new Exception("Error creating card");
            }

            return cardDto;
        }

        public async Task<List<ColumnWithCards>> GetColumnsAndCards(int boardId)
        {
            var board = await _boardRepository.GetById(boardId);

            if(board == null)
            {
                throw new Exception("Board does not exists");
            }

            var columns = await _columnRepository.GetColumnsFromBoard(boardId);

            var result = new List<ColumnWithCards>();

            foreach(var column in columns)
            {
                var cardsInColumns = await _cardRepository.GetCardsFromColumn(column.Id);

                var columnWithCards = new ColumnWithCards
                {
                    ColumnId = column.Id,
                    Column = column.Name,
                    Cards = cardsInColumns,
                };

                result.Add(columnWithCards);

            }

            return result;
        }

        public async Task<Card> GetCardById(int cardId)
        {
            var card = await _cardRepository.GetById(cardId);

            return card;
        }

        public async Task<Card> ChangeCardColumn(int cardId, int newColumnId)
        {
            var card = await _cardRepository.GetById(cardId);
            if (card == null)
            {
                throw new Exception("Card doesn't exists");
            }
            card.ColumnId = newColumnId;
            Card cardToUpdate = new Card
            {
                Id = cardId,
                Name = card.Name,
                Description = card.Description,
                AssignedUser = card.AssignedUser,
                ColumnId = newColumnId,
            };
            var updatedCard = await _cardRepository.Update(cardToUpdate);

            return updatedCard;
        }

        public async Task<Card> AssignUserToCard(int cardId, int userId)
        {
            var card = await _cardRepository.GetById(cardId);
            if (card == null)
            {
                throw new Exception("Card doesn't exists");
            }

            var user = await _userRepository.GetById(userId);
            if (user == null)
            {
                throw new Exception("User doesn't exists");
            }

            card.AssignedUser += $", {user.UserName}";

            var updatedCard = await _cardRepository.Update(card);

            return updatedCard;
        }

        public async Task<bool> DeleteCard(int cardId)
        {
            var card = await _cardRepository.GetById(cardId);

            if (card == null)
                throw new Exception("No card");

            else
            {
                await _cardRepository.Delete(card);
                return true;
            }
        }
    }
}
