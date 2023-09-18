using Microsoft.VisualBasic;
using NpgsqlTypes;
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
using Traineeship.Domain.Models;

namespace Traineeship.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _genericRepository;
        public StudentService(IGenericRepository<Student> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public bool AddStudents(StudentRequest response)
        {
            try
            {
                var addStudent = new Student()
                {
                    Name = response.Name,
                    Enrollmentdate = DateAndTime.Now,
                    Clubid = response.Clubid,
                };
                _genericRepository.Insert(addStudent);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                throw;
            }
        }

        //Delete Student
        public bool DeleteStudents(int id)
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

        //GetByID
        public Student GetById(int id)
        {
            var data = _genericRepository.GetById(id);
            return data;
        }

        //GetAllList
        public List<StudentResponse> GetStudents()
        {
            try
            {
                var list = _genericRepository.GetAll();
                var result = new List<StudentResponse>();
                foreach (var item in list)
                {
                    var studentCandidateResponse = new StudentResponse()
                    {
                        Studentid = item.Studentid,
                        Name = item.Name,
                        Clubid = item.Clubid,
                    };
                    result.Add(studentCandidateResponse);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateStudents(StudentResponse response)
        {
            try
            {
                var existingDetails = _genericRepository.GetById(response.Studentid);
                if (existingDetails != null)
                {
                    existingDetails.Name = response.Name;
                    existingDetails.Clubid = response.Clubid;

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
