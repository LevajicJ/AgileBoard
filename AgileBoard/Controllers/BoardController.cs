using AgileBoard.Application.DTOs;
using AgileBoard.Application.Interfaces;
using AgileBoard.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {

        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBoard([FromBody] BoardDTO board)
        {

            var newBoard = await _boardService.CreateBoard(board);
            
            if(newBoard == null)
            {
                return BadRequest();
            }

            return Ok(newBoard);
        }

        [HttpGet("GetBoard/{id}")]
        public async Task<ActionResult<User>> GetBoardById(int id)
        {
            var board = await _boardService.GetBoardById(id);

            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }

        [HttpGet("GetAllBoards")]
        public async Task<ActionResult<User>> GetAllBoards()
        {
            var board = await _boardService.GetAllBoards();

            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }

        [HttpPost("AddUsersToBoard")]
        public async Task<IActionResult> AddUsersToBoard([FromBody] BoardUserDTO boardUserDTO)
        {
            var result = await _boardService.AddUsersToBoard(boardUserDTO);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("DeleteUserFromBoard/{boardId}, {userId}")]
        public async Task<IActionResult> DeleteUserFromBoard(int boardId, int userId)
        {
            var result = await _boardService.DeleteUserFromBoard(boardId, userId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetBoardUsers/{boardId}")]
        public async Task<IActionResult> GetBoardUsers(int boardId)
        {
            var boardUsers = await _boardService.GetBoardUsers(boardId);
            
            if (boardUsers == null)
                return NotFound();

            return Ok(boardUsers);
        }

        [HttpGet("GetBoardsForUser/{userId}")]
        public async Task<IActionResult> GetBoardsForUser(int userId)
        {
            var boards = await _boardService.GetBoardsForUser(userId);

            if (boards == null)
                return NotFound("No boards for user");

            return Ok(boards);

        }

        [HttpGet("GetColumnId/{boardId}, {columnName}")]
        public async Task<IActionResult> GetColumnIdByName(int boardId, string columnName)
        {
            var column = await _boardService.GetColumnIdForBoardByColumnName(boardId, columnName);

            if(column == null)
                return NotFound("No column");

            return Ok(column);
        }

        [HttpDelete("DeleteBoard/{boardId}")]
        public async Task<IActionResult> DeleteBoard(int boardId)
        {
            var board = await _boardService.DeleteBoard(boardId);

            if(board == null)
                return NotFound();

            return Ok(board);
        }
    }
}
