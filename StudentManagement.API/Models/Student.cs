namespace StudentManagement.API.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Email { get; set; } = string.Empty;

        public StudentProfile? Profile { get; set; }

        public Department? Department { get; set; }

        public int? DepartmentId { get; set; }
    }

    public class StudentProfile
    {
        public int Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public int StudentId { get; set; }

        public Student? Student { get; set; }
    }
}
