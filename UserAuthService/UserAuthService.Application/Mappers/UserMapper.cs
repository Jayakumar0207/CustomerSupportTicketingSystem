using UserAuthService.Application.DTOs;
using UserAuthService.Domain.Entities;
using AutoMapper;


namespace UserAuthService.Application.Mappers
{
    public class UserMapper: Profile
    {
        public UserMapper() { 
            CreateMap<User, UserDTO>()                
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));


            CreateMap<SignUpDTO, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())       // Auto-generated
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());   // Set automatically
        }
    }
}
