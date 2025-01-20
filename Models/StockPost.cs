using System;

namespace sampleAPI.Models;

public class StockPost
{
    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public decimal Purchase { get; set; }

    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = string.Empty;
    public long MarkedCap { get; set; }
}
