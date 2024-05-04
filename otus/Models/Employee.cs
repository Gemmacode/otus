using System;
using System.Collections.Generic;

namespace otus.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? Department { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<ProjectDetail> ProjectDetails { get; set; } = new List<ProjectDetail>();
}
