using System;
using System.Collections.Generic;

namespace otus.Models;

public partial class ProjectDetail
{
    public int ProjectId { get; set; }

    public int? EmployeeId { get; set; }

    public string? ProjectName { get; set; }

    public virtual Employee? Employee { get; set; }
}
