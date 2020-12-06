using System;

namespace lab_anemic_domain_model.Models
{
    public interface IStudentRepository
    {
        Student GetById(Guid id);
        void Create(Student student);
        void Update(Student student);
    }
}
