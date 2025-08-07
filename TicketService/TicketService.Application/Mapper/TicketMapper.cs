using AutoMapper;
using TicketService.Application.DTOs;
using TicketService.Domain.Entities;

namespace TicketServices.API.Mapper
{
    public class TicketMapper : Profile
    {
        public TicketMapper() 
        {
            CreateMap<TicketDTOs, Ticket>()
                .ForMember(dest => dest.TicketId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<Ticket, TicketDTOs>().ReverseMap();
            CreateMap<Comment, CommentDTOs>().ReverseMap();
        }        
    }
}
