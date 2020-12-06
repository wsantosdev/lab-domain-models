using System;

namespace lab_rich_domain_model.Domain
{
    public struct Age
    {
        public byte Value { get; private set; }

        public static Age Of(byte value)
        {
            if (value < 6)
                throw new ArgumentException("Invalid age. The minimum age to a student is 6 years old.");

            return new Age { Value = value };
        }

        public static implicit operator byte(Age age) =>
            age.Value;

        public static Age operator ++(Age age)
        {
            age.Value++;
            return age;
        }
    }
}
