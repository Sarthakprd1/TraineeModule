using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Traineeship.Application.Contracts;
using Traineeship.Application.RequestModels;
using Traineeship.Application.ResponseModels;
using Traineeship.Application.Contracts;

namespace traineeship_module.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Instructorcontroller : ControllerBase
    {
        private readonly IInstructorService _instructorservice;

        public Instructorcontroller(IInstructorService instructorservice)
        {
            _instructorservice = instructorservice;
        }

        //GetAllInstructor
        [HttpGet]
        public ActionResult<List<InstructorResponse>> GetAllInstructor()
        {
            var getall = _instructorservice.GetInstructor();
            return Ok(getall);
        }

        //GetInstructorByID
        [HttpGet("{id}")]
        public ActionResult<List<InstructorResponse>> GetById(int id)
        {
            var getbyid = _instructorservice.GetById(id);
            if (getbyid == null)
            {
                return BadRequest("no details found !");
            }
            return Ok(getbyid);
        }

        //AddNewInstructor
        [HttpPost]
        public ActionResult InsertInstructor(InstructorRequest instructorrequest)
        {
            var addinstructor = _instructorservice.AddInstructor(instructorrequest);
            return Ok(addinstructor);
        }

        //UpdateInstructor
        [HttpPut]
        public ActionResult updateInstructor(InstructorResponse instructorresponse)
        {
            var updateinstructor = _instructorservice.UpdateInstructor(instructorresponse);
            if (updateinstructor == true)
            {
                return Ok(instructorresponse);
            }
            return BadRequest("couldn't find the student.");
        }

        //DeleteInstrutor
        [HttpDelete("{id}")]
        public ActionResult DeleteInstructor(int id)
        {
            var deletebyid = _instructorservice.DeleteInstructor(id);
            if (deletebyid != true)
            {
                return BadRequest("couldn't find the instructor.");
            }
            return Ok("successfully deleted.");
        }

    }
}
