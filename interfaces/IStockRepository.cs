using System;
using sampleAPI.Dto;
using sampleAPI.Helpers;
using sampleAPI.Models;

namespace sampleAPI.interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync(QueryObject query);
    Task<Stock?> GetByIdAsync(int id); // FirstOrDefault can be null
    Task<Stock> CreateAsync(Stock stockModal);
    Task<Stock?> UpdateAsync(int id, StockPut stockModal);
    Task<Stock?> DeleteAsync(int id);
    Task<bool> StockExist(int id);
}
