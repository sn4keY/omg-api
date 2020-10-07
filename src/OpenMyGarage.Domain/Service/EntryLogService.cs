using AutoMapper;
using OpenMyGarage.Domain.ViewModel;
using OpenMyGarage.Entity.Entity;
using OpenMyGarage.Entity.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OpenMyGarage.Domain.Service
{
    public class EntryLogService : IService<EntryLogViewModel, EntryLog> 
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public EntryLogService(IUnitOfWork uof, IMapper m)
        {
            this.unitOfWork = uof;
            this.mapper = m;
        }

        public IEnumerable<EntryLogViewModel> GetAll()
        {
            var entities = unitOfWork.GetRepository<EntryLog>().GetAll();

            return mapper.Map<IEnumerable<EntryLogViewModel>>(entities);
        }

        public IEnumerable<EntryLogViewModel> Get(Expression<Func<EntryLog, bool>> filter = null, Func<IQueryable<EntryLog>, IOrderedQueryable<EntryLog>> orderBy = null)
        {
            var entities = unitOfWork.GetRepository<EntryLog>().Get(filter, orderBy);

            return mapper.Map<IEnumerable<EntryLogViewModel>>(entities);
        }

        public EntryLogViewModel GetById(object id)
        {
            var entity = unitOfWork.GetRepository<EntryLog>().GetByID(id);

            return mapper.Map<EntryLogViewModel>(entity);
        }

        public void Insert(EntryLogViewModel vm)
        {
            var entity = mapper.Map<EntryLog>(vm);
            unitOfWork.GetRepository<EntryLog>().Insert(entity);
            unitOfWork.Save();
        }

        public void Delete(object id)
        {
            unitOfWork.GetRepository<EntryLog>().Delete(id);
            unitOfWork.Save();
        }

        public void Delete(EntryLogViewModel vm)
        {
            var entity = mapper.Map<EntryLog>(vm);
            unitOfWork.GetRepository<EntryLog>().Delete(entity);
            unitOfWork.Save();
        }

        public void Update(EntryLogViewModel vmToUpdate)
        {
            var entity = mapper.Map<EntryLog>(vmToUpdate);
            unitOfWork.GetRepository<EntryLog>().Update(entity);
        }
    }
}
