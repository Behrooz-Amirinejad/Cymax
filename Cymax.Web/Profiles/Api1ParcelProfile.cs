
using AutoMapper;
using Cymax.Web.DTOs.Parcel;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.Models;

namespace Cymax.Web.Profiles
{
    public class Api1ParcelProfile : Profile
    {
        public Api1ParcelProfile()
        {
            CreateMap<Api1ParcelRequestModel, ParcelInputModel>()
                        .ForMember(dest => dest.From,
                                    opt => opt.MapFrom(x => x.ContactAddress))
                        .ForMember(dest => dest.To,
                                    opt => opt.MapFrom(x => x.WarehouseAddress));

        }
    }
}
