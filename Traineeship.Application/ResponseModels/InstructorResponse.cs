using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Traineeship.Domain.Models;

namespace Traineeship.Application.ResponseModels
{
    public class InstructorResponse
    {
        public int InstructorId { get; set; }
        public string? Name { get; set; }
        //public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
    }
}
