using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Domain.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
        public List<BoardUser> BoardUsers { get; set; }
    }
}
