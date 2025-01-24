using static DotnetRedisCacheAPI.Models.JsonPlaceholderDtos;

namespace DotnetRedisCacheAPI.Service
{
    public interface IJsonPlaceholderService
    {
        Task<IEnumerable<PostDto>> GetAllPosts();
        Task<IEnumerable<CommentDto>> GetAllComments();
        Task<IEnumerable<AlbumDto>> GetAllAlbums();
        Task<IEnumerable<PhotoDto>> GetAllPhotos();
        Task<IEnumerable<TodoDto>> GetAllTodos();
        Task<IEnumerable<UserDto>> GetAllUsers();

    }
}
