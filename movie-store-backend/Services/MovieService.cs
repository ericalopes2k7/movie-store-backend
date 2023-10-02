using movie_store_backend.Core;
using movie_store_backend.Domain;
using movie_store_backend.DTOs;
using movie_store_backend.Mapper;
using movie_store_backend.Repos.IRepos;
using movie_store_backend.Services.IServices;

namespace movie_store_backend.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _movieRepo;

        public MovieService(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public async Task<Result<MovieDTO>> CreateMovie(MovieRequestBody dto)
        {
            var newMovie = new Movie(dto.Title, dto.Synopsis, dto.Director, dto.Year);

            await _movieRepo.Create(newMovie);

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(newMovie));
        }

        public async Task<Result<MovieDTO>> FindMovie(string id)
        {
            var movie = await _movieRepo.FindOne(id);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("This movie doesn't exist");
            }

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }

        public async Task<Result<List<MovieDTO>>> FindMovies(string title)
        {
            var movieList = await _movieRepo.FindMany(title);
            if (movieList.Count == 0)
            {
                return Result<List<MovieDTO>>.Fail("There are no movies found with the title '" + title + "'");
            }

            return Result<List<MovieDTO>>.Ok(movieList.ConvertAll(MovieMapper.ToDTO));
        }

        public async Task<Result<List<MovieDTO>>> FindAllMovies()
        {
            var movieList = await _movieRepo.FindAll();
            if (movieList.Count == 0)
            {
                return Result<List<MovieDTO>>.Fail("No movies were found");
            }

            return Result<List<MovieDTO>>.Ok(movieList.ConvertAll(MovieMapper.ToDTO));
        }

        public async Task<Result<MovieDTO>> UpdateMovie(string id, MovieRequestBody dto)
        {
            var movie = await _movieRepo.FindOne(id);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("This movie doesn't exist");
            }

            movie.Title = dto.Title;
            movie.Synopsis = dto.Synopsis;
            movie.Director = dto.Director;
            movie.Year = dto.Year;

            await _movieRepo.CommitChanges();

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }

        public async Task<Result<MovieDTO>> DeleteMovie(string id)
        {
            var movie = await _movieRepo.FindOne(id);
            if (movie == null)
            {
                return Result<MovieDTO>.Fail("This movie doesn't exist");
            }

            await _movieRepo.Delete(movie);

            return Result<MovieDTO>.Ok(MovieMapper.ToDTO(movie));
        }
    }
}
