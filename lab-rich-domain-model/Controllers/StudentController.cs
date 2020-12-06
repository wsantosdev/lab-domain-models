using lab_rich_domain_model.Application;
using lab_rich_domain_model.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace lab_rich_domain_model.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository) =>
            _studentRepository = studentRepository;

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetById(Guid studentId)
        {
            return Ok((StudentModel)_studentRepository.GetById(studentId));
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentRequest request)
        {
            var student = Student.Create(StudentName.Create(request.Name, request.Surname),
                                             Age.Of(request.Age),
                                             Grade.Of(request.Grade));

            _studentRepository.Create(student);

            return Ok();
        }

        [HttpPut]
        [Route("/{id}/updatename")]
        public IActionResult UpdateName(Guid id, [FromBody] UpdateStudentNameRequest request)
        {
            var student = _studentRepository.GetById(id);
            student.UpdateName(StudentName.Create(request.Name, request.Surname));

            _studentRepository.Update(student);

            return Ok();
        }

        [HttpPut]
        [Route("/{id}/approve")]
        public IActionResult Approve(Guid id)
        {
            var student = _studentRepository.GetById(id);
            student.Approve();

            _studentRepository.Update(student);

            return Ok();
        }

        [HttpPut]
        [Route("/{id}/reprove")]
        public IActionResult Reprove(Guid id)
        {
            var student = _studentRepository.GetById(id);
            student.Approve();

            _studentRepository.Update(student);

            return Ok();
        }
    }
}
