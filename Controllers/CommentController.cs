using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sampleAPI.interfaces;
using sampleAPI.Mapper;
using sampleAPI.Dto;

namespace sampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(x => x.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> PostComment([FromRoute] int stockId, [FromBody] CommentPost comment)
        {
            var stock = await _stockRepository.StockExist(stockId);
            if (!stock)
            {
                return BadRequest("Stock id is not valid");
            }
            var commentVale = comment.ToCommentFromPost(stockId);
            var commentRes = await _commentRepository.CreateCommentAsync(commentVale);
            return CreatedAtAction(nameof(GetById), new { id = commentRes.Id }, commentRes);
        }
    }
}
