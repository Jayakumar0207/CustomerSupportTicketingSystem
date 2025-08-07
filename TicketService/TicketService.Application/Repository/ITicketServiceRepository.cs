using TicketService.Domain.Entities;

namespace TicketService.Application.Repository
{
    public interface ITicketServiceRepository
    {
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);
        int SaveChanges();
    }
}
