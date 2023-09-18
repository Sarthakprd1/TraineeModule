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
    public interface IFaculty
    {
        List<FacultyResponse> GetFaculty();
        bool AddFaculty(FacultyRequest response);
        bool UpdateFaculty(FacultyResponse response);
        bool DeleteFaculty(int id);
        Faculty GetById(int id);
    }
}
