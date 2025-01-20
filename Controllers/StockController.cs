using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using sampleAPI.Dto;
using sampleAPI.Data;
using sampleAPI.Models;
using sampleAPI.Mapper;

namespace sampleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public StockController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var stock = _context.Stock.ToList().Select(s => s.ToStockDto());
        return Ok(stock);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var stock = _context.Stock.Find(id)?.ToStockDto();
        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock);
    }

    [HttpPost]
    public IActionResult PostStock([FromBody] StockPost stock)
    {
        try
        {
            if (stock == null)
            {
                return BadRequest("incorrect data");
            }

            var newStock = stock.ToStockPost();
            _context.Stock.Add(newStock);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = newStock.Id }, newStock.ToStockDto());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{id}")]
    public IActionResult PutStock([FromRoute] int id, [FromBody] StockPut stockPost)
    {
        try
        {
            var stock = _context.Stock.FirstOrDefault(x => x.Id == id);
            if (stock == null)
            {
                return NotFound("stock id not found");
            }
            stock.Symbol = stockPost.Symbol;
            stock.CompanyName = stockPost.CompanyName;
            stock.Industry = stockPost.Industry;
            stock.LastDiv = stockPost.LastDiv;
            stock.MarkedCap = stockPost.MarkedCap;
            stock.Purchase = stockPost.Purchase;

            _context.SaveChanges();
            return Ok(stock.ToStockDto());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStock([FromRoute] int id)
    {
        var stock = _context.Stock.FirstOrDefault(x => x.Id == id);
        if (stock == null)
        {
            return NotFound();
        }
        _context.Stock.Remove(stock);

        _context.SaveChanges();

        return NoContent();
    }

}

