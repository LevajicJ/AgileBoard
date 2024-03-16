using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.DTOs
{
    public class CardDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssignedUser { get; set; }
        public int ColumnId { get; set; }
    }
}
