using System;
using sampleAPI.Dto;
using sampleAPI.Models;

namespace sampleAPI.Mapper;

public static class StockMapper
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        var stockDto = new StockDto()
        {
            Id = stockModel.Id,
            CompanyName = stockModel.CompanyName,
            Industry = stockModel.Industry,
            LastDiv = stockModel.LastDiv,
            MarkedCap = stockModel.MarkedCap,
            Purchase = stockModel.Purchase,
            Symbol = stockModel.Symbol,
        };
        return stockDto;
    }
}
