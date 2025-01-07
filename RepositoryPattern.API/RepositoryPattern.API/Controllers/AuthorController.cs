using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.API.Domain.Contracts;
using RepositoryPattern.API.Domain.Entities;
using RepositoryPattern.API.Repositories;

namespace RepositoryPattern.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthorController : ControllerBase
    {
        private readonly IBaseRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IBaseRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }


        [HttpGet("authors")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorRepository.GetAll(a => a.Books);
            var authorDtos = _mapper.Map<List<GetAuthorDto>>(authors);
            return Ok(authorDtos);
        }


        [HttpGet("authors/{id}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var author = await _authorRepository.Get(id, a => a.Books);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = _mapper.Map<GetAuthorDto>(author);
            return Ok(authorDto);
        }

        [HttpPost("authors")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthor createAuthor)
        {
            var author = _mapper.Map<Author>(createAuthor);
            var createdAuthor = await _authorRepository.Add(author);
            var authorDto = _mapper.Map<GetAuthorDto>(createdAuthor);
            return CreatedAtAction(nameof(GetAuthor), new { id = authorDto.Id }, authorDto);
        }


        [HttpPut("authors/{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] UpdateAuthor updateAuthor)
        {
            var author = await _authorRepository.Get(id);
            if (author == null)
            {
                return NotFound();
            }
            _mapper.Map(updateAuthor, author);
            var updatedAuthor = await _authorRepository.Update(author);
            var authorDto = _mapper.Map<GetAuthorDto>(updatedAuthor);
            return Ok(authorDto);
        }


        [HttpDelete("authors/{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var author = await _authorRepository.Delete(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = _mapper.Map<GetAuthorDto>(author);
            return Ok(authorDto);
        }

    }
}
