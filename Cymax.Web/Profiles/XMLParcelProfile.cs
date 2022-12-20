using AutoMapper;
using Cymax.Web.DTOs.Parcel;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.Models;
using System.Xml.Linq;

namespace Cymax.Web.Profiles
{
    public class XMLParcelProfile : Profile
    {
        public XMLParcelProfile()
        {
            CreateMap<XMLPracelRequestModel, ParcelInputModel>()
                                 .ForMember(dest => dest.From,
                                             opt => opt.MapFrom(x => x.Source))
                                 .ForMember(dest => dest.To,
                                             opt => opt.MapFrom(x => x.Destination));
        }
    }
}
