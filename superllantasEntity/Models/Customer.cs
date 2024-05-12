using System;
using System.Collections.Generic;

namespace superllantasEntity.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerType { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public decimal? SpecialDiscount { get; set; }

    public int? SalesAdvisorId { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual User? SalesAdvisor { get; set; }
}
