using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Traineeship.Application.Contracts;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;
using Traineeship.Domain.Models;
using Traineeship.Domain.Repositories.IServices;

namespace Traineeship_Module.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //GetAllStudents
        [HttpGet]
        public ActionResult<List<StudentResponse>> GetAllStudents()
        {
            var getall = _studentService.GetStudents();
            return Ok(getall);
        }

        //GetStudentsByID
        [HttpGet("{id}")]
        public ActionResult<List<StudentResponse>> GetById(int id)
        {
            var getByID = _studentService.GetById(id);
            if (getByID == null)
            {
                return BadRequest("No Details Found !");
            }
            return Ok(getByID);
        }

        //AddNewStudent
        [HttpPost]
        public ActionResult InsertStudents(StudentRequest studentRequest)
        {
            var addStudent = _studentService.AddStudents(studentRequest);
            return Ok(addStudent);
        }

        //UpdateStudent
        [HttpPut]
        public ActionResult UpdateStudent(StudentResponse studentResponse)
        {
            var updateStudents = _studentService.UpdateStudents(studentResponse);
            if (updateStudents == true)
            {
                return Ok(studentResponse);
            }
            return BadRequest("Couldn't Find the student.");
        }

        //DeleteStudent
        [HttpDelete("{id}")]
        public ActionResult DeleteStudents(int id)
        {
            var deleteById = _studentService.DeleteStudents(id);
            if (deleteById != true)
            {
                return BadRequest("Couldn't find the student.");
            }
            return Ok("Successfully deleted.");
        }

    }
}
