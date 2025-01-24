using static DotnetRedisCacheAPI.Models.JsonPlaceholderDtos;

namespace DotnetRedisCacheAPI.Service
{
    public class JsonPlaceholderService : IJsonPlaceholderService
    {
        private readonly HttpClient _httpClient;
        private readonly IRedisService _redisService;
        private readonly ILogger<JsonPlaceholderService> _logger;
        private const string BASE_URL = "https://jsonplaceholder.typicode.com";
        private const int DEFAULT_CACHE_MINUTE = 5;


        public JsonPlaceholderService(

            HttpClient httpClient
            , IRedisService redisService
            , ILogger<JsonPlaceholderService> logger

            )
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _redisService = redisService ?? throw new ArgumentNullException(nameof(redisService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient.BaseAddress = new Uri(BASE_URL);
        }


        private async Task<IEnumerable<T>> GetCachedDataAsync<T>(string endpoint, string cacheKey, string entityName)
        {
            try
            {
                var cachedData = await _redisService.GetDataAsync<IEnumerable<T>>(cacheKey);
                if (cachedData != null)
                {
                    _logger.LogInformation($"{entityName} retrieved from cache ");
                    return cachedData;
                }

                var data = await _httpClient.GetFromJsonAsync<IEnumerable<T>>(endpoint);
                if (data != null)
                {
                    await _redisService.SetDataAsync(cacheKey, data, DateTime.UtcNow.AddMinutes(DEFAULT_CACHE_MINUTE));
                    _logger.LogInformation($"{entityName} cached successfully ");
                    return data;
                }
                _logger.LogWarning($" No {entityName} data received from API");
                return Enumerable.Empty<T>();


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving {entityName}: {ex.Message}");
                throw;

            }
        }


        public Task<IEnumerable<PostDto>> GetAllPosts() =>

           GetCachedDataAsync<PostDto>("/posts", "posts_all", "posts");



        public Task<IEnumerable<CommentDto>> GetAllComments() =>

           GetCachedDataAsync<CommentDto>("/comments", "comments_all", "Comments");



        public Task<IEnumerable<AlbumDto>> GetAllAlbums() =>
         GetCachedDataAsync<AlbumDto>("/albums", "albums_all", "Albums");



        public Task<IEnumerable<PhotoDto>> GetAllPhotos() =>
             GetCachedDataAsync<PhotoDto>("/photos", "photos_all", "Photos");



        public Task<IEnumerable<TodoDto>> GetAllTodos() =>
           GetCachedDataAsync<TodoDto>("/todos", "todos_all", "Todos");


        public Task<IEnumerable<UserDto>> GetAllUsers() =>
            GetCachedDataAsync<UserDto>("/users", "users_all", "Users");

    }
}
