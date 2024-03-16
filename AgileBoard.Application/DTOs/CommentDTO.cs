using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.DTOs
{
    public class CommentDTO
    {
        public string CommentText { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
    }
}
