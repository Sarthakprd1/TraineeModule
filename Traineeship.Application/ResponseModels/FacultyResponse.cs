using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traineeship.Application.ResponseModels
{
    public class FacultyResponse
    {
        public string? Name { get; set; }
        public int? Supervisorid { get; set; }
        public int Facultiesid { get; set; }
    }
}
