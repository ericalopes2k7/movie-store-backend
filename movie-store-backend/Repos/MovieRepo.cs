using Microsoft.EntityFrameworkCore;
using movie_store_backend.Core;
using movie_store_backend.Domain;
using movie_store_backend.Repos.IRepos;

namespace movie_store_backend.Repos
{
    public class MovieRepo : Repo<Movie>, IMovieRepo
    {
        public MovieRepo(AppDBContext dbContext) : base(dbContext, dbContext.Movies) { }

        public async Task<List<Movie>> FindMany(string title)
        {
            var ty= await _dbset.Where(x => x.Title.Contains(title)).ToListAsync();
            return ty;
        }
    }
}
