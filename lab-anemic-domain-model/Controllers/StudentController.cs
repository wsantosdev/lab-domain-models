using lab_anemic_domain_model.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace lab_anemic_domain_model.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService) =>
            _studentService = studentService;

        [HttpGet]
        public IActionResult GetById(Guid studentId)
        {
            return Ok(_studentService.GetById(studentId));
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _studentService.Create(student);

            return Ok();
        }

        [HttpPatch]
        public IActionResult UpdateName(Guid id, string name)
        {
            _studentService.UpdateName(id, name);

            return Ok();
        }
    }
}
