namespace movie_store_backend.Core
{
    public class Entity
    {
        public Guid Id { get; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
