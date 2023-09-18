using Microsoft.VisualBasic;
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
    public class InstructorService : IInstructorService
    {
        private readonly IGenericRepository<Instructor> _genericRepository;
        public InstructorService(IGenericRepository<Instructor> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        //GetByID
        public Instructor GetById(int id)
        {
            var data = _genericRepository.GetById(id);
            return data;
        }

        //GetAllList
        public List<InstructorResponse> GetInstructor()
        {
            try
            {
                var list = _genericRepository.GetAll();
                var result = new List<InstructorResponse>();
                foreach (var item in list)
                {
                    var instructorResponse = new InstructorResponse()
                    {
                        InstructorId = item.Instructorid,
                        Name = item.Name,
                    };
                    result.Add(instructorResponse);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Instructor
        public bool AddInstructor(InstructorRequest response)
        {
            try
            {
                var addInstructor = new Instructor()
                {
                    Instructorid = response.InstructorId,
                    Name = response.Name,
                };
                _genericRepository.Insert(addInstructor);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Insertion of details failed.");
                throw;
            }
        }

        //Delete Instructor
        public bool DeleteInstructor(int id)
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


        //Update Instructor
        public bool UpdateInstructor(InstructorResponse response)
        {
            try
            {
                var existingDetails = _genericRepository.GetById(response.InstructorId);
                if (existingDetails != null)
                {
                    existingDetails.Name = response.Name;


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
