namespace ScalarOpenApi.Domain.Contract
{

    public record CreateStudent(string Name, string Email, string Phone, double IndexNumber);
    public record UpdateStudent(Guid Id, string Name, string Email, string Phone, double IndexNumber);

    public record StudentRespond(Guid Id, string Name, string Email, string Phone, double IndexNumber, DateTime CreatedAt, DateTime LastUpdatedAt);
    public record DeleteStudent(Guid Id);

}
