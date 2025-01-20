using System;
using Microsoft.EntityFrameworkCore;
using sampleAPI.Data;
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
    public Task<List<Stock>> GetAllAsync()
    {
        return _context.Stock.ToListAsync();
    }
}
