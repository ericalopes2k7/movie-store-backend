namespace movie_store_backend.Repos.IRepos
{
    public interface IRepo<TEntity> 
    {
        Task Create(TEntity obj);
        Task<List<TEntity>> FindAll();
        Task<TEntity?> FindOne(string id);
        Task Delete(TEntity obj);
        Task CommitChanges();
    }
}
