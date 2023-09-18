using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traineeship.Domain.Models;

namespace Traineeship.Application.ResponseModels
{
    public class StudentResponse
    {
        public int Studentid { get; set; }
        public string? Name { get; set; }
        public string? Clubid { get; set; }
        public string? ClubName { get; set; }

    }
}
