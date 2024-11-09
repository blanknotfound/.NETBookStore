using learning.Data;
using learning.Entities;
using Microsoft.EntityFrameworkCore;

namespace learning.Repositories
{
    public class EntityFrameworkBooksRepository : IBookRepository
    {
        private readonly BookStoreContext dbContext;

        public EntityFrameworkBooksRepository(BookStoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
           return await dbContext.Books.AsNoTracking().ToListAsync();
        }
        public async Task<Book?> GetAsync(int id)
        {
            return await dbContext.Books.FindAsync(id);
        }

        public async Task CreateAsync(Book book)
        {
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
        }
        public async Task updateAsync(Book updatedBook)
        {
            dbContext.Update(updatedBook);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await dbContext.Books.Where(book => book.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
