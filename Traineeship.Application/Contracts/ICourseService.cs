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
    public interface ICourseService
    { 
        List<CourseResponse> GetCourses();
        bool AddCourse(CourseRequest request);
        bool UpdateCourse(CourseResponse response);
        bool DeleteCourse(int id);
        Course GetById(int id);
    }
}
