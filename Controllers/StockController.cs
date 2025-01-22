using Microsoft.AspNetCore.Mvc;
using sampleAPI.Dto;
using sampleAPI.Mapper;
using sampleAPI.interfaces;
using sampleAPI.Helpers;

namespace sampleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly IStockRepository _stockService;
    public StockController(IStockRepository stockRepository)
    {
        _stockService = stockRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stock = await _stockService.GetAllAsync(query);
        var stockDto = stock.Select(s => s.ToStockDto());

        return Ok(stockDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var stock = await _stockService.GetByIdAsync(id);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (stock == null)
            {
                return BadRequest("incorrect data");
            }

            var newStock = stock.ToStockPost();
            await _stockService.CreateAsync(newStock);
            return CreatedAtAction(nameof(GetById), new { id = newStock.Id }, newStock.ToStockDto());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutStock([FromRoute] int id, [FromBody] StockPut stockPost)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockService.UpdateAsync(id, stockPost);
            if (stock == null)
            {
                return NotFound("stock not found");
            }
            return Ok(stock.ToStockDto());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStock([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _stockService.DeleteAsync(id);

        return NoContent();
    }

}

