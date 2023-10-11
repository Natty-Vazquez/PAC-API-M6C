using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

        [HttpGet("students")]
        public IActionResult GetStudents()
        {
            return null;
        }

        [HttpGet("student/{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            return null;
        }

        [HttpPost("student/create")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            return null;
        }
    }
}
