using AgileBoard.Application.DTOs;
using AgileBoard.Application.Interfaces;
using AgileBoard.Domain.Contracts;
using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDTO> AddComment(CommentDTO commentDto)
        {
            var comment = new Comment
            {
                CommentText = commentDto.CommentText,
                CardId = commentDto.CardId,
                UserId = commentDto.UserId,
            };

            await _commentRepository.Add(comment);
            
            return commentDto;
        }
    }
}
