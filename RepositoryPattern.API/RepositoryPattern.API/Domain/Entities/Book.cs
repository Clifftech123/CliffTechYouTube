namespace RepositoryPattern.API.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
