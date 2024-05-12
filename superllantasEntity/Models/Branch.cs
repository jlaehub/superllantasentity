using System;
using System.Collections.Generic;

namespace superllantasEntity.Models;

public partial class Branch
{
    public int BranchId { get; set; }

    public int? CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
