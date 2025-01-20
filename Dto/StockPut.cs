using System;
using System.ComponentModel.DataAnnotations;

namespace sampleAPI.Dto;

public class StockPut
{
    [Required]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    public string CompanyName { get; set; } = string.Empty;

    public decimal Purchase { get; set; }

    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = string.Empty;
    public long MarkedCap { get; set; }
}
