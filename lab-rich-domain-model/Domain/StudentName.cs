using System;

namespace lab_rich_domain_model.Domain
{
    public record StudentName
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public static StudentName Create(string name, string surname)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid name. A student name and surname must be provided.", nameof(name));

            if (name.Length + surname.Length > 100)
                throw new ArgumentException("Invalid name. A valid name should be at maximum 100 characters long.");

            return new StudentName
            {
                Name = name,
                Surname = surname
            };
        }

        public static implicit operator string(StudentName studentName) =>
            $"{studentName.Name} {studentName.Surname}";
    }
}
