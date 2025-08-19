using AutoMapper;
using TicketService.Application.DTOs;
using TicketService.Application.Repository;
using TicketService.Application.Services.Abstraction;
using TicketService.Domain.Entities;

namespace TicketService.Application.Services.Implementation
{    
    public class TicketAppService : ITicketAppService
    {
        ITicketServiceRepository _ticketServiceRepository;
        IMapper _mapper;
        public TicketAppService(ITicketServiceRepository ticketServiceRepository, IMapper mapper) 
        {
            _ticketServiceRepository = ticketServiceRepository;
            _mapper = mapper;
        }
        public void Add(TicketDTOs ticketDTOs)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(ticketDTOs);
                _ticketServiceRepository.Add(ticket);
                _ticketServiceRepository.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            
        }

        public bool Delete(int id)
        {
            var ticket = _ticketServiceRepository.GetTicketDetailById(id);
            if (ticket == null)
            {
                return false;
            }
            _ticketServiceRepository.Delete(id);
            _ticketServiceRepository.SaveChanges();
            return true;
        }

        public IEnumerable<TicketDTOs> GetTicketsByUserId(Guid userid)
        {
            var tickets = _ticketServiceRepository.GetTicketsByUserId(userid);
            if(tickets == null)
            {
                return null!;
            }
            return _mapper.Map<IEnumerable<TicketDTOs>>(tickets);
        }

        public TicketDTOs GetTicketDetailById(int id)
        {
            var ticket = _ticketServiceRepository.GetTicketDetailById(id);
            if (ticket == null)
            {
                return null!;
            }
            return _mapper.Map<TicketDTOs>(ticket);
        }

        public bool Update(TicketDTOs ticketDTOs)
        {
            var ticket = _ticketServiceRepository.GetTicketDetailById(ticketDTOs.TicketID);
            if (ticket == null)
            {
                return false;
            }
            _mapper.Map(ticketDTOs, ticket);
            _ticketServiceRepository.Update(ticket);
            _ticketServiceRepository.SaveChanges();
            return true;
        }
    }
}
