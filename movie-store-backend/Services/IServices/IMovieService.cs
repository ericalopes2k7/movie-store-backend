using movie_store_backend.Core;
using movie_store_backend.DTOs;

namespace movie_store_backend.Services.IServices
{
    public interface IMovieService
    {
        Task<Result<MovieDTO>> CreateMovie(MovieRequestBody dto);
        Task<Result<MovieDTO>> FindMovie(string id);
        Task<Result<List<MovieDTO>>> FindMovies(string title);
        Task<Result<List<MovieDTO>>> FindAllMovies();
        Task<Result<MovieDTO>> UpdateMovie(string id, MovieRequestBody dto);
        Task<Result<MovieDTO>> DeleteMovie(string id);
    }
}
