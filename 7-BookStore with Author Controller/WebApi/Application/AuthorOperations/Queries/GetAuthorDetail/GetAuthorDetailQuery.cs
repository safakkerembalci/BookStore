using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorsDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(author => author.IsActive && author.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("The author is not found!");
                
            return _mapper.Map<AuthorDetailViewModel>(author);
        }
        public class AuthorDetailViewModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}