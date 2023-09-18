using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traineeship.Application.ResponseModels
{
    public class CourseResponse
    {
        public int Courseid { get; set; }
        public string? Title { get; set; }
        public int? Credits { get; set; }
        public int? Facultyid { get; set; }
    }
}
