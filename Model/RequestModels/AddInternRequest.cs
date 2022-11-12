using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Request
{
    /// <summary>
    /// Schema for adding new student
    /// </summary>
    public class AddInternRequest
    {
        public int? InternId { get; set; }

        public string? InternName { get; set; }

        public string Mentor { get; set; } = null!;

        public string CurrentTrainings { get; set; } = null!;
    }
}
