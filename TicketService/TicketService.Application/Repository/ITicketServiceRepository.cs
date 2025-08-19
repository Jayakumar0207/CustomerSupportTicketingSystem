using TicketService.Domain.Entities;

namespace TicketService.Application.Repository
{
    public interface ITicketServiceRepository
    {
        IEnumerable<Ticket> GetTicketsByUserId(Guid userid);
        Ticket GetTicketDetailById(int id);
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);
        int SaveChanges();
    }
}
