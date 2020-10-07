﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OpenMyGarage.Entity.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
