using System;

namespace lab_rich_domain_model.Domain
{
    public interface IStudentRepository
    {
        Student GetById(Guid id);
        void Create(Student student);
        void Update(Student student);
    }
}
