using System;

namespace lab_anemic_domain_model.Models
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public Student GetById(Guid id) =>
            _repository.GetById(id);

        public void Create(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
                throw new ArgumentException("Invalid name. A student name must be provided.", nameof(student.Name));

            if (student.Name.Length > 100)
                throw new ArgumentException("Invalid name. A valid name should be at maximum 100 characters long.", nameof(student.Name));

            if (student.Age < 6)
                throw new ArgumentException("Invalid age. The minimum age to a student is 6 years old.", nameof(student.Age));

            if (student.Grade < 1)
                throw new ArgumentException("Invalid grade. A student must at least at the first grade.", nameof(student.Grade));

            if (student.Grade > 9)
                throw new ArgumentException("Invalid grade. A last grade possible for a student is the ninth.", nameof(student.Grade));

            student.Id = Guid.NewGuid();

            _repository.Create(student);
        }

        public void Approve(Guid id)
        {
            var student = _repository.GetById(id);
            student.Grade++;
            student.Age++;
            _repository.Update(student);
        }

        public void Reprove(Guid id)
        {
            var student = _repository.GetById(id);
            student.Age++;
            _repository.Update(student);
        }

        public void UpdateName(Guid id, string name)
        {
            var student = _repository.GetById(id);

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid name. A student name must be provided.", nameof(name));

            student.Name = name;
            _repository.Update(student);
        }
    }
}