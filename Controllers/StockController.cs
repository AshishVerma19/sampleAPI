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
            var stockDetails = new Stock()
            {
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                LastDiv = stock.LastDiv,
                Symbol = stock.Symbol,
                Purchase = stock.Purchase,
                MarkedCap = stock.MarkedCap,
            };

            var newStock = _context.Stock.Add(stockDetails);
            _context.SaveChanges();
            return Ok("stock created");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
}
