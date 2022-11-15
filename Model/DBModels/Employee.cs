using System;
using System.Collections.Generic;

namespace Model.DBModels;

/// <summary>
/// Employee schema
/// </summary>
public partial class Employee
{
    /// <summary>
    /// Employee ID
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Employee Name
    /// </summary>
    public string EmployeeName { get; set; } = null!;

    /// <summary>
    /// Date of Joining
    /// </summary>
    public string? JoiningDate { get; set; }

    /// <summary>
    /// Current Project involved in
    /// </summary>
    public string? CurrentProject { get; set; }
}
