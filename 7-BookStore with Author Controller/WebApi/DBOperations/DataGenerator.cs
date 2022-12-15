using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book
                if (context.Books.Any())
                {
                    return; // Data was already seeded
                }

                context.Authors.AddRange(
                    new Author{
                        Name = "Aziz",
                        Surname = "Nesin",
                        Birthday = new DateTime(1915, 12, 20)
                    },
                    new Author{
                        Name = "Nazım",
                        Surname = "Hikmet",
                        Birthday = new DateTime(1902, 01, 15)
                    },
                    new Author{
                        Name = "Yaşar",
                        Surname = "Kemal",
                        Birthday = new DateTime(1923, 10, 06)
                    }
                );

                context.Genres.AddRange(
                    new Genre{
                        Name = "Personal Growth"
                    },
                    new Genre{
                        Name = "Science Fiction"
                    },
                    new Genre{
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}