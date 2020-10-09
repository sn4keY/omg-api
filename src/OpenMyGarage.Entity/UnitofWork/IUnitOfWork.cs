using OpenMyGarage.Entity.Repository;

namespace OpenMyGarage.Entity.UnitofWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }
}
