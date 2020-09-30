using OpenMyGarage.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMyGarage.Entity.UnitofWork
{
    interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }
}
