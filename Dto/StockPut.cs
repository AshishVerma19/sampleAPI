using System;
using System.ComponentModel.DataAnnotations;

namespace sampleAPI.Dto;

public class StockPut
{
    [Required]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [Range(1, 10000000)]
    public decimal Purchase { get; set; }
    [Required]
    public decimal LastDiv { get; set; }
    [Required]
    public string Industry { get; set; } = string.Empty;
    [Required]
    public long MarkedCap { get; set; }
}
