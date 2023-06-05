using AutoMapper;
using Cymax.WebApp.Models;
using Cymax.WebApp.ViewModels;

namespace Cymax.WebApp.Configurations;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegistrationRequestModel,  User>()
          .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
}
