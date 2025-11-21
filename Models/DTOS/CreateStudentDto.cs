using System.ComponentModel.DataAnnotations;

namespace ta.Models.DTOS
{
    public record CreateStudentDto
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
    }
}
