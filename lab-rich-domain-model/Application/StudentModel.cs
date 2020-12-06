using lab_rich_domain_model.Domain;

namespace lab_rich_domain_model.Application
{
    public record StudentModel
    {
        public string Name { get; private set; }
        public byte Age { get; private set; }
        public byte Grade { get; private set; }

        public static explicit operator StudentModel(Student student) =>
            new StudentModel
            {
		        Name = student.Name,
                Age = student.Age,
                Grade = student.Grade
            };
    }
}
