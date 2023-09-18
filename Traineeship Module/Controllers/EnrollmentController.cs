using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Traineeship.Application.Contracts;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;

namespace Traineeship_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _iEnrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _iEnrollmentService = enrollmentService;
        }

        //GetAllCourses
        [HttpGet]
        public ActionResult<List<EnrollmentResponse>> GetAllEnrollment()
        {
            var getall = _iEnrollmentService.GetEnrollmentDetails();
            return Ok(getall);
        }

        //GetEnrollmentsByID
        [HttpGet("{id}")]
        public ActionResult<List<EnrollmentResponse>> GetById(int id)
        {
            var getbyid = _iEnrollmentService.GetById(id);
            if (getbyid == null)
            {
                return BadRequest("no details found !");
            }
            return Ok(getbyid);
        }

        //AddNewEnrollment
        [HttpPost]
        public ActionResult InsertEnrollment(EnrollmentRequest enrollmentRequest)
        {
            var addCourse = _iEnrollmentService.AddEnroll(enrollmentRequest);
            return Ok(addCourse);
        }

        //UpdateEnrollment
        [HttpPut]
        public ActionResult UpdateEnrollment(EnrollmentResponse enrollmentResponse)
        {
            var updateCourse = _iEnrollmentService.UpdateEnroll(enrollmentResponse);
            if (updateCourse == true)
            {
                return Ok(enrollmentResponse);
            }
            return BadRequest("couldn't find the student.");
        }

        //DeleteEnrollment
        [HttpDelete("{id}")]
        public ActionResult DeleteEnrollment(int id)
        {
            var deletebyid = _iEnrollmentService.DeleteEnroll(id);
            if (deletebyid != true)
            {
                return BadRequest("couldn't find the instructor.");
            }
            return Ok("successfully deleted.");
        }
    }
}
