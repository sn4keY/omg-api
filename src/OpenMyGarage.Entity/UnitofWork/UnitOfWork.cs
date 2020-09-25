using OpenMyGarage.Entity.Data;
using OpenMyGarage.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OpenMyGarage.Entity.UnitofWork
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context;
        private Dictionary<Type, object> repositories;
        private bool disposed;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            disposed = false;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
                repositories = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
                repositories[type] = new GenericRepository<TEntity>(context);
            return (IRepository<TEntity>)repositories[type];
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
