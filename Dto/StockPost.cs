using System;
using System.ComponentModel.DataAnnotations;

namespace sampleAPI.Dto;

public class StockPost
{
    [Required]
    [MaxLength(10, ErrorMessage = "Symbol can not be over 10 characters")]
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
