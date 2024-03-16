using AgileBoard.Application.DTOs;
using AgileBoard.Domain.Models;
using AgileBoard.UI.Models;

namespace AgileBoard.UI.Services
{
    public interface IBoardService
    {
        Task<List<BoardUser>> GetBoardsForUser(int userId);
        Task CreateBoard(CreateBoardDto createBoardDto);
        Task<List<ColumnWithCards>> GetColumnsAndCards(int boardId);
        Task ChangeCardCollumn(int cardId, int columnId);
        Task AddComment(CommentDTO commentDto);
        Task<Card> GetCardById(int cardId);
        Task<Board> GetBoardById(int boardId);
        Task AddUserToBoard(BoardUserDTO boardUserDto);
        Task CreateCard(CardDTO cardDto);
        Task<int> GetColumnIdForBoardByColumnName(int boardId, string columnName);
        Task DeleteCard(int cardId);
        Task DeleteBoard(int boardId);
        Task DeleteUserFromBoard(int boardId, int userId);
        Task <List<Board>> GetAllBoards();
    }
}
