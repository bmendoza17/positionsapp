using System;
using System.Collections.Generic;

namespace Job.Domain.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
