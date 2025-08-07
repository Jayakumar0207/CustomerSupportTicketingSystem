using TicketService.Domain.Entities;

namespace TicketService.Application.DTOs
{
    public class TicketDTOs
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public List<CommentDTOs>? Comments { get; set; }
    }
}
