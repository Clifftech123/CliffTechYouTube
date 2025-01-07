namespace RepositoryPattern.API.Domain.Contracts
{
    public record CreateBook
    {
        public string Title { get; init; }
        public double Price { get; init; }
        public string Description { get; init; }
        public Guid AuthorId { get; init; }
    }


    public record UpdateBook
    {
        public string Title { get; init; }
        public double Price { get; init; }
        public string Description { get; init; }
        public Guid AuthorId { get; init; }
    }


    public record DeleteBook
    {
        public Guid Id { get; init; }
    }


    public record GetBook
    {
        public Guid Id { get; init; }
    }


    public class GetBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
    }

}
