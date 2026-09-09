using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.DTOs.Requests
{
    public class CreateStudentRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60.")]
        public int Age { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty; 
    }
}
