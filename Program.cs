
using learning.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app  = builder.Build();

app.MapBooksEndpoints();

app.Run();