using System;
using System.Collections.Generic;

namespace superllantasEntity.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
