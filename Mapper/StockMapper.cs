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
            Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList(),
        };
        return stockDto;
    }

    public static Stock ToStockPost(this StockPost stockPost)
    {
        var stock = new Stock()
        {
            CompanyName = stockPost.CompanyName,
            Industry = stockPost.Industry,
            LastDiv = stockPost.LastDiv,
            Symbol = stockPost.Symbol,
            Purchase = stockPost.Purchase,
            MarkedCap = stockPost.MarkedCap,
        };

        return stock;
    }
}
