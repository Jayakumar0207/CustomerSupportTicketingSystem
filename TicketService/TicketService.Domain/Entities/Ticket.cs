using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Domain.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(50)]
        public required string Title { get; set; }
        [Required]
        [StringLength(500)]
        public required string Description { get; set; }
        [Required]
        public required string Priority { get; set; }
        public required string Status { get; set; } // Open, In Progress, Resolved
        public string Comments { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }  
    }
}