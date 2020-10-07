using AutoMapper;
using OpenMyGarage.Domain.ViewModel;
using OpenMyGarage.Entity.Entity;

namespace OpenMyGarage.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EntryLogViewModel, EntryLog>();
            CreateMap<EntryLog, EntryLogViewModel>();

            CreateMap<StoredPlateViewModel, StoredPlate>();
            CreateMap<StoredPlate, StoredPlateViewModel>();
        }
    }
}
