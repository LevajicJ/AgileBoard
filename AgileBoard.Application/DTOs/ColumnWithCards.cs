using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.DTOs
{
    public class ColumnWithCards
    {
        public int ColumnId { get; set; }
        public string Column { get; set; }
        public List<Card> Cards { get; set;}
    }
}
