using System;
using System.Collections.Generic;

namespace Traineeship.Domain.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Courses = new HashSet<Course>();
        }

        public string? Name { get; set; }
        public int? Supervisorid { get; set; }
        public int Facultiesid { get; set; }

        public virtual Instructor? Supervisor { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
