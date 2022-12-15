using WebApi.DBOperations;
using AutoMapper;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<GenresViewModel> Handle()
        {
            var genreList = _dbContext.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            return _mapper.Map<List<GenresViewModel>>(genreList);
        }
    }
    public class GenresViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
    }
}