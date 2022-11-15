using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ResponseModels
{
    /// <summary>
    /// Intern Data Trasnfer Object
    /// </summary>
    public class InternDTO
    {
        /// <summary>
        /// intern ID
        /// </summary>
        public int? InternId { get; set; }

        /// <summary>
        /// Mentor Name
        /// </summary>
        public string Mentor { get; set; } = null!;

        /// <summary>
        /// Current Traings involved in
        /// </summary>
        public string? CurrentTrainings { get; set; } = null!;
    }
}
