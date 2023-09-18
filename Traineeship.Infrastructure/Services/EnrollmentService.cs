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

namespace Traineeship.Infrastructure.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IGenericRepository<Enrollment> _genericRepository;

        public EnrollmentService(IGenericRepository<Enrollment> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Enrollment GetById(int id)
        {
            var data = _genericRepository.GetById(id);
            return data;
        }

        public List<EnrollmentResponse> GetEnrollmentDetails()
        {
            try
            {
                var list = _genericRepository.GetAll();
                var result = new List<EnrollmentResponse>();
                foreach (var item in list)
                {
                    var courseResponse = new EnrollmentResponse()
                    {
                        Courseid = item.Courseid,
                        Id = item.Id,
                        Marks = item.Marks,
                        Studentid = item.Studentid
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

        public bool AddEnroll(EnrollmentRequest request)
        {
            try
            {
                var addCourse = new Enrollment()
                {
                    Id = (_genericRepository.GetAll().ToList().Max(x => x.Id)) + 1,
                    Courseid = request.Courseid,
                    Studentid= request.Studentid,
                    Marks = request.Marks,

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

        public bool DeleteEnroll(int id)
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

        public bool UpdateEnroll(EnrollmentResponse response)
        {
            try
            {
                var existingDetails = _genericRepository.GetById(response.Id);
                if (existingDetails != null)
                {
                    existingDetails.Studentid = response.Studentid;
                    existingDetails.Courseid = response.Courseid;
                    existingDetails.Marks = response.Marks;

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
