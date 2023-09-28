using movie_store_backend.Services.IServices;
using movie_store_backend.Services;

var builder = WebApplication.CreateBuilder(args);

//CUSTOM
builder.Services.AddSingleton<IMovieService, MovieService>();
//CUSTOM

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
