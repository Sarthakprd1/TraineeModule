using System;
using System.Collections.Generic;

namespace Traineeship.Domain.Models
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public int? Marks { get; set; }
        public int Studentid { get; set; }
        public int Courseid { get; set; }
    }
}
