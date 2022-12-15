using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model;
        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("The author is not found!");

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string? Name { get; set;}
        public string? Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}