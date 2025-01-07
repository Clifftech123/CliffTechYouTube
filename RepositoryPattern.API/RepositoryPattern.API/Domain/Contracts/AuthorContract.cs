namespace RepositoryPattern.API.Domain.Contracts
{
    public record CreateAuthor
    {
        public string Name { get; init; }
        public string Bio { get; init; }
    }

    public record UpdateAuthor
    {
        public string Name { get; init; }
        public string Bio { get; init; }
    }


    public record DeleteAuthor
    {
        public Guid Id { get; init; }


    }

    public record GetAuthor
    {
        public Guid Id { get; init; }
    }


    public class GetAuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<GetBookDto> Books { get; set; }
    }


}