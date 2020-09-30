using AutoMapper;
using OpenMyGarage.Domain.ViewModel;
using OpenMyGarage.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenMyGarage.Api.Mapper
{
    public class MappigProfile : Profile
    {
        public MappigProfile()
        {
            CreateMap<EntryLogViewModel, EntryLog>();
            CreateMap<EntryLog, EntryLogViewModel>();

            CreateMap<StoredPlateViewModel, StoredPlate>();
            CreateMap<StoredPlate, StoredPlateViewModel>();
        }
    }
}
