using learning.Entities;

namespace learning.Repositories
{
    public interface IBookRepository
    {
        Task CreateAsync(Book book);
        Task DeleteAsync(int id);
        Task<Book?> GetAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task updateAsync(Book updatedBook);
    }
}
