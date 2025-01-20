using System;
using sampleAPI.Models;

namespace sampleAPI.interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();
}
