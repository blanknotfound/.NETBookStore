
using learning.Data;
using learning.Endpoints;
using learning.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

var app  = builder.Build();

await app.Services.InitializeDbAsync();

app.MapBooksEndpoints();

app.Run();