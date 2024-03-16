using AgileBoard.Application.DTOs;
using AgileBoard.Application.Interfaces;
using AgileBoard.Domain.Models;
using Azure.Core;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardDTO card)
        {
            var newCard = await _cardService.Create(card);

            if (newCard == null)
            {
                return BadRequest();
            }

            return Ok(newCard);
        }

        [HttpGet("GetColumnsAndCards/{boardId}")]
        public async Task<IActionResult> GetColumnsAndCardsFromBoard(int boardId)
        {
            var columnsAndCards = await _cardService.GetColumnsAndCards(boardId);

            if (columnsAndCards == null)
            {
                return NotFound();
            }

            return Ok(columnsAndCards);
        }

        [HttpGet("GetCard/{cardId}")]
        public async Task<IActionResult> GetCardById(int cardId)
        {
            var card = await _cardService.GetCardById(cardId);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        [HttpPut("ChangeColumn/{cardId}, {columnId}")]
        public async Task<IActionResult> ChangeCardColumn(int cardId, int columnId)
        {
            var card = await _cardService.ChangeCardColumn(cardId, columnId);

            if (card == null)
                return BadRequest(cardId);

            return Ok(card);
        }

        [HttpPut("AssignUser/{cardId}, {userId}")]
        public async Task<IActionResult> AssignUserToCard(int cardId, int userId)
        {
            var card = await _cardService.AssignUserToCard(cardId, userId);

            if (card == null)
                return NotFound();

            return Ok(card);
        }

        [HttpDelete("DeleteCard/{cardId}")]
        public async Task<IActionResult> DeleteCard(int cardId)
        {
            var card = await _cardService.DeleteCard(cardId);
            if (card == null)
                return NotFound();

            return Ok(card);
        }


    }
}
