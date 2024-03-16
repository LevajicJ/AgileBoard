using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Domain.Contracts
{
    public interface IBoardUserRepository : IRepository<BoardUser>
    {
        Task<BoardUser> DeleteUserFromBoard(BoardUser boardUser);
        Task<List<BoardUser>> GetBoardsByUserId(int userId);
    }
}
