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
    public interface IEnrollmentService
    {
        List<EnrollmentResponse> GetEnrollmentDetails();
        bool AddEnroll(EnrollmentRequest request);
        bool UpdateEnroll(EnrollmentResponse response);
        bool DeleteEnroll(int id);
        Enrollment GetById(int id);
    }
}
