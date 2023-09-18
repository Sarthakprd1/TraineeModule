using System;
using System.Collections.Generic;

namespace Traineeship.Domain.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Faculties = new HashSet<Faculty>();
        }

        public string? Name { get; set; }
        public int Instructorid { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
