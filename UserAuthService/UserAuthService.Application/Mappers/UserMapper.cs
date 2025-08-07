using UserAuthService.Application.DTOs;
using UserAuthService.Domain.Entities;
using AutoMapper;


namespace UserAuthService.Application.Mappers
{
    public class UserMapper: Profile
    {
        public UserMapper() { 
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Token, opt => opt.Ignore());

            CreateMap<SignUpDTO, User>();
        }
    }
}
