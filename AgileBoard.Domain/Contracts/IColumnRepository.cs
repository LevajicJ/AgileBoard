using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Domain.Contracts
{
    public interface IColumnRepository : IRepository<Column>
    {
        Task<List<Column>> GetColumnsFromBoard(int boardId);
        Task<Column> GetColumnIdFromBoardByColumnName(int boardId, string columnName);
    }
}
