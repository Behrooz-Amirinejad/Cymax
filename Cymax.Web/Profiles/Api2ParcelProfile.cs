using AutoMapper;
using Cymax.Web.DTOs.Parcel;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.Models;
using System.Xml.Linq;

namespace Cymax.Web.Profiles
{
    public class Api2ParcelProfile : Profile
    {
        public Api2ParcelProfile()
        {


            CreateMap<Api2ParcelRequestModel, ParcelInputModel>()
                                  .ForMember(dest => dest.From,
                                              opt => opt.MapFrom(x => x.consignee))
                                  .ForMember(dest => dest.To,
                                              opt => opt.MapFrom(x => x.consignor));
        }
    }
}
