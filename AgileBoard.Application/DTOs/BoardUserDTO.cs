using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.DTOs
{
    public class BoardUserDTO
    {
        public int BoardId { get; set; }
        public List<int> UserIds { get; set; }
    }
}
