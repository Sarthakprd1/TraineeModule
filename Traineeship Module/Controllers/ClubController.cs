using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Traineeship.Application.Contracts;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;

namespace Traineeship_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _iClubService;

        public ClubController(IClubService clubService)
        {
            _iClubService = clubService;
        }

        //GetAllClubs
        [HttpGet]
        public ActionResult<List<ClubResponse>> GetAllClub()
        {
            var getall = _iClubService.GetAllClubs();
            return Ok(getall);
        }

        //getClubsById
        [HttpGet("{string}")]
        public ActionResult<List<ClubResponse>> GetBySerial(string serial)
        {
            var getbyid = _iClubService.GetBySerial(serial);
            if (getbyid == null)
            {
                return BadRequest("no details found !");
            }
            return Ok(getbyid);
        }

        //AddNewClub
        [HttpPost]
        public ActionResult InsertClubs(ClubRequest clubRequest)
        {
            var addCourse = _iClubService.AddClub(clubRequest);
            return Ok(addCourse);
        }

        //UpdateClubs
        [HttpPut]
        public ActionResult UpdateClubs(ClubResponse clubResponse)
        {
            var updateCourse = _iClubService.UpdateClub(clubResponse);
            if (updateCourse == true)
            {
                return Ok(clubResponse);
            }
            return BadRequest("couldn't find the student.");
        }

        //DeleteClubs
        [HttpDelete("{id}")]
        public ActionResult DeleteClubs(string serial)
        {
            var deletebyid = _iClubService.DeleteClub(serial);
            if (deletebyid != true)
            {
                return BadRequest("couldn't find the instructor.");
            }
            return Ok("successfully deleted.");
        }
    }
}
