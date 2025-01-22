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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> PostComment([FromRoute] int stockId, [FromBody] CommentPost comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockRepository.StockExist(stockId);
            if (!stock)
            {
                return BadRequest("Stock id is not valid");
            }
            var commentVale = comment.ToCommentFromPost(stockId);
            var commentRes = await _commentRepository.CreateCommentAsync(commentVale);
            return CreatedAtAction(nameof(GetById), new { id = commentRes.Id }, commentRes);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutComment([FromRoute] int id, [FromBody] CommentPost commentModal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepository.UpdateCommentAsync(id, commentModal);
            if (comment == null)
            {
                return BadRequest("comment id not found");
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentRepository.DeleteAsync(id);
            if (comment == null)
            {
                BadRequest($"Comment with not {id} found");
            }
            return NoContent();
        }
    }
}
