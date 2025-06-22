namespace QueryableIEnumerableAPI.Constract;


public record CreateRequsetEmployeeDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public double Salary { get; set; }
    
};
    
    
public record EmployeeResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public double Salary { get; set; }
}