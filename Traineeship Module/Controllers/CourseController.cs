using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Traineeship.Application.Contracts;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;

namespace Traineeship_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _iCourseService;

        public CourseController(ICourseService courseService)
        {
            _iCourseService = courseService; 
        }

        //GetAllCourses
        [HttpGet]
        public ActionResult<List<CourseResponse>> GetAllCourses()
        {
            var getall = _iCourseService.GetCourses();
            return Ok(getall);
        }

        //GetCourseById
        [HttpGet("{id}")]
        public ActionResult<List<CourseResponse>> GetById(int id)
        {
            var getbyid = _iCourseService.GetById(id);
            if (getbyid == null)
            {
                return BadRequest("no details found !");
            }
            return Ok(getbyid);
        }

        //AddNewCourse
        [HttpPost]
        public ActionResult InsertCourse(CourseRequest courseRequest)
        {
            var addCourse = _iCourseService.AddCourse(courseRequest);
            return Ok(addCourse);
        }

        //UpdateCourse
        [HttpPut]
        public ActionResult UpdateCourse(CourseResponse courseResponse)
        {
            var updateCourse = _iCourseService.UpdateCourse(courseResponse);
            if (updateCourse == true)
            {
                return Ok(courseResponse);
            }
            return BadRequest("couldn't find the student.");
        }

        //DeleteFaculty
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var deletebyid = _iCourseService.DeleteCourse(id);
            if (deletebyid != true)
            {
                return BadRequest("couldn't find the instructor.");
            }
            return Ok("successfully deleted.");
        }
    }
}
