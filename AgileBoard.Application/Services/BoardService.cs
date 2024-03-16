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
    public class BoardService : IBoardService
    {

        private readonly IBoardRepository _boardRepository;
        private readonly IBoardUserRepository _boardUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly IColumnRepository _columnRepository;

        public BoardService(IBoardRepository boardRepository, IBoardUserRepository boardUserRepository, IUserRepository userRepository, IColumnRepository columnRepository)
        {
            _boardRepository = boardRepository;
            _boardUserRepository = boardUserRepository;
            _userRepository = userRepository;
            _columnRepository = columnRepository;
        }



        public async Task<BoardDTO> CreateBoard(BoardDTO board)
        {
            var newBoard = new Board
            {
                Name = board.BoardName
            };
            var boardCreated = await _boardRepository.Add(newBoard);
            
            if (boardCreated == null)
            {
                throw new Exception("Board can't be created");
            }

            
            foreach(Columns columnName in Enum.GetValues(typeof(Columns)))
            {
                var column = new Column 
                { 
                    Name = columnName.ToString(), 
                    BoardId = boardCreated.Id
                };
                await _columnRepository.Add(column);
            }

            var inserBoardUser = new BoardUser
            {
                BoardId = newBoard.Id,
                UserId = board.BoardOwner
            };

            var boardUserAdded = await _boardUserRepository.Add(inserBoardUser);

            if (boardUserAdded == null) 
            {
                throw new Exception("Failed to associate the user with the board");
            }

            return board;
        }

        public async Task<IEnumerable<Board>> GetAllBoards()
        {
            var boards = await _boardRepository.GetAllAsync();

            return boards;
        }

        public async Task<Board> GetBoardById(int id)
        {
            var board = await _boardRepository.GetById(id);
            
            return board;
        }

        public async Task<Board> AddUsersToBoard(BoardUserDTO boardUserDTO)
        {
            var board = await _boardRepository.GetById(boardUserDTO.BoardId);

            if(board == null)
            {
                throw new Exception("Board does not exist");
            }

            foreach (var userId in boardUserDTO.UserIds)
            {
                var user = await _userRepository.GetById(userId);

                if (user == null)
                {
                    throw new Exception("User does't exist");
                }
                else
                {
                    var boardUser = new BoardUser
                    {
                        BoardId = board.Id,
                        UserId = userId,
                    };

                    await _boardUserRepository.Add(boardUser);
                }
            }

            return board;
        }

        public async Task<Board> DeleteUserFromBoard(int boardId, int userId)
        {
            var board = await _boardRepository.GetById(boardId);

            if (board == null)
            {
                throw new Exception("Board does not exist");
            }

            var user = await _userRepository.GetById(userId);

            if(user == null)
            {
                throw new Exception("User doesn't exist");
            }
            var boardUser = new BoardUser
            {
                BoardId = boardId,
                UserId = userId,
            };

            await _boardUserRepository.DeleteUserFromBoard(boardUser);

            return board;
        }

        public async Task<List<BoardUser>> GetBoardUsers(int boardId)
        {
            var board = await GetBoardById(boardId);

            if (board == null)
                throw new Exception("Board doesn't exists");

            var boardUsers = board.BoardUsers.ToList();

            return boardUsers;
        }

        public async Task<List<BoardUser>> GetBoardsForUser(int userId)
        {
            var boards = await _boardUserRepository.GetBoardsByUserId(userId);

            if (boards == null)
                throw new Exception("No boards for user");

            return boards;
        }

        public async Task<int> GetColumnIdForBoardByColumnName(int boardId, string columnName)
        {
            var column = await _columnRepository.GetColumnIdFromBoardByColumnName(boardId, columnName);

            if (column == null)
                throw new Exception("No column on the board");

            return column.Id;
        }

        public async Task<bool> DeleteBoard(int boardId)
        {
            var board = await _boardRepository.GetById(boardId);

            if (board == null)
                return false;
            else
            {
                await _boardRepository.Delete(board);
                return true;
            }
        }
    }
}
