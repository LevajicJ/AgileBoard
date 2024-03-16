using AgileBoard.Application.DTOs;
using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDTO> AddComment(CommentDTO comment);
    }
}
