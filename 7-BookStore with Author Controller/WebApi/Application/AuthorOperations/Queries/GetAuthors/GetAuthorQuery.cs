using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<AuthorsViewModel> Handle()
        {
            var authorList = _dbContext.Authors.Where(x => x.IsActive).OrderBy(x => x.Id).ToList<Author>();
            return _mapper.Map<List<AuthorsViewModel>>(authorList);
        }
        public class AuthorsViewModel
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}