using movie_store_backend.Domain;

namespace movie_store_backend.Repos.IRepos
{
    public interface IMovieRepo : IRepo<Movie>
    {
        Task<List<Movie>> FindMany(string title);
    }
}
