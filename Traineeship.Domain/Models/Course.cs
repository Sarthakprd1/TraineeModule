using System;
using System.Collections.Generic;

namespace Traineeship.Domain.Models
{
    public partial class Course
    {
        public int Courseid { get; set; }
        public string? Title { get; set; }
        public int? Credits { get; set; }
        public int? Facultyid { get; set; }

        public virtual Faculty? Faculty { get; set; }
    }
}
