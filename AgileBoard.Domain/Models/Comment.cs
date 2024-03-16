using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
