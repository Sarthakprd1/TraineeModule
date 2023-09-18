using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Traineeship.Application.Contracts;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;

namespace Traineeship_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFaculty _iFaculties;

        public FacultyController(IFaculty facultyservices)
        {
            _iFaculties = facultyservices;
        }

        //GetAllFaculties
        [HttpGet]
        public ActionResult<List<FacultyResponse>> GetAllFaculties()
        {
            var getall = _iFaculties.GetFaculty();
            return Ok(getall);
        }

        //getFacultiesById
        [HttpGet("{id}")]
        public ActionResult<List<FacultyResponse>> GetById(int id)
        {
            var getbyid = _iFaculties.GetById(id);
            if (getbyid == null)
            {
                return BadRequest("no details found !");
            }
            return Ok(getbyid);
        }

        //AddNewFaculties
        [HttpPost]
        public ActionResult InsertFaculties(FacultyRequest facultyRequest)
        {
            var addinstructor = _iFaculties.AddFaculty(facultyRequest);
            return Ok(addinstructor);
        }

        //UpdateFaculty
        [HttpPut]
        public ActionResult UpdateFaculties(FacultyResponse facultyResponse)
        {
            var updateinstructor = _iFaculties.UpdateFaculty(facultyResponse);
            if (updateinstructor == true)
            {
                return Ok(facultyResponse);
            }
            return BadRequest("couldn't find the student.");
        }

        //DeleteFaculty
        [HttpDelete("{id}")]
        public ActionResult DeleteFaculties(int id)
        {
            var deletebyid = _iFaculties.DeleteFaculty(id);
            if (deletebyid != true)
            {
                return BadRequest("couldn't find the instructor.");
            }
            return Ok("successfully deleted.");
        }
    }
}
