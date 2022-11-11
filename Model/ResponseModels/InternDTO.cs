using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ResponseModels
{
    public class InternDTO
    {
        public int? InternId { get; set; }

        public string Mentor { get; set; } = null!;

    }
}
