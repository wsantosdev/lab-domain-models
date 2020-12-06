using System;

namespace lab_rich_domain_model.Domain
{
    public class Student
    {
        public Guid Id { get; private set; }
        public StudentName Name { get; private set; }
        public Age Age { get; private set; }
        public Grade Grade { get; private set; }

        private Student() { }

        public static Student Create(StudentName name, Age age, Grade grade)
        {
            return new Student
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                Grade = grade
            };
        }

        public void UpdateName(StudentName name) =>
            Name = name;

        public void Approve()
        {
            Grade++;
            Age++;
        }

        public void Reprove() =>
            Age++;
    }
}
