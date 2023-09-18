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
    public class FacultyService : IFaculty
    {
        private readonly IGenericRepository<Faculty> _genericRepository;

        public FacultyService(IGenericRepository<Faculty> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Faculty GetById(int id)
        {
            var data = _genericRepository.GetById(id);
            return data;
        }

        public List<FacultyResponse> GetFaculty()
        {
            try
            {
                var list = _genericRepository.GetAll();
                var result = new List<FacultyResponse>();
                foreach (var item in list)
                {
                    var facultyResponse = new FacultyResponse()
                    {
                        Facultiesid= item.Facultiesid,
                        Name= item.Name,    
                        Supervisorid= item.Supervisorid,
                    };
                    result.Add(facultyResponse);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddFaculty(FacultyRequest response)
        {
            try
            {
                var addFaculty = new Faculty()
                {
                    Name= response.Name,
                    Supervisorid= response.Supervisorid,
                    
                };
                _genericRepository.Insert(addFaculty);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Insertion of details failed.");
                throw;
            }
        }

        public bool DeleteFaculty(int id)
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

        public bool UpdateFaculty(FacultyResponse response)
        {
            try
            {
                var existingDetails = _genericRepository.GetById(response.Facultiesid);
                if (existingDetails != null)
                {
                   existingDetails.Supervisorid = response.Supervisorid;
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
