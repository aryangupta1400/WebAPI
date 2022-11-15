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
        /// <summary>
        /// Intern Name
        /// </summary>
        public string? InternName { get; set; }

        /// <summary>
        /// Assigned Mentor
        /// </summary>
        public string Mentor { get; set; } = null!;

        /// <summary>
        /// Current trainings involved in
        /// </summary>
        public string CurrentTrainings { get; set; } = null!;
    }
}
