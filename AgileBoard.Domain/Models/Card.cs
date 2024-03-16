using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Domain.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssignedUser { get; set; }
        public int ColumnId { get; set; }
        public Column Column { get; set; }
        public List<Comment> Comments { get; set; }
        

    }
}
