using System;
using System.Collections.Generic;

namespace Model.DBModels;

public partial class Intern
{
    public int InternId { get; set; }

    public string InternName { get; set; } = null!;

    public string Mentor { get; set; } = null!;

    public string? CurrentTrainings { get; set; }
}
