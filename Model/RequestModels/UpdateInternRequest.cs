using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModels
{
    /// <summary>
    /// Request to update intern details
    /// </summary>
    public class UpdateInternRequest
    {      
        
        /// <summary>
        /// Mentor assigned
        /// </summary>
        public string Mentor { get; set; } = null!;

        /// <summary>
        /// Current Traings involved in
        /// </summary>
        public string? CurrentTrainings { get; set; }
    }
}
