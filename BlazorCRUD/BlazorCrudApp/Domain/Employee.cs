using System.ComponentModel.DataAnnotations;

namespace BlazorCrudApp.Domain
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string EmployeName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
