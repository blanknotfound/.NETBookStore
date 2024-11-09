using learning.Dtos;
using System.Runtime.CompilerServices;

namespace learning.Entities
{
    public static class EntitiyExtensions
    {
        public static BookDto AsDto(this  Book book)
        {
            return new BookDto(
                book.Id,
                book.Title,
                book.Description,
                book.Genre,
                book.Author,
                book.imageUri,
                book.ReleaseDate,
                book.Price
            );
        }
    }
}
