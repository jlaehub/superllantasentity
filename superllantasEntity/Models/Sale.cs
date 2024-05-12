using System;
using System.Collections.Generic;

namespace superllantasEntity.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int? CustomerId { get; set; }

    public int? BranchId { get; set; }

    public string? SaleType { get; set; }

    public decimal? TemporaryDiscount { get; set; }

    public DateTime? SaleDate { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }
}
