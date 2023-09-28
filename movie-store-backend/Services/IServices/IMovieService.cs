namespace movie_store_backend.Services.IServices
{
    public interface IMovieService
    {
        string CreateMovie();
        string FindMovie();
        string FindMovies();
        string FindAllMovies();
        string UpdateMovie();
        string DeleteMovie();
    }
}
