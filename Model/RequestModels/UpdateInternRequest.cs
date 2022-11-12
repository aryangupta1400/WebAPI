using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModels
{
    public class UpdateInternRequest
    {
        public int? InternId { get; set; }

        public string? InternName { get; set; }

        public string Mentor { get; set; } = null!;

        public string CurrentTrainings { get; set; }
    }
}
