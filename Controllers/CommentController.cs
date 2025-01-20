using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sampleAPI.interfaces;
using sampleAPI.Mapper;

namespace sampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(x => x.ToCommentDto());
            return Ok(commentDto);
        }
    }
}
