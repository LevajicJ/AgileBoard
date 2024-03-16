using AgileBoard.Application.DTOs;
using AgileBoard.Domain.Models;
using AgileBoard.UI.Models;
using System.Net.Http.Json;

namespace AgileBoard.UI.Services
{
    public class BoardService : IBoardService
    {
        private readonly HttpClient _httpClient;
        public BoardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BoardUser>> GetBoardsForUser(int userId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<BoardUser>>($"api/Board/GetBoardsForUser/{userId}");
            return result;
        }

        public async Task CreateBoard(CreateBoardDto createBoardDto)
        {
            await _httpClient.PostAsJsonAsync("api/Board", createBoardDto);
            
        }

        public async Task<List<ColumnWithCards>> GetColumnsAndCards(int boardId)
        {
            return await _httpClient.GetFromJsonAsync<List<ColumnWithCards>>($"api/Card/GetColumnsAndCards/{boardId}");
        }

        public async Task ChangeCardCollumn(int cardId, int columnId)
        {
            await _httpClient.PutAsync($"api/Card/ChangeColumn/{cardId}, {columnId}", null);
        }

        public async Task AddComment(CommentDTO commentDto)
        {
            await _httpClient.PostAsJsonAsync("api/Comment/AddComment", commentDto);
        }

        public async Task<Card> GetCardById(int cardId)
        {
            return await _httpClient.GetFromJsonAsync<Card>($"api/Card/GetCard/{cardId}");
        }

        public async Task<Board> GetBoardById(int boardId)
        {
            return await _httpClient.GetFromJsonAsync<Board>($"api/Board/GetBoard/{boardId}");
        }

        public async Task AddUserToBoard(BoardUserDTO boardUserDto)
        {
            await _httpClient.PostAsJsonAsync("/api/Board/AddUsersToBoard", boardUserDto);
        }

        public async Task CreateCard(CardDTO cardDto)
        {
            await _httpClient.PostAsJsonAsync("api/Card", cardDto);
        }

        public async Task<int> GetColumnIdForBoardByColumnName(int boardId, string columnName)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/Board/GetColumnId/{boardId}, {columnName}");
        }

        public async Task DeleteCard(int cardId)
        {
            await _httpClient.DeleteAsync($"api/Card/DeleteCard/{cardId}");
        }

        public async Task DeleteBoard(int boardId)
        {
            await _httpClient.DeleteAsync($"api/Board/DeleteBoard/{boardId}");
        }

        public async Task DeleteUserFromBoard(int boardId, int userId)
        {
            await _httpClient.DeleteAsync($"api/Board/DeleteUserFromBoard/{boardId}, {userId}");
        }

        public async Task<List<Board>> GetAllBoards()
        {
            return await _httpClient.GetFromJsonAsync<List<Board>>("api/Board/GetAllBoards");
        }
    }
}
