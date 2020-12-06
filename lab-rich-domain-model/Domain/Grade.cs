using System;

namespace lab_rich_domain_model.Domain
{
    public struct Grade
    {
        public byte Value { get; private set; }

        public static Grade Of(byte value)
        {
            if (value < 1)
                throw new ArgumentException("Invalid grade. A student must at least at the first grade.");

            if (value > 9)
                throw new ArgumentException("Invalid grade. A last grade possible for a student is the ninth.");

            return new Grade { Value = value };
        }

        public static implicit operator byte(Grade grade) =>
            grade.Value;

        public static Grade operator ++(Grade grade)
        {
            grade.Value++;
            return grade;
        }
    }
}