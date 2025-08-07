using TicketService.Application.DTOs;
using TicketService.Domain.Entities;

namespace TicketService.Application.Services.Abstraction
{
    public interface ITicketAppService
    {
        IEnumerable<TicketDTOs> GetAll();
        TicketDTOs GetById(int id);
        void Add(TicketDTOs ticketDTOs);
        bool Update(int id, TicketDTOs ticketDTOs);
        bool Delete(int id);
    }
}