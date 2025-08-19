using TicketService.Application.Repository;
using TicketService.Domain.Entities;

namespace TicketService.Infrastructure.Repositories
{
    public class TicketServiceRepository : ITicketServiceRepository
    {
        TicketServiceDBContext _dbcontext;
        public TicketServiceRepository(TicketServiceDBContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public void Add(Ticket ticket)
        {
            _dbcontext.Tickets.Add(ticket);
        }

        public void Delete(int id)
        {
            Ticket ticket = _dbcontext.Tickets.Find(id)!;
            if (ticket != null)
            {
                _dbcontext.Tickets.Remove(ticket);
            }
        }

        public IEnumerable<Ticket> GetTicketsByUserId(Guid userid)
        {
            return _dbcontext.Tickets
                .Where(t => t.UserId == userid)
                .ToList();
        }

        public Ticket GetTicketDetailById(int id)
        {
            return _dbcontext.Tickets.Find(id)!;
        }

        public int SaveChanges()
        {
            return _dbcontext.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            _dbcontext.Tickets.Update(ticket);
        }
    }
}
