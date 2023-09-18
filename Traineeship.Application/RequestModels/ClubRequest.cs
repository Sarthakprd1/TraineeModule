using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traineeship.Application.RequestModels
{
    public class ClubRequest
    {
        public string Serial { get; set; } = null!;
        public string? Entitle { get; set; }
    }
}
