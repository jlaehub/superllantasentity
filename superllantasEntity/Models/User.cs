using System;
using System.Collections.Generic;

namespace superllantasEntity.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? UserType { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
