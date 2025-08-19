using TicketService.Application.DTOs;
using TicketService.Domain.Entities;

namespace TicketService.Application.Services.Abstraction
{
    public interface ITicketAppService
    {
        IEnumerable<TicketDTOs> GetTicketsByUserId(Guid userid);
        TicketDTOs GetTicketDetailById(int id);
        void Add(TicketDTOs ticketDTOs);
        bool Update(TicketDTOs ticketDTOs);
        bool Delete(int id);
    }
}