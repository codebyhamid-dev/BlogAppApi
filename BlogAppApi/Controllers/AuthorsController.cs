using AutoMapper;
using BlogAppApi.Dtos.AuthorDto;
using BlogAppApi.Models;
using BlogAppApi.Repositories.AuthorRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _repository.GetAllAuthorsAsync();
            var authorDtos = _mapper.Map<IEnumerable<readAuthorDto>>(authors);
            return Ok(authorDtos);
        }
        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _repository.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = _mapper.Map<readAuthorDto>(author);
            return Ok(authorDto);
        }
        // POST: api/authors
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] createAuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var author = _mapper.Map<Author>(authorDto);
            await _repository.AddAuthorAsync(author);
            var createdAuthorDto = _mapper.Map<readAuthorDto>(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, createdAuthorDto);
        }
        // PUT: api/authors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] updateAuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingAuthor = await _repository.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            var author = _mapper.Map<Author>(authorDto);
            author.Id = id;
            await _repository.UpdateAuthorAsync(author);
            return NoContent();
        }
        // DELETE: api/authors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var existingAuthor = await _repository.GetAuthorByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            await _repository.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
