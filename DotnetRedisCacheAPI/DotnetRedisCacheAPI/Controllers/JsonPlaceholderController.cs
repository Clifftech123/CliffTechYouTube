using DotnetRedisCacheAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRedisCacheAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class JsonPlaceholderController : Controller
    {
        private readonly IJsonPlaceholderService _jsonPlaceholderService;

        public JsonPlaceholderController(IJsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }


        [HttpGet("post")]
        public async Task<IActionResult> GetAllPosts()
        {
            var post = await _jsonPlaceholderService.GetAllPosts();
            return Ok(post);
        }

        [HttpGet("comments")]

        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _jsonPlaceholderService.GetAllComments();
            return Ok(comments);
        }


        [HttpGet("albums")]
        public async Task<IActionResult> GetAllAlbums()
        {
            var albums = await _jsonPlaceholderService.GetAllAlbums();
            return Ok(albums);
        }


        [HttpGet("photos")]
        public async Task<IActionResult> GetAllPhotos()
        {
            var photos = await _jsonPlaceholderService.GetAllPhotos();
            return Ok(photos);
        }



        [HttpGet("todos")]

        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _jsonPlaceholderService.GetAllTodos();
            return Ok(todos);
        }


        [HttpGet("users")]

        public async Task<IActionResult> GetAllUser()
        {
            var users = await _jsonPlaceholderService.GetAllUsers();
            return Ok(users);
        }






    }
}
