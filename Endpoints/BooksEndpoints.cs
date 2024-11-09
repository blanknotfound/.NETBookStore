using learning.Dtos;
using learning.Entities;
using learning.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace learning.Endpoints
{
    public static class BooksEndpoints
    {
        const string GetBookEndPoint = "GetBook";

        public static RouteGroupBuilder MapBooksEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/books")
               .WithParameterValidation();

            group.MapGet("/", async(IBookRepository repository) => 
            (await repository.GetAllAsync()).Select(book => book.AsDto()));

            group.MapGet("/{id}", async(IBookRepository repository,int id) =>
            {
                Book? book = await repository.GetAsync(id);
                return book is not null ? Results.Ok(book.AsDto()) : Results.NotFound();
            })
            .WithName(GetBookEndPoint);

            group.MapPost("/",async (IBookRepository repository,CreateBookDto bookDto) =>
            {
                Book book = new()
                {
                    Title = bookDto.Title,
                    Description = bookDto.Description,
                    Genre = bookDto.Genre,
                    Author = bookDto.Author,
                    imageUri = bookDto.imageUri,
                    ReleaseDate = bookDto.ReleaseDate,
                    Price = bookDto.Price
                };
                await repository.CreateAsync(book);
                return Results.CreatedAtRoute(GetBookEndPoint, new { id = book.Id }, book);
            });

            group.MapPut("/{id}",async (IBookRepository repository, int id, UpdateBookDto updatedbookDto) =>
            {
                Book? existingBooks = await repository.GetAsync(id);

                if (existingBooks is null)
                {
                    return Results.NotFound();
                }

                existingBooks.Title = updatedbookDto.Title;
                existingBooks.Description = updatedbookDto.Description;
                existingBooks.Genre = updatedbookDto.Genre;
                existingBooks.Author = updatedbookDto.Author;
                existingBooks.imageUri = updatedbookDto.imageUri;
                existingBooks.Price = updatedbookDto.Price;

                await repository.updateAsync(existingBooks);
                return Results.NoContent();

            });

            group.MapDelete("/{id}",async (IBookRepository repository,int id) =>
            {
                Book? book = await repository.GetAsync(id);

                if (book is not null)
                {
                    await repository.DeleteAsync(id);
                }

                return Results.NoContent();
            });

            return group;
        }
    }
}
