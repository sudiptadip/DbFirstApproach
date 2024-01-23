using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Models;

[Table("Employee")]
public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Salary { get; set; }

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(50)]
    public string State { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? Mobile { get; set; }
}
