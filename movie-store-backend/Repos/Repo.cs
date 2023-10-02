using Microsoft.EntityFrameworkCore;
using movie_store_backend.Core;
using movie_store_backend.Repos.IRepos;

namespace movie_store_backend.Repos
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : Entity
    {
        private readonly AppDBContext _dbContext;
        protected readonly DbSet<TEntity> _dbset;

        public Repo(AppDBContext dbContext, DbSet<TEntity> dbset)
        {
            _dbContext = dbContext;
            _dbset = dbset;
        }

        public async Task Create(TEntity obj)
        {
            await _dbset.AddAsync(obj);
            await CommitChanges();
        }

        public async Task<List<TEntity>> FindAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<TEntity?> FindOne(string id)
        {
            return await _dbset.Where(x => x.Id.ToString().Equals(id)).FirstOrDefaultAsync();
        }

        public async Task Delete(TEntity obj)
        {
            _dbset.Remove(obj);
            await CommitChanges();
        }

        public async Task CommitChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
