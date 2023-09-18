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
    public interface IStudentService
    {
        List<StudentResponse> GetStudents();
        bool AddStudents(StudentRequest response);
        bool UpdateStudents(StudentResponse response);
        bool DeleteStudents(int id);
        Student GetById(int id);
    }
}
