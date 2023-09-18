using System;
using System.Collections.Generic;

namespace Traineeship.Domain.Models
{
    public partial class Club
    {
        public Club()
        {
            Students = new HashSet<Student>();
        }

        public string Serial { get; set; } = null!;
        public string? Entitle { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
