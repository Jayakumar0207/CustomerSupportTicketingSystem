using TicketService.Domain.Entities;

namespace TicketService.Application.DTOs
{
    public class TicketDTOs
    {
        public required Guid UserId { get; set; }
        public int TicketID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Priority { get; set; }
        public required string Status { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        
    }
}
