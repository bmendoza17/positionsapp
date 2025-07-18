using System;
using System.Collections.Generic;

namespace Job.Domain.Models;

public partial class Recruiter
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
