using System;
using System.Collections.Generic;

namespace Traineeship.Domain.Models
{
    public partial class Student
    {
        public string? Name { get; set; }
        public DateTime? Enrollmentdate { get; set; }
        public string? Clubid { get; set; }
        public int Studentid { get; set; }

        public virtual Club? Club { get; set; }
    }
}
