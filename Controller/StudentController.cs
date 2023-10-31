using Microsoft.AspNetCore.Mvc;
using TestKafka.Core.IServices;
using TestKafka.Core.Models;
using TestKafka.Core.Services;

namespace TestKafka.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private  readonly IStudentService _studentService;

        public StudentController(IStudentService student) { 
            _studentService = student;
        }
        [HttpPost]
       public IActionResult Add(Student s)
        {
            _studentService.Add(s);
            return Ok(s);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.Get());
        }
    }
}
