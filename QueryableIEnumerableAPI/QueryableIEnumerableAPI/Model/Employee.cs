namespace QueryableIEnumerableAPI.Model;

public class Employee
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public  double Salary { get; set; }  
}