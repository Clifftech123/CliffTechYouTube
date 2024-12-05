namespace GlobalExceptions.src.Contracts
{
    public record CreateStudent(string Name, string Biography);
    public record UpdateStudent(int Id, string Name, string Biography);
    public record StudentDto(int Id, string Name, string Biography);
}
