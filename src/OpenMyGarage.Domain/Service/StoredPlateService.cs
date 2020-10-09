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
    public class StoredPlateService : IService<StoredPlateViewModel, StoredPlate>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StoredPlateService(IUnitOfWork uof, IMapper m)
        {
            this.unitOfWork = uof;
            this.mapper = m;
        }

        public IEnumerable<StoredPlateViewModel> GetAll()
        {
            var entities = unitOfWork.GetRepository<StoredPlate>().GetAll();

            return mapper.Map<IEnumerable<StoredPlateViewModel>>(entities);
        }

        public IEnumerable<StoredPlateViewModel> Get(Expression<Func<StoredPlate, bool>> filter = null, Func<IQueryable<StoredPlate>, IOrderedQueryable<StoredPlate>> orderBy = null)
        {
            var entities = unitOfWork.GetRepository<StoredPlate>().Get(filter, orderBy);

            return mapper.Map<IEnumerable<StoredPlateViewModel>>(entities);
        }

        public StoredPlateViewModel GetById(object id)
        {
            var entity = unitOfWork.GetRepository<StoredPlate>().GetByID(id);

            return mapper.Map<StoredPlateViewModel>(entity);
        }

        public void Insert(StoredPlateViewModel vm)
        {
            var entity = mapper.Map<StoredPlate>(vm);
            unitOfWork.GetRepository<StoredPlate>().Insert(entity);
            unitOfWork.Save();
        }

        public void Delete(object id)
        {
            unitOfWork.GetRepository<StoredPlate>().Delete(id);
            unitOfWork.Save();
        }

        public void Delete(StoredPlateViewModel vm)
        {
            var entity = mapper.Map<StoredPlate>(vm);
            unitOfWork.GetRepository<StoredPlate>().Delete(entity);
            unitOfWork.Save();
        }

        public void Update(StoredPlateViewModel vmToUpdate)
        {
            var entity = mapper.Map<StoredPlate>(vmToUpdate);
            unitOfWork.GetRepository<StoredPlate>().Update(entity);
            unitOfWork.Save();
        }
    }
}
