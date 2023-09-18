using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Traineeship.Application.Contracts;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;
using Traineeship.Domain.Models;
using Traineeship.Domain.Repositories.IServices;

namespace Traineeship.Infrastructure.Services
{
    public class ClubService : IClubService
    {
        private readonly IGenericRepository<Club> _genericRepository;

        public ClubService(IGenericRepository<Club> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Club GetBySerial(string serial)
        {
            var data = _genericRepository.GetBySerial(serial);
            return data;
        }

        public List<ClubResponse> GetAllClubs()
        {
            try
            {
                var list = _genericRepository.GetAll();
                var result = new List<ClubResponse>();
                foreach (var item in list)
                {
                    var clubResponse = new ClubResponse()
                    {
                        Serial= item.Serial,
                        Entitle = item.Entitle,
                        
                    };
                    result.Add(clubResponse);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddClub(ClubRequest request)
        {
            try
            {
                var addClub = new Club()
                {
                    Serial = request.Serial,
                    Entitle= request.Entitle,

                };
                _genericRepository.Insert(addClub);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Insertion of details failed.");
                throw;
            }
        }

        public bool DeleteClub(string serial)
        {
            var findById = _genericRepository.GetBySerial(serial);
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

        public bool UpdateClub(ClubResponse response)
        {
            try
            {
                var existingDetails = _genericRepository.GetBySerial(response.Serial);
                if (existingDetails != null)
                {
                    existingDetails.Serial = response.Serial;
                    existingDetails.Entitle = response.Entitle; 

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
