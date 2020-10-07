using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OpenMyGarage.Domain.Service
{
    public interface IService<TV, TE>
    {
        IEnumerable<TV> GetAll();
        IEnumerable<TV> Get(
            Expression<Func<TE, bool>> filter = null,
            Func<IQueryable<TE>, IOrderedQueryable<TE>> orderBy = null);
        TV GetById(object id);
        void Insert(TV vm);
        void Delete(object id);
        void Delete(TV vm);
        void Update(TV vmToUpdate);
    }
}
