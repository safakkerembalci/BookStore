using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int GenreId { get; set; }
        public UpdateGenreModel Model;
        public UpdateGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {

            var genre = _dbContext.Genres.SingleOrDefault(genre => genre.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("The book is not found!");

            if (_dbContext.Genres.Any(x=> x.Name!.ToLower() == Model.Name!.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("The book of the same name is available!");
                
            genre.Name = string.IsNullOrEmpty(Model.Name!.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _dbContext.SaveChanges();

        } 
    }
    public class UpdateGenreModel
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}