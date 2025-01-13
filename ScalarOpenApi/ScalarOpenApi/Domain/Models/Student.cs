namespace ScalarOpenApi.Domain.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double IndexNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt
        {
            get; set;

        }
    }

}
