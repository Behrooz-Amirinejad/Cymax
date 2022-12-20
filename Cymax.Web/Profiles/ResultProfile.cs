using AutoMapper;
using Cymax.Web.DTOs.ParcelBusinessModels;
using Cymax.Web.ViewModels;

namespace Cymax.Web.Profiles;

public class ResultProfile : Profile
{
    public ResultProfile()
    {
        CreateMap<ParcelOutputModel,Api1ViewModel>().ForMember(dest => dest.Total , opt => opt.MapFrom(x => x.Value)).ReverseMap();
        CreateMap<ParcelOutputModel, Api2ViewModel>().ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.Value)).ReverseMap();
        CreateMap<ParcelOutputModel,XmlViewModel>().ForMember(dest => dest.XmlValue, opt => opt.MapFrom(x => $"<xml><quate> {x.Value.ToString()} </quate></xml>" )).ReverseMap() ;
    }
}
