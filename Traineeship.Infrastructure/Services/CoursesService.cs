using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traineeship.Application.Contracts;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;
using Traineeship.Domain.Models;
using Traineeship.Domain.Repositories.IServices;
using Traineeship.Infrastructure.DBContext;

namespace Traineeship.Infrastructure.Services
{
    public class CoursesService : ICourseService
    {
        private readonly IGenericRepository<Course> _genericRepository;

        public CoursesService(IGenericRepository<Course> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Course GetById(int id)
        {
            var data = _genericRepository.GetById(id);
            return data;
        }

        public List<CourseResponse> GetCourses()
        {
            try
            {
                var list = _genericRepository.GetAll();
                var result = new List<CourseResponse>();
                foreach (var item in list)
                {
                    var courseResponse = new CourseResponse()
                    {
                         Courseid= item.Courseid,
                         Credits= item.Credits,
                         Facultyid= item.Facultyid,
                         Title  = item.Title,
                    };
                    result.Add(courseResponse);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddCourse(CourseRequest request)
        {
            try
            {
                var addCourse = new Course()
                {
                    Courseid = (_genericRepository.GetAll().ToList().Max(x => x.Courseid)) + 1,
                    Credits = request.Credits,
                    Facultyid= request.Facultyid,
                    Title = request.Title,

                };
                _genericRepository.Insert(addCourse);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Insertion of details failed.");
                throw;
            }
        }

        public bool DeleteCourse(int id)
        {
            var findById = _genericRepository.GetById(id);
            if (findById != null)
            {
                _genericRepository.Delete(findById);
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool UpdateCourse(CourseResponse response)
        {
            try
            {
                var existingDetails = _genericRepository.GetById(response.Courseid);
                if (existingDetails != null)
                {
                    existingDetails.Facultyid = response.Facultyid;
                    existingDetails.Title = response.Title; 
                    existingDetails.Credits = response.Credits; 

                    _genericRepository.Update(existingDetails);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
