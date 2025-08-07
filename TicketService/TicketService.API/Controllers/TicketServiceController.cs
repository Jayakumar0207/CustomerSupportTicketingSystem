using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketService.Application.DTOs;
using TicketService.Application.Services.Abstraction;
using TicketService.Domain.Entities;

namespace TicketServices.API.Controllers
{
    [Route("api/ticket")]
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
        public IActionResult GetAll()
        {
            var tickets = _ticketAppService.GetAll();
            return Ok(tickets);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ticket = _ticketAppService.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }
        [HttpPost]
        public void Add(TicketDTOs ticketDTOs)
        {
            _ticketAppService.Add(ticketDTOs);
        }
        [HttpDelete]
        public bool Delete(int ticketID)
        {
            _ticketAppService.Delete(ticketID);
            return true;
        }
        [HttpPut("{id}")]
        public bool Update(int id, [FromBody] TicketDTOs ticketDTOs)
        {
            _ticketAppService.Update(id, ticketDTOs); 
            return true;
        }
    }
}
