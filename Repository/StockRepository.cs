using System;
using Microsoft.EntityFrameworkCore;
using sampleAPI.Data;
using sampleAPI.Dto;
using sampleAPI.Helpers;
using sampleAPI.interfaces;
using sampleAPI.Models;

namespace sampleAPI.Repository;

public class StockRepository : IStockRepository
{
    public readonly ApplicationDbContext _context;
    public StockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Stock> CreateAsync(Stock stockModal)
    {
        await _context.Stock.AddAsync(stockModal);
        await _context.SaveChangesAsync();
        return stockModal;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
        if (stock == null)
        {
            return null;
        }
        _context.Stock.Remove(stock);
        await _context.SaveChangesAsync();
        return stock;
    }

    public async Task<List<Stock>> GetAllAsync(QueryObject query)
    {
        var stocks = _context.Stock.Include(c => c.Comments).AsQueryable();
        if (!string.IsNullOrEmpty(query.CompanyName))
        {
            stocks = stocks.Where(s => s.CompanyName.ToLower().Contains(query.CompanyName.ToLower()));
        }
        if (!string.IsNullOrEmpty(query.Symbol))
        {
            stocks = stocks.Where(s => s.Symbol.ToLower().Contains(query.Symbol.ToLower()));
        }
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
            {
                stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
            }
        }
        int skipNumber = (query.PageNumber - 1) * query.PageSize;
        stocks = stocks.Skip(skipNumber).Take(query.PageSize);
        return await stocks.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stock.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id);
    }

    public Task<bool> StockExist(int id)
    {
        return _context.Stock.AnyAsync(x => x.Id == id);
    }

    public async Task<Stock?> UpdateAsync(int id, StockPut stockModal)
    {
        var stock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
        if (stock == null)
        {
            return null;
        }
        stock.Symbol = stockModal.Symbol;
        stock.CompanyName = stockModal.CompanyName;
        stock.Industry = stockModal.Industry;
        stock.LastDiv = stockModal.LastDiv;
        stock.MarkedCap = stockModal.MarkedCap;
        stock.Purchase = stockModal.Purchase;

        await _context.SaveChangesAsync();
        return stock;
    }

}
