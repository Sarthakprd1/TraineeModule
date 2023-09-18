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
    public interface IClubService
    {
        List<ClubResponse> GetAllClubs();
        bool AddClub(ClubRequest request);
        bool UpdateClub(ClubResponse response);
        bool DeleteClub(string serial);
        Club GetBySerial(string serial);
    }
}
