using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using static WebApi.Application.AuthorOperations.Queries.GetAuthorsDetail.GetAuthorDetailQuery;
using WebApi.Application.AuthorOperations.Queries.GetAuthorsDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using static WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET Method

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        // GETBYID Method

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AuthorDetailViewModel result;

            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);

            query.AuthorId = id;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
    
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        // POST Method

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);

            command.Model = newAuthor;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();

            validator.ValidateAndThrow(command);
            command.Handle(); 
            return Ok();
        }

        // PUT Method

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.Model = updatedAuthor;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // DELETE Method

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);

            command.AuthorId = id;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}