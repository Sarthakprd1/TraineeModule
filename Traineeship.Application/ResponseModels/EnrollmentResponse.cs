using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traineeship.Application.ResponseModels
{
    public class EnrollmentResponse
    {
        public int Id { get; set; }
        public int? Marks { get; set; }
        public int Studentid { get; set; }
        public int Courseid { get; set; }
    }
}
