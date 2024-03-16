using AgileBoard.Application.DTOs;
using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.Interfaces
{
    public interface IBoardService
    {
        Task<BoardDTO> CreateBoard(BoardDTO board);
        Task<Board> GetBoardById(int id);
        Task<IEnumerable<Board>> GetAllBoards();
        Task<Board> AddUsersToBoard(BoardUserDTO boardUserDTO);
        Task<Board> DeleteUserFromBoard(int boardId, int userId);
        Task<List<BoardUser>> GetBoardUsers(int boardId);
        Task<List<BoardUser>> GetBoardsForUser(int userId);
        Task<int> GetColumnIdForBoardByColumnName(int boardId, string columnName);
        Task<bool> DeleteBoard(int boardId);
    }
}
