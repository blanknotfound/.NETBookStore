using System.ComponentModel.DataAnnotations;

namespace learning.Dtos;

public record BookDto(
     int id,
     string Title,
     string Description,
     string Genre,
     string Author,
     string imageUri,
     DateTime ReleaseDate,
     decimal Price
);

public record CreateBookDto(
     [Required][StringLength(100)] string Title,
     [Required][StringLength(300)] string Description,
     [Required][StringLength(40)] string Genre,
     [Required][StringLength(100)] string Author,
     [Url] string imageUri,
     DateTime ReleaseDate,
     [Range(1,300)]decimal Price
);

public record UpdateBookDto(
     [Required][StringLength(100)] string Title,
     [Required][StringLength(300)] string Description,
     [Required][StringLength(40)] string Genre,
     [Required][StringLength(100)] string Author,
     [Url] string imageUri,
     DateTime ReleaseDate,
     [Range(1, 300)] decimal Price
);

