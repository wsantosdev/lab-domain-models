using System;
using System.Text.Json.Serialization;

namespace lab_anemic_domain_model.Models
{
	public class Student
	{
		[JsonIgnore]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public byte Age { get; set; }
		public byte Grade { get; set; }
	}
}
