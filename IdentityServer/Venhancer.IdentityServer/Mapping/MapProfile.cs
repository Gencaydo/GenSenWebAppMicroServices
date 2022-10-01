using AutoMapper;
using AutoMapper.Features;
using Venhancer.IdentityServer.Dtos;
using Venhancer.IdentityServer.Models;

namespace Venhancer.IdentityServer.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<UserDto, ApplicationUser>().ReverseMap();
        }
    }
}
