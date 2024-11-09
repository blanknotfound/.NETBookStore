using learning.Entities;
using System.Collections.Immutable;

namespace learning.Repositories
{

    public class Cachein : IBookRepository
    {
        private readonly List<Book> books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "Rich dad Poor Dad",
                Description = "Rich Dad Poor Dad is a 1997 book written by Robert T. Kiyosaki and Sharon Lechter. It advocates the importance of financial literacy (financial education), financial independence.",
                Genre = "Economy",
                Author = "Robert Kiyosaki",
                imageUri = "https://placehold.co/100",
                ReleaseDate = new DateTime(2024,1,8),
                Price = 100.99M
            },
            new Book()
            {
                Id = 2,
                Title = "A Song of Ice and Fire",
                Description = "A Game of Thrones is the first book in the A Song of Ice and Fire series by George R.R. Martin, published in 1996. The book is set in the fictional continents of Westeros and Essos, where several noble families vie for the Iron Throne of the Seven Kingdoms.",
                Genre = "Fantasy",
                Author = "George R. R. Martin",
                imageUri = "https://placehold.co/100",
                ReleaseDate = new DateTime(2016, 8, 18),
                Price = 89.99M
            },
            new Book()
            {
                Id = 3,
                Title = "Alices adventures in wonderland",
                Description = "lice's Adventures in Wonderland is an 1865 novel written by English author Charles Lutwidge Dodgson under the pseudonym Lewis Carroll. It tells of a girl named Alice falling through a rabbit hole into a fantasy world populated by peculiar, anthropomorphic creatures. The tale plays with logic, giving the story lasting popularity with adults as well as with children.",
                Genre = "Adventure",
                Author = "Lewis Carroll",
                imageUri = "https://placehold.co/100",
                ReleaseDate = new DateTime(2012, 6, 28),
                Price = 95
            }
        };

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.FromResult(books);
        }

        public async Task <Book?> GetAsync(int id)
        {
            return await Task.FromResult(books.Find(book => book.Id == id));
        }

        public async Task CreateAsync(Book book)
        {
            book.Id = books.Max(book => book.Id) + 1;
            books.Add(book);

            await Task.CompletedTask;
        }

        public async Task updateAsync(Book updatedBook)
        {
            var index = books.FindIndex(book => book.Id == updatedBook.Id);
            books[index] = updatedBook;

            await Task.CompletedTask;
        }

        public async Task  DeleteAsync(int id)
        {
            var index = books.FindIndex(book => book.Id == id);
            books.RemoveAt(index);

            await Task.CompletedTask;
        }
    }
}
