using System.ComponentModel.DataAnnotations;

namespace BlazorCrudApp.Domain
{
    public class CreateEmployeeDto
    {
        [Required]
        public string EmployeName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
    }

    public class UpdateEmployeeDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string EmployeName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }

    public class EmployeeDetailsDto
    {
        public Guid Id { get; set; }
        public string EmployeName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
