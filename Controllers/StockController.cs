using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using sampleAPI.Dto;
using sampleAPI.Data;
using sampleAPI.Models;
using sampleAPI.Mapper;
using Microsoft.EntityFrameworkCore;
using sampleAPI.interfaces;

namespace sampleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IStockRepository _stockService;
    public StockController(ApplicationDbContext context, IStockRepository stockRepository)
    {
        _context = context;
        _stockService = stockRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stock = await _stockService.GetAllAsync();
        var stockDto = stock.Select(s => s.ToStockDto());

        return Ok(stockDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _context.Stock.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock?.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> PostStock([FromBody] StockPost stock)
    {
        try
        {
            if (stock == null)
            {
                return BadRequest("incorrect data");
            }

            var newStock = stock.ToStockPost();
            await _context.Stock.AddAsync(newStock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = newStock.Id }, newStock.ToStockDto());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStock([FromRoute] int id, [FromBody] StockPut stockPost)
    {
        try
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
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

            await _context.SaveChangesAsync();
            return Ok(stock.ToStockDto());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock([FromRoute] int id)
    {
        var stock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
        if (stock == null)
        {
            return NotFound();
        }
        _context.Stock.Remove(stock);

        await _context.SaveChangesAsync();

        return NoContent();
    }

}

