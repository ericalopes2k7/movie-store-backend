using movie_store_backend.Services.IServices;
using movie_store_backend.Services;
using movie_store_backend.Repos;
using movie_store_backend.Repos.IRepos;
using movie_store_backend.Core;

var builder = WebApplication.CreateBuilder(args);

//CUSTOM
builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddTransient<IMovieRepo, MovieRepo>();
builder.Services.AddTransient<IMovieService, MovieService>();
//CUSTOM

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
