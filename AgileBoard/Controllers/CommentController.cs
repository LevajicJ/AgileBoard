using AgileBoard.Application.DTOs;
using AgileBoard.Application.Interfaces;
using AgileBoard.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentDTO commentDto)
        {
            var comment = await _commentService.AddComment(commentDto);

            if(comment == null)
            {
                return BadRequest();
            }

            return Ok(comment);
        }
    }
}
