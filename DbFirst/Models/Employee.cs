using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Salary { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;
}
