using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;
using Traineeship.Domain.Models;

namespace Traineeship.Application.Contracts
{
    public interface IInstructorService
    {
        List<InstructorResponse> GetInstructor();
        bool AddInstructor(InstructorRequest response);
        bool UpdateInstructor(InstructorResponse response);
        bool DeleteInstructor(int id);
        Instructor GetById(int id);
    }
}
