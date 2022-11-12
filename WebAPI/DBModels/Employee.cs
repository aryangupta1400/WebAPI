using System;
using System.Collections.Generic;

namespace WebAPI.DBModels;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string? JoiningDate { get; set; }

    public string? CurrentProject { get; set; }
}
