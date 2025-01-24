namespace DotnetRedisCacheAPI.Models
{
    public class JsonPlaceholderDtos
    {
        public record PostDto(int Id, int UserId, string Titel, string Body);
        public record CommentDto(int Id, int PostId, string Name, string Email, string Body);

        public record AlbumDto(int Id, int UserId, string Title);
        public record PhotoDto(int Id, int AlbumId, string Title, string Url, string ThumbnailUrl);
        public record TodoDto(int Id, int UserId, string Title, bool Completed);
        public record UserDto(int Id, string Name, string Username, string Email);


    }
}
