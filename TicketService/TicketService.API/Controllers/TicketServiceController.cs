using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketService.Application.DTOs;
using TicketService.Application.Services.Abstraction;
using TicketService.Domain.Entities;

namespace TicketServices.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketServiceController : ControllerBase
    {
        ITicketAppService _ticketAppService;
        IMapper _mapper;
        public TicketServiceController(ITicketAppService ticketAppService, IMapper mapper)
        {
            _ticketAppService = ticketAppService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTicketsByUserId(Guid userid)
        {
            var tickets = _ticketAppService.GetTicketsByUserId(userid);
            return Ok(tickets);
        }
        [HttpGet]
        public IActionResult GetTicketDetailById(int id)
        {
            var ticket = _ticketAppService.GetTicketDetailById(id);            
            return Ok(ticket);
        }
        [HttpPost]
        public void CreateTicket(TicketDTOs ticketDTOs)
        {
            _ticketAppService.Add(ticketDTOs);
        }
        [HttpDelete]
        public bool DeleteTicket(int ticketID)
        {
            return _ticketAppService.Delete(ticketID);            
        }
        [HttpPut]
        public bool UpdateTicket([FromBody] TicketDTOs ticketDTOs)
        {
            return _ticketAppService.Update(ticketDTOs);             
        }
    }
}
