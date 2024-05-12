using System;
using System.Collections.Generic;

namespace superllantasEntity.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? BranchId { get; set; }

    public decimal? WithholdingTax { get; set; }

    public decimal? SalesTax { get; set; }

    public virtual Branch? Branch { get; set; }


}
